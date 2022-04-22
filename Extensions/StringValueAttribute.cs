using System;
using System.Reflection;

namespace GingerMintSoft.Domotica.Gui.Extensions
{
    /// <summary>
    /// This attribute is used to represent a string value for a value in an enum.
    /// </summary>
    public class EnumStringValueAttribute : Attribute 
    {
        #region Properties

        /// <summary>
        /// Holds the stringvalue for a value in an enum.
        /// </summary>
        public string EnumStringValue { get; protected set; }

        #endregion

        #region Constructor

        /// <summary>
        /// Constructor used to init a StringValue Attribute
        /// </summary>
        /// <param name="value"></param>
        public EnumStringValueAttribute(string value) 
        {
            this.EnumStringValue = value;
        }

        #endregion
    }

    public static class StringValue       
    {
       /// <summary>
        /// Will get the string value for a given enums value, this will
        /// only work if you assign the StringValue attribute to
        /// the items in your enum.
        /// </summary>
        /// <param name="value">Enum</param>
        /// <returns>Decorated string value</returns>
        public static string? GetStringValue(this Enum value) 
        {
            // Get the type
            Type type = value.GetType();

            // Get fieldinfo for this type
            FieldInfo? fieldInfo = type.GetField(value.ToString());

            // Get the stringvalue attributes
            EnumStringValueAttribute[]? attribs = fieldInfo?
                .GetCustomAttributes(typeof(EnumStringValueAttribute), false) as EnumStringValueAttribute[];

            // Return the first if there was a match.
            return attribs?.Length == 0 
                ? null 
                : attribs?[0].EnumStringValue;
        }
    }
}
