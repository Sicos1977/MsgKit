using System;

namespace MsgWriter.Exceptions
{
    /// <summary>
    /// Raised when an attachment with the same name already exists
    /// </summary>
    public class MWAttachmentExists : Exception
    {
        internal MWAttachmentExists() 
        {
        }

        internal MWAttachmentExists(string message) : base(message)
        {
        }

        internal MWAttachmentExists(string message, Exception inner) : base(message, inner)
        {
        }
    }
}