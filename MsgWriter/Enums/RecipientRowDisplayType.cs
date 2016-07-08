namespace MsgWriter.Enums
{
    /// <summary>
    ///     An enumeration. This field MUST be present when the Type field
    ///     of the RecipientFlags field is set to X500DN(0x1) and MUST NOT be present otherwise.This
    ///     value specifies the display type of this address.Valid values for this field are specified in the
    ///     following table.
    /// </summary>
    public enum RecipientRowDisplayType
    {
        /// <summary>
        ///     A messaging user
        /// </summary>
        MessagingUser = 0x00,

        /// <summary>
        ///     A distribution list
        /// </summary>
        DistributionList = 0x01,

        /// <summary>
        ///     A forum, such as a bulletin board service or a public or shared folder
        /// </summary>
        Forum = 0x02,

        /// <summary>
        ///     An automated agent
        /// </summary>
        AutomatedAgent = 0x03,

        /// <summary>
        ///     An Address Book object defined for a large group, such as helpdesk, accounting, coordinator, or
        ///     department
        /// </summary>
        AddressBook = 0x04,

        /// <summary>
        ///     A private, personally administered distribution list
        /// </summary>
        PrivateDistributionList = 0x05,

        /// <summary>
        ///     An Address Book object known to be from a foreign or remote messaging system
        /// </summary>
        RemoteAddressBook = 0x06
    }
}