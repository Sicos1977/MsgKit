using System;

namespace MsgWriter.Exceptions
{
    /// <summary>
    /// Raised when a property is invalid
    /// </summary>
    public class MWInvalidProperty : Exception
    {
        internal MWInvalidProperty()
        {
        }

        internal MWInvalidProperty(string message) : base(message)
        {
        }

        internal MWInvalidProperty(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
