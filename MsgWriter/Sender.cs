using MsgWriter.Enums;

namespace MsgWriter
{
    #region Constructor
    /// <summary>
    ///     Contains the message sender's e-mail address.
    /// </summary>
    /// <remarks>
    ///     These properties are examples of the address properties for the message sender. They must be set by the outgoing
    ///     transport provider, which should never propagate any previously existing values.
    /// </remarks>
    public class Sender : Address
    {
        /// <summary>
        ///     Creates this object and sets all it's needed properties
        /// </summary>
        /// <param name="email">The full E-mail address</param>
        /// <param name="displayName">The displayname for the <paramref name="email" /></param>
        /// <param name="addressType">The <see cref="Address.AddressType" /></param>
        public Sender(string email, string displayName, AddressType addressType = AddressType.Smtp)
            : base(email, displayName, addressType)
        {
        }
    }
    #endregion
}