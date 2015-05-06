using System;
using MsgWriter.Helpers;

namespace MsgWriter
{
    #region PropertyFlags
    /// <summary>
    ///     Flags used to set on a <see cref="FixedLengthProperty" />
    /// </summary>
    [Flags]
    internal enum PropertyFlags
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
    internal enum PropertyType
    {
        /// <summary>
        /// 2 bytes; a 16-bit integer (PT_SHORT, PT_I2, i2, ui2)
        /// </summary>
        [StringValue("0002")] 
        PtypInteger16 = 0x0002,

        /// <summary>
        /// 4 bytes; a 32-bit integer (PT_LONG, PT_I4, int, ui4)
        /// </summary>
        [StringValue("0003")] 
        PtypInteger32 = 0x0003,

        /// <summary>
        /// 4 bytes; a 32-bit floating point number (PT_FLOAT, PT_R4, float, r4)
        /// </summary>
        [StringValue("0004")] 
        PtypFloating32 = 0x0004,

        /// <summary>
        /// 8 bytes; a 64-bit floating point number (PT_DOUBLE, PT_R8, r8)
        /// </summary>
        [StringValue("0005")] 
        PtypFloating64 = 0x0005,

        /// <summary>
        ///     8 bytes; a 64-bit signed, scaled integer representation of a decimal currency value, with four places to the
        ///     right of the decimal point (PT_CURRENCY, fixed.14.4)
        /// </summary>
        [StringValue("0006")] 
        PtypCurrency = 0x0006,

        /// <summary>
        ///     8 bytes; a 64-bit floating point number in which the whole number part represents the number of days since
        ///     December 30, 1899, and the fractional part represents the fraction of a day since midnight (PT_APPTIME)
        /// </summary>
        [StringValue("0007")] 
        PtypFloatingTime = 0x0007,

        /// <summary>
        /// 4 bytes; a 32-bit integer encoding error information as specified in section 2.4.1. (PT_ERROR)
        /// </summary>
        [StringValue("000A")] 
        PtypErrorCode = 0x000A,

        /// <summary>
        /// 1 byte; restricted to 1 or 0 (PT_BOOLEAN. bool)
        /// </summary>
        [StringValue("000B")] 
        PtypBoolean = 0x000B,

        /// <summary>
        /// 8 bytes; a 64-bit integer (PT_LONGLONG, PT_I8, i8, ui8)
        /// </summary>
        [StringValue("0014")] 
        PtypInteger64 = 0x0014,

        /// <summary>
        ///     Variable size; a string of Unicode characters in UTF-16LE format encoding with terminating null character
        ///     (0x0000). (PT_UNICODE, string)
        /// </summary>
        [StringValue("001F")] 
        PtypString = 0x001F,

        /// <summary>
        ///     Variable size; a string of multibyte characters in externally specified encoding with terminating null
        ///     character (single 0 byte). (PT_STRING8)
        /// </summary>
        [StringValue("001E")] 
        PtypString8 = 0x001E,

        /// <summary>
        ///     8 bytes; a 64-bit integer representing the number of 100-nanosecond intervals since January 1, 1601
        ///     (PT_SYSTIME, time, datetime, datetime.tz, datetime.rfc1123, Date, time, time.tz)
        /// </summary>
        [StringValue("0040")] 
        PtypTime = 0x0040,

        /// <summary>
        /// 16 bytes; a GUID with Data1, Data2, and Data3 fields in little-endian format (PT_CLSID, UUID)
        /// </summary>
        [StringValue("0048")]
        PtypGuid = 0x0048,

        /// <summary>
        /// Variable size; a 16-bit COUNT field followed by a structure as specified in section 2.11.1.4. (PT_SVREID)
        /// </summary>
        [StringValue("00FB")]
        PtypServerId = 0x00FB,

        /// <summary>
        ///     Variable size; a byte array representing one or more Restriction structures as specified in section 2.12.
        ///     (PT_SRESTRICT)
        /// </summary>
        [StringValue("00FD")] 
        PtypRestriction = 0x00FD,

        /// <summary>
        ///     Variable size; a 16-bit COUNT field followed by that many rule (4) action (3) structures, as specified in
        ///     [MS-OXORULE] section 2.2.5. (PT_ACTIONS)
        /// </summary>
        [StringValue("00FE")] 
        PtypRuleAction = 0x00FE,

