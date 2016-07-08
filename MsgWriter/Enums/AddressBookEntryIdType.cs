namespace MsgWriter.Enums
{
    /// <summary>
    ///     An integer representing the type of the object. It MUST be one of the values from the following table.
    /// </summary>
    public enum AddressBookEntryIdType
    {
        /// <summary>
        /// A local mail user
        /// </summary>
        LocalMailUser = 0x00000000,

        /// <summary>
        /// A distribution list
        /// </summary>
        DistributionList = 0x00000001,

        /// <summary>
        /// A bulletinboard or public folder
        /// </summary>
        BulletinBoardOrPublicFolder = 0x00000002,

        /// <summary>
        /// An automated mailbox
        /// </summary>
        AutomatedMailBox = 0x00000003,

        /// <summary>
        /// An organiztional mailbox
        /// </summary>
        OrganizationalMailBox = 0x00000004,

        /// <summary>
        /// A private distribtion list
        /// </summary>
        PrivateDistributionList = 0x00000005,

        /// <summary>
        /// A remote mail user
        /// </summary>
        RemoteMailUser = 0x00000006,

        /// <summary>
        /// A container
        /// </summary>
        Container = 0x00000100,

        /// <summary>
        /// A template
        /// </summary>
        Template = 0x00000101,

        /// <summary>
        /// One off user
        /// </summary>
        OneOffUser = 0x00000102,

        /// <summary>
        /// Search
        /// </summary>
        Search = 0x00000200
    }
}