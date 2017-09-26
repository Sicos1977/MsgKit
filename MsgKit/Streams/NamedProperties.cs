using MsgKit.Structures;
using OpenMcdf;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MsgKit.Streams
{
    internal sealed class NamedProperties : List<NamedProperty>
    {
        private TopLevelProperties _topLevelProperties;
        #region Constructor

        public NamedProperties(TopLevelProperties topLevelProperties)
        {
            _topLevelProperties = topLevelProperties;
        }
        #endregion

        private ushort NamedPropertyIndex = 0;

        //Only support for properties by ID for now. 
        internal void AddProperty(NamedPropertyTag mapiTag, object obj)
        {
            _topLevelProperties.AddProperty(new PropertyTag((ushort)(0x8000+ (NamedPropertyIndex++)), mapiTag.Type), obj); //named property field 0000. 0x8000 + property offset
            Add(new NamedProperty() { NameIdentifier = mapiTag.Id , Guid = mapiTag.Guid, Kind= PropertyKind.Lid }); ;
        }

        #region WriteProperties

        //Unfortunately this is going to have to be used after we already written the top level properties. 
        internal void WriteProperties(CFStorage storage, long messageSize = 0)
        {
            //Grab the nameIdStorage 
            storage = storage.GetStorage(PropertyTags.NameIdStorage); //3.1 on the SPEC

            var entryStream = new EntryStream(storage);
            var stringStream = new StringStream(storage);
            var guidStream = new GuidStream(storage);
            var entryStream2 = new EntryStream(storage);

            ushort propertyIndex = 0;
            var guids = this.Select(x=>x.Guid).Distinct().ToList();
            foreach ( var guid in guids)
            {
                guidStream.Add(guid); //We need to write he GUID this needs to record which index we are writing to (or we keep track of the index)
            }
          
            foreach (var namedProperty in this)
            {
                var guidIndex = (ushort)(guids.IndexOf(namedProperty.Guid) + 3);
                //Dependign on the property type. This is doing name. 
                entryStream.Add(new EntryStreamItem(namedProperty.NameIdentifier, new IndexAndKindInformation(propertyIndex, guidIndex, PropertyKind.Lid))); //+3 as per spec.
                entryStream2.Add(new EntryStreamItem(namedProperty.NameIdentifier, new IndexAndKindInformation(propertyIndex, guidIndex , PropertyKind.Lid))); //3.2.2 of the SPEC [MS-OXMSG]
                entryStream2.Write(storage, GenerateStreamString(namedProperty.NameIdentifier, guidIndex, namedProperty.Kind)); // 3.2.2 of the SPEC Needs to be written, because the stream changes as per named object.
                entryStream2.Clear();
                propertyIndex++;
            }

            guidStream.Write(storage);
            entryStream.Write(storage);
            stringStream.Write(storage);
        }

        internal string GenerateStreamString(uint nameIdentifier, uint guidTarget, PropertyKind propertyKind)
        {
            switch (propertyKind)
            {
                case PropertyKind.Lid:
                    return "__substg1.0_" + ((4096 + ((nameIdentifier ^ (guidTarget << 1)) % 0x1F)) << 16 | 0x00000102).ToString("X").PadLeft(8, '0');
                default:
                    throw new NotImplementedException();
            }
        }


        #endregion


    }
}