        /// <summary>
        /// Variable size; a COUNT field followed by that many bytes. (PT_BINARY)
        /// </summary>
        [StringValue("0102")] 
        PtypBinary = 0x0102,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypInteger16 values. (PT_MV_SHORT, PT_MV_I2, mv.i2)
        /// </summary>
        [StringValue("1002")]
        PtypMultipleInteger16 = 0x1002,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypInteger32 values. (PT_MV_LONG, PT_MV_I4, mv.i4)
        /// </summary>
        [StringValue("1003")]
        PtypMultipleInteger32 = 0x1003,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypFloating32 values. (PT_MV_FLOAT, PT_MV_R4, mv.float)
        /// </summary>
        [StringValue("1004")] 
        PtypMultipleFloating32 = 0x1004,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypFloating64 values. (PT_MV_DOUBLE, PT_MV_R8)
        /// </summary>
        [StringValue("1005")]
        PtypMultipleFloating64 = 0x1005,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypCurrency values. (PT_MV_CURRENCY, mv.fixed.14.4)
        /// </summary>
        [StringValue("1006")] 
        PtypMultipleCurrency = 0x1006,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypFloatingTime values. (PT_MV_APPTIME)
        /// </summary>
        [StringValue("1007")]
        PtypMultipleFloatingTime = 0x1007,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypInteger64 values. (PT_MV_I8, PT_MV_LONGLONG)
        /// </summary>
        [StringValue("1014")]
        PtypMultipleInteger64 = 0x1014,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypString values. (PT_MV_UNICODE)
        /// </summary>
        [StringValue("0x101F")] 
        PtypMultipleString = 0x101F,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypString8 values. (PT_MV_STRING8, mv.string)
        /// </summary>
        [StringValue("101E")]
        PtypMultipleString8 = 0x101E,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypTime values. (PT_MV_SYSTIME)
        /// </summary>
        [StringValue("1040")]
        PtypMultipleTime = 0x1040,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypGuid values. (PT_MV_CLSID, mv.uuid)
        /// </summary>
        [StringValue("1048")]
        PtypMultipleGuid = 0x1048,

        /// <summary>
        /// Variable size; a COUNT field followed by that many PtypBinary values. (PT_MV_BINARY, mv.bin.hex)
        /// </summary>
        [StringValue("1102")]
        PtypMultipleBinary = 0x1102,

        /// <summary>
        ///     Any: this property type value matches any type; a server MUST return the actual type in its response. Servers
        ///     MUST NOT return this type in response to a client request other than NspiGetIDsFromNames or the
        ///     RopGetPropertyIdsFromNamesROP request ([MS-OXCROPS] section 2.2.8.1). (PT_UNSPECIFIED)
        /// </summary>
        [StringValue("0000")]
        PtypUnspecified = 0x0000,

        /// <summary>
        /// None: This property is a placeholder. (PT_NULL)
        /// </summary>
        [StringValue("0001")]
        PtypNull = 0x0001,

        /// <summary>
        /// The property value is a Component Object Model (COM) object, as specified in section 2.11.1.5. (PT_OBJECT)
        /// </summary>
        [StringValue("000D")]
        PtypObject = 0x000D
    }
    #endregion

    /// <summary>
    ///     A property with a fixed 16 byte size
    /// </summary>
    internal class FixedLengthProperty
    {
        #region Constructor
        /// <summary>
        ///     Creates this object and sets all its propertues
        /// </summary>
        /// <param name="name">The name of the property</param>
        /// <param name="type">The <see cref="PropertyType" /></param>
        /// <param name="flags">The <see cref="PropertyFlags" /></param>
        internal FixedLengthProperty(string name, PropertyType type, PropertyFlags flags)
        {
            Name = name;
            Type = type;
            Flags = flags;
        }
        #endregion

        #region Properties
        /// <summary>
        ///     The name of the property
        /// </summary>
        internal string Name { get; private set; }

        /// <summary>
        ///     The <see cref="PropertyType" />
        /// </summary>
        internal PropertyType Type { get; private set; }

        /// <summary>
        ///     The <see cref="PropertyFlags" />
        /// </summary>
        internal PropertyFlags Flags { get; private set; }
        #endregion
    }
}