using System.Collections.Generic;
using System.IO;
using System.Text;
using MsgKit.Helpers;
using OpenMcdf;

namespace MsgKit.Streams
{
    /// <summary>
    ///     The string stream MUST be named "__substg1.0_00040102". It MUST consist of one entry for each
    ///     string named property, and all entries MUST be arranged consecutively, like in an array.
    ///     As specified in section 2.2.3.1.2, the offset, in bytes, to use for a particular property is stored in the
    ///     corresponding entry in the entry stream.That is a byte offset into the string stream from where the
    ///     entry for the property can be read.The strings MUST NOT be null-terminated. Implementers can add a
    ///     terminating null character to the string
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee124409(v=exchg.80).aspx
    /// </remarks>
    internal sealed class StringStream : List<StringStreamItem>
    {
        #region Constructors
        /// <summary>
        ///     Creates this object
        /// </summary>
        internal StringStream()
        {

        }

        /// <summary>
        ///     Creates this object and reads all the <see cref="StringStreamItem" /> objects 
        ///     from the given <paramref name="storage"/>
        /// </summary>
        /// <param name="storage">The <see cref="CFStorage"/> that contains the <see cref="PropertyTags.EntryStream"/></param>
        internal StringStream(CFStorage storage)
        {
            var stream = storage.GetStream(PropertyTags.StringStream);
            using (var memoryStream = new MemoryStream(stream.GetData()))
            using (var binaryReader = new BinaryReader(memoryStream))
                while (!binaryReader.Eos())
                {
                    var stringStreamItem = new StringStreamItem(binaryReader);
                    Add(stringStreamItem);
                }
        }
        #endregion

        #region Write
        /// <summary>
        ///     Writes all the <see cref="StringStream"/>'s as a <see cref="CFStream" /> to the
        ///     given <paramref name="storage" />
        /// </summary>
        /// <param name="storage">The <see cref="CFStorage" /></param>
        internal void Write(CFStorage storage)
        {
            var stream = storage.GetStream(PropertyTags.StringStream);
            using (var memoryStream = new MemoryStream())
            using (var binaryWriter = new BinaryWriter(memoryStream))
            {
                foreach (var stringStreamItem in this)
                    stringStreamItem.Write(binaryWriter);

                stream.SetData(memoryStream.ToArray());
            }
        }
        #endregion
    }

    /// <summary>
    ///     Represents one item in the <see cref="StringStream"/> stream
    /// </summary>
    internal sealed class StringStreamItem
    {
        #region Properties
        /// <summary>
        ///     The length of the following <see cref="Name"/> field in bytes.
        /// </summary>
        public uint Length { get; }

        /// <summary>
        ///     A Unicode string that is the name of the property. A new entry MUST always start
        ///     on a 4 byte boundary; therefore, if the size of the Name field is not an exact multiple of 4, and
        ///     another Name field entry occurs after it, null characters MUST be appended to the stream after it
        ///     until the 4-byte boundary is reached.The Name Length field for the next entry will then start at
        ///     the beginning of the next 4-byte boundary
        /// </summary>
        public string Name { get; }
        #endregion

        #region Constructors
        /// <summary>
        ///     Creates this object and reads all the properties from the given <paramref name="binaryReader" />
        /// </summary>
        /// <param name="binaryReader">The <see cref="BinaryReader"/></param>
        internal StringStreamItem(BinaryReader binaryReader)
        {
            Length = binaryReader.ReadUInt32();
            Name = Encoding.Unicode.GetString(binaryReader.ReadBytes((int) Length)).Trim('\0');
            var boundry = Get4BytesBoundry(Length);
            binaryReader.ReadBytes((int) boundry);
        }

        /// <summary>
        ///     Creates this object and sets all it's needed properties
        /// </summary>
        /// <param name="name"><see cref="Name"/></param>
        internal StringStreamItem(string name)
        {
            Length = (uint) name.Length;
            Name = name;
        }
        #endregion

        #region Write
        /// <summary>
        ///     Writes all the internal properties to the given <paramref name="binaryWriter" />
        /// </summary>
        /// <param name="binaryWriter"></param>
        internal void Write(BinaryWriter binaryWriter)
        {
            binaryWriter.Write(Length);
            binaryWriter.Write(Name);
            var boundry = Get4BytesBoundry(Length);
            var bytes = new byte[boundry];
            binaryWriter.Write(bytes);
        }
        #endregion

        #region Get4BytesBoundry
        /// <summary>
        ///     Extract 4 from the given <paramref name="length"/> until the result is smaller
        ///     then 4 and then returns this result;
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private static uint Get4BytesBoundry(uint length)
        {
            if (length == 0) return 4;

            while (length >= 4)
                length -= 4;

            return length;
        }
        #endregion
    }
}
