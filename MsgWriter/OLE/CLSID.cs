using System;
using System.IO;
using System.Linq;

namespace MsgWriter.OLE
{
    /// <summary>
    ///     The packet version of the CLSID structure represents a class identifier (CLSID) in a serialized manner.
    /// </summary>
    // ReSharper disable once InconsistentNaming
    internal class CLSID
    {
        #region Properties
        /// <summary>
        ///     Data1 (4 bytes): This MUST be identical in meaning to the Data1 field specified in [MS-DTYP] section 2.3.4.
        /// </summary>
        public byte[] Data1 { get; private set; }

        /// <summary>
        ///     Data2 (2 bytes): This MUST be identical in meaning to the Data2 field specified in [MS-DTYP] section 2.3.4.
        /// </summary>
        public byte[] Data2 { get; private set; }

        /// <summary>
        ///     Data3 (2 bytes): This MUST be identical in meaning to the Data3 field specified in [MS-DTYP] section 2.3.4.
        /// </summary>
        public byte[] Data3 { get; private set; }

        /// <summary>
        ///     Data4 (8 bytes): This MUST be identical in meaning to the Data4 field specified in [MS-DTYP] section 2.3.4.
        /// </summary>
        public byte[] Data4 { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        ///     Creatis this object and sets all it properties
        /// </summary>
        /// <param name="binaryReader"></param>
        internal CLSID(BinaryReader binaryReader)
        {
            Data1 = binaryReader.ReadBytes(4).Reverse().ToArray();
            Data2 = binaryReader.ReadBytes(2).Reverse().ToArray();
            Data3 = binaryReader.ReadBytes(2).Reverse().ToArray();
            Data4 = binaryReader.ReadBytes(8).Reverse().ToArray();
        }
        #endregion

        #region ToGuid
        /// <summary>
        ///     Returns <see cref="Data1" />, <see cref="Data2" />, <see cref="Data3" />, <see cref="Data4" /> as
        ///     a <see cref="Guid" />
        /// </summary>
        public Guid ToGuid()
        {
            return new Guid(Data1.Concat(Data2).Concat(Data3).Concat(Data4).ToArray());
        }
        #endregion
    }
}