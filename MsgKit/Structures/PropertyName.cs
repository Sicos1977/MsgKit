using System;
using MsgKit.Streams;

namespace MsgKit.Structures
{
    /// <summary>
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee158295(v=exchg.80).aspx
    /// </remarks>
    internal class PropertyName : PropertyName_r
    {
        #region Properties
        /// <summary>
        ///     The possible values for the Kind field are in the following table.
        /// </summary>
        public PropertyKind Kind { get; internal set; }

        /// <summary>
        ///     The value of this field is equal to the number of bytes in the Name string that follows it. This field is present
        ///     only if the value of the <see cref="Kind" /> field is equal to <see cref="PropertyKind.Name" />
        /// </summary>
        /// <remarks>
        ///     Optional
        /// </remarks>
        public uint NameSize { get; internal set; }

        /// <summary>
        ///     This field is present only if <see cref="Kind" /> is equal to <see cref="PropertyKind.Name" />. The value is a
        ///     Unicode (UTF-16 format) string, followed by two zero bytes as terminating null characters, that identifies the
        ///     property within its property set.
        /// </summary>
        /// <remarks>
        ///     Optional
        /// </remarks>
        public string Name { get; internal set; }
        #endregion
    }
}