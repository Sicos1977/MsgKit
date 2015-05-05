using System;

namespace MsgWriter.Helpers
{
    /// <summary>
    /// Used to add a string value to a enum property
    /// </summary>
    public class StringValue : Attribute
    {
        /// <summary>
        /// The string value
        /// </summary>
        public string Value { get; private set; }
        
        /// <summary>
        /// Creates this object and sets all its properties
        /// </summary>
        /// <param name="value"></param>
        public StringValue(string value)
        {
            Value = value;
        }
    }

    public static class StringEnum
    {
        /// <summary>
        /// Returns the string value that has been set on the enum with the [StringValue()] attribute
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string ToStringValue(this Enum value)
        {
            string result = null;
            
            var type = value.GetType();
            var fieldInfo = type.GetField(value.ToString());
            var customAttributes = fieldInfo.GetCustomAttributes(typeof (StringValue), false) as StringValue[];

            if (customAttributes != null && customAttributes.Length > 0)
                result = customAttributes[0].Value;

            return result;
        }
    }
}