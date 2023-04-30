using System;

namespace MsgKit.HtmParser
{
    [AttributeUsage(AttributeTargets.Field)]
    internal class HtmlAttributeNameAttribute : Attribute
    {
        #region Properties
        public string Name { get; protected set; }
        #endregion

        #region Constructor
        public HtmlAttributeNameAttribute(string name)
        {
            Name = name;
        }
        #endregion
    }
}