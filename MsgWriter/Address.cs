using System;
using MsgWriter.Enums;

namespace MsgWriter
{
    /// <summary>
    ///     A base class for <see cref="Sender"/> and <see cref="Recipient"/>
    /// </summary>
    public class Address
    {
        #region Fields
        private AddressType _addressType;
        #endregion

        #region Properties
        /// <summary>
        ///     The E-mail address
        /// </summary>
        public string Email { get; internal set; }

        /// <summary>
        ///     The displayname for the <see cref="Email"/>
        /// </summary>
        public string DisplayName { get; internal set; }
        /// <summary>
        ///     Returns the messaging user's e-mail address type. Use <see cref="AddressTypeString"/>
        ///     when this property returns <see cref="Enums.AddressType.Unknown"/>
        /// </summary>
        public AddressType AddressType
        {
            get { return _addressType; }
            internal set
            {
                _addressType = value;
                switch (value)
                {
                    case AddressType.Unknown:
                        AddressTypeString = string.Empty;
                        break;

                    case AddressType.Ex:
                        AddressTypeString = "EX";
                        break;

                    case AddressType.Smtp:
                        AddressTypeString = "SMTP";
                        break;

                    case AddressType.Fax:
                        AddressTypeString = "FAX";
                        break;

                    case AddressType.Mhs:
                        AddressTypeString = "MHS";
                        break;

                    case AddressType.Profs:
                        AddressTypeString = "PROFS";
                        break;

                    case AddressType.X400:
                        AddressTypeString = "X400";
                        break;

                    default:
                        throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }
            }
        }

        /// <summary>
        ///     Returns the <see cref="Enums.AddressType"/> as a string
        /// </summary>
        public string AddressTypeString { get; private set; }
        #endregion
    }
}
