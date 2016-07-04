using System;
using MsgWriter.Structures;

namespace MsgWriter.Enums
{
    /// <summary>
    ///     Flags used to set on a <see cref="Property" />
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/ee158556(v=exchg.80).aspx
    /// </remarks>
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
}