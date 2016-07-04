namespace MsgWriter.Enums
{
    /// <summary>
    ///     The type of the attachment
    /// </summary>
    public enum AttachmentType : uint
    {
        /// <summary>
        ///     There is no attachment
        /// </summary>
        NoAttachment = 0x0000,

        /// <summary>
        ///     The  <see cref="PropertyTags.PR_ATTACH_DATA_BIN" /> property contains the attachment data
        /// </summary>
        AttachByValue = 0x0001,

        /// <summary>
        ///     The <see cref="PropertyTags.PR_ATTACH_PATHNAME_W" /> or <see cref="PropertyTags.PR_ATTACH_LONG_PATHNAME_W" />
        ///     property contains a fully qualified path identifying the attachment to recipients with access to a common file server
        /// </summary>
        AttachByReference = 0x0002,

        /// <summary>
        ///     The <see cref="PropertyTags.PR_ATTACH_PATHNAME_W" /> or <see cref="PropertyTags.PR_ATTACH_LONG_PATHNAME_W" />
        ///     property contains a fully qualified path identifying the attachment
        /// </summary>
        AttachByRefResolve = 0x0003,

        /// <summary>
        ///     The <see cref="PropertyTags.PR_ATTACH_PATHNAME_W" /> or <see cref="PropertyTags.PR_ATTACH_LONG_PATHNAME_W" />
        ///     property contains a fully qualified path identifying the attachment
        /// </summary>
        AttachByRefOnly = 0x0004,

        /// <summary>
        ///     The  <see cref="PropertyTags.PR_ATTACH_DATA_OBJ" /> (PidTagAttachDataObject) property contains an embedded object
        ///     that supports the IMessage interface
        /// </summary>
        AttachEmbeddedMsg = 0x0005,

        /// <summary>
        ///     The attachment is an embedded OLE object
        /// </summary>
        AttachOle = 0x0006
    }
}