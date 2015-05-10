using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace MsgWriter
{
    #region PropertyFlags
    /// <summary>
    ///     Flags used to set on a <see cref="FixedLengthProperty" />
    /// </summary>
    [Flags]
    internal enum PropertyFlag : uint
    {
        // ReSharper disable InconsistentNaming
        /// <summary>
        ///     If this flag is set for a property, that property MUST NOT be deleted from the .msg file
        ///     (irrespective of which storage it is contained in) and implementations MUST return an error
        ///     if any attempt is made to do so. This flag is set in circumstances where the implementation
        ///     depends on that property always being present in the .msg file once it is written there.
        /// </summary>
        PROPATTR_MANDATORY = 0x00000001,

        /// <summary>
        ///     If this flag is not set on a property, that property MUST NOT be read from the .msg file
        ///     and implementations MUST return an error if any attempt is made to read it. This flag is
        ///     set on all properties unless there is an implementation-specific reason to prevent a property
        ///     from being read from the .msg file.
        /// </summary>
        PROPATTR_READABLE = 0x00000002,

        /// <summary>
        ///     If this flag is not set on a property, that property MUST NOT be modified or deleted and
        ///     implementations MUST return an error if any attempt is made to do so. This flag is set in
        ///     circumstances where the implementation depends on the properties being writable.
        /// </summary>
        PROPATTR_WRITABLE = 0x00000004
        // ReSharper restore InconsistentNaming
    }
    #endregion

    #region PropertyType
    /// <summary>
    ///     The type of a property in the properties stream
    /// </summary>
    internal enum PropertyType : ushort
    {
        /// <summary>
        /// 2 bytes; a 16-bit integer (PT_SHORT, PT_I2, i2, ui2)
        /// </summary>
        PtypInteger16 = 0x0002,

        /// <summary>
        /// 4 bytes; a 32-bit integer (PT_LONG, PT_I4, int, ui4)
        /// </summary>
        PtypInteger32 = 0x0003,

        /// <summary>
        /// 4 bytes; a 32-bit floating point number (PT_FLOAT, PT_R4, float, r4)
        /// </summary>
        PtypFloating32 = 0x0004,

        /// <summary>
        /// 8 bytes; a 64-bit floating point number (PT_DOUBLE, PT_R8, r8)
        /// </summary>
        PtypFloating64 = 0x0005,

        /// <summary>
        ///     8 bytes; a 64-bit signed, scaled integer representation of a decimal currency value, with four places to the
        ///     right of the decimal point (PT_CURRENCY, fixed.14.4)
        /// </summary>
        PtypCurrency = 0x0006,

        /// <summary>
        ///     8 bytes; a 64-bit floating point number in which the whole number part represents the number of days since
        ///     December 30, 1899, and the fractional part represents the fraction of a day since midnight (PT_APPTIME)
        /// </summary>
        PtypFloatingTime = 0x0007,

        /// <summary>
        /// 4 bytes; a 32-bit integer encoding error information as specified in section 2.4.1. (PT_ERROR)
        /// </summary>
        PtypErrorCode = 0x000A,

        /// <summary>
        /// 1 byte; restricted to 1 or 0 (PT_BOOLEAN. bool)
        /// </summary>
        PtypBoolean = 0x000B,

        /// <summary>
        /// 8 bytes; a 64-bit integer (PT_LONGLONG, PT_I8, i8, ui8)
        /// </summary>
        PtypInteger64 = 0x0014,

        /// <summary>
        ///     Variable size; a string of Unicode characters in UTF-16LE format encoding with terminating null character
        ///     (0x0000). (PT_UNICODE, string)
        /// </summary>
        PtypString = 0x001F,

        /// <summary>
        ///     Variable size; a string of multibyte characters in externally specified encoding with terminating null
        ///     character (single 0 byte). (PT_STRING8)
        /// </summary>
        PtypString8 = 0x001E,

        /// <summary>
        ///     8 bytes; a 64-bit integer representing the number of 100-nanosecond intervals since January 1, 1601
        ///     (PT_SYSTIME, time, datetime, datetime.tz, datetime.rfc1123, Date, time, time.tz)
        /// </summary>
        PtypTime = 0x0040,

        /// <summary>
        /// 16 bytes; a GUID with Data1, Data2, and Data3 fields in little-endian format (PT_CLSID, UUID)
        /// </summary>
        PtypGuid = 0x0048,

        /// <summary>
        /// Variable size; a 16-bit COUNT field followed by a structure as specified in section 2.11.1.4. (PT_SVREID)
        /// </summary>
        PtypServerId = 0x00FB,

        /// <summary>
        ///     Variable size; a byte array representing one or more Restriction structures as specified in section 2.12.
        ///     (PT_SRESTRICT)
        /// </summary>
        PtypRestriction = 0x00FD,

        /// <summary>
        ///     Variable size; a 16-bit COUNT field followed by that many rule (4) action (3) structures, as specified in
        ///     [MS-OXORULE] section 2.2.5. (PT_ACTIONS)
        /// </summary>
        PtypRuleAction = 0x00FE,

        /// <summary>
        /// Variable size; a COUNT field followed by that many bytes. (PT_BINARY)
        /// </summary>
        PtypBinary = 0x0102,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypInteger16 values. (PT_MV_SHORT, PT_MV_I2, mv.i2)
        /// </summary>
        PtypMultipleInteger16 = 0x1002,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypInteger32 values. (PT_MV_LONG, PT_MV_I4, mv.i4)
        /// </summary>
        PtypMultipleInteger32 = 0x1003,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypFloating32 values. (PT_MV_FLOAT, PT_MV_R4, mv.float)
        /// </summary>
        PtypMultipleFloating32 = 0x1004,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypFloating64 values. (PT_MV_DOUBLE, PT_MV_R8)
        /// </summary>
        PtypMultipleFloating64 = 0x1005,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypCurrency values. (PT_MV_CURRENCY, mv.fixed.14.4)
        /// </summary>
        PtypMultipleCurrency = 0x1006,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypFloatingTime values. (PT_MV_APPTIME)
        /// </summary>
        PtypMultipleFloatingTime = 0x1007,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypInteger64 values. (PT_MV_I8, PT_MV_LONGLONG)
        /// </summary>
        PtypMultipleInteger64 = 0x1014,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypString values. (PT_MV_UNICODE)
        /// </summary>
        PtypMultipleString = 0x101F,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypString8 values. (PT_MV_STRING8, mv.string)
        /// </summary>
        PtypMultipleString8 = 0x101E,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypTime values. (PT_MV_SYSTIME)
        /// </summary>
        PtypMultipleTime = 0x1040,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypGuid values. (PT_MV_CLSID, mv.uuid)
        /// </summary>
        PtypMultipleGuid = 0x1048,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypBinary values. (PT_MV_BINARY, mv.bin.hex)
        /// </summary>
        PtypMultipleBinary = 0x1102,

        /// <summary>
        ///     Any: this property type value matches any type; a server MUST return the actual type in its response. Servers
        ///     MUST NOT return this type in response to a client request other than NspiGetIDsFromNames or the
        ///     RopGetPropertyIdsFromNamesROP request ([MS-OXCROPS] section 2.2.8.1). (PT_UNSPECIFIED)
        /// </summary>
        PtypUnspecified = 0x0000,

        /// <summary>
        /// None: This property is a placeholder. (PT_NULL)
        /// </summary>
        PtypNull = 0x0001,

        /// <summary>
        /// The property value is a Component Object Model (COM) object, as specified in section 2.11.1.5. (PT_OBJECT)
        /// </summary>
        PtypObject = 0x000D
    }
    #endregion

    /// <summary>
    ///     A property with a fixed 16 byte size
    /// </summary>
    internal class FixedLengthProperty
    {
        #region Properties
        /// <summary>
        ///     The id of the property
        /// </summary>
        internal UInt16 Id { get; private set; }

        /// <summary>
        ///     The <see cref="PropertyType" />
        /// </summary>
        internal PropertyType Type { get; private set; }

        /// <summary>
        ///     The <see cref="PropertyFlag" >property flags</see> that have been set
        ///     in its <see cref="uint"/> raw form
        /// </summary>
        internal uint Flags { get; private set; }

        /// <summary>
        ///     The <see cref="PropertyFlag" >property flags</see> that have been set
        ///     as a readonly collection
        /// </summary>
        internal ReadOnlyCollection<PropertyFlag> FlagsCollection 
        {
            get
            {
                var result = new List<PropertyFlag>();

                if ((Flags & Convert.ToUInt32(PropertyFlag.PROPATTR_MANDATORY)) != 0)
                    result.Add(PropertyFlag.PROPATTR_MANDATORY);

                if ((Flags & Convert.ToUInt32(PropertyFlag.PROPATTR_READABLE)) != 0)
                    result.Add(PropertyFlag.PROPATTR_READABLE);

                if ((Flags & Convert.ToUInt32(PropertyFlag.PROPATTR_WRITABLE)) != 0)
                    result.Add(PropertyFlag.PROPATTR_WRITABLE);

                return result.AsReadOnly();
            } 
        }

        /// <summary>
        ///     The property data
        /// </summary>
        internal byte[] Data { get; private set; }
        #endregion

        #region Constructor
        /// <summary>
        ///     Creates this object and sets all its propertues
        /// </summary>
        /// <param name="id">The id of the property</param>
        /// <param name="type">The <see cref="PropertyType" /></param>
        /// <param name="flags">The <see cref="PropertyFlag" /></param>
        /// <param name="data">The property data</param>
        internal FixedLengthProperty(ushort id, PropertyType type, PropertyFlag flags, byte[] data)
        {
            Id = id;
            Type = type;
            Flags = Convert.ToUInt32(flags);
            Data = data;
        }

        /// <summary>
        ///     Creates this object and sets all its propertues
        /// </summary>
        /// <param name="id">The id of the property</param>
        /// <param name="type">The <see cref="PropertyType" /></param>
        /// <param name="flags">The <see cref="PropertyFlag" /></param>
        /// <param name="data">The property data</param>
        internal FixedLengthProperty(ushort id, PropertyType type, uint flags, byte[] data)
        {
            Id = id;
            Type = type;
            Flags = flags;
            Data = data;
        }
        #endregion
    }
}