using System;

namespace MsgKit.Structures
{
    /// <summary>
    ///     The PropertyName_r structure does not support string names for named properties.
    ///     The <see cref="PropertyName_r" /> structure only supports LIDs.
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee204357(v=exchg.80).aspx
    /// </remarks>
    // ReSharper disable once InconsistentNaming
    internal class PropertyName_r
    {
        #region Properties
        /// <summary>
        ///     Encodes the GUID field of the PropertyName structure, as specified in section 2.6.1.
        /// </summary>
        public Guid Guid { get; internal set; }

        /// <summary>
        ///     All clients and servers MUST set this value to 0x00000000.
        /// </summary>
        public uint Reserved { get; internal set; }

        /// <summary>
        ///     This value encodes the LID field in the PropertyName structure, as specified in section 2.6.1. Unlike the optional
        ///     LID field in the PropertyName structure, the LID field is always present in the PropertyName_r structure. Also,
        ///     string names for named properties are not allowed.
        /// </summary>
        public uint Lid { get; internal set; }
        #endregion
    }
}