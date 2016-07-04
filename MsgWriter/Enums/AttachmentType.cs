// ReSharper disable InconsistentNaming
namespace MsgWriter.Enums
{
    /// <summary>
    ///     The type of the attachment
    /// </summary>
    /// <remarks>
    ///     See https://msdn.microsoft.com/en-us/library/office/cc815439.aspx
    /// </remarks>
    public enum AttachmentType : uint
    {
        /// <summary>
        ///     There is no attachment
        /// </summary>
        NO_ATTACHMENT = 0x0000,

        /// <summary>
        ///     The  <see cref="PropertyTags.PR_ATTACH_DATA_BIN" /> property contains the attachment data
        /// </summary>
        ATTACH_BY_VALUE = 0x0001,

        /// <summary>
        ///     The <see cref="PropertyTags.PR_ATTACH_PATHNAME_W" /> or <see cref="PropertyTags.PR_ATTACH_LONG_PATHNAME_W" />
        ///     property contains a fully qualified path identifying the attachment to recipients with access to a common file server
        /// </summary>
        ATTACH_BY_REFERENCE = 0x0002,

        /// <summary>
        ///     The <see cref="PropertyTags.PR_ATTACH_PATHNAME_W" /> or <see cref="PropertyTags.PR_ATTACH_LONG_PATHNAME_W" />
        ///     property contains a fully qualified path identifying the attachment
        /// </summary>
        ATTACH_BY_REF_RESOLVE = 0x0003,

        /// <summary>
        ///     The <see cref="PropertyTags.PR_ATTACH_PATHNAME_W" /> or <see cref="PropertyTags.PR_ATTACH_LONG_PATHNAME_W" />
        ///     property contains a fully qualified path identifying the attachment
        /// </summary>
        ATTACH_BY_REF_ONLY = 0x0004,

        /// <summary>
        ///     The  <see cref="PropertyTags.PR_ATTACH_DATA_OBJ" /> (PidTagAttachDataObject) property contains an embedded object
        ///     that supports the IMessage interface
        /// </summary>
        ATTACH_EMBEDDED_MSG = 0x0005,

        /// <summary>
        ///     The attachment is an embedded OLE object
        /// </summary>
        ATTACH_OLE = 0x0006
    }
}