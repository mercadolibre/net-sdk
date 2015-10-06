using System;
using System.Collections.Generic;

namespace MercadoLibre.SDK.Meta
{
    /// <summary>
    /// Class to help dealing with enumerations.
    /// </summary>
    public static class EnumHelper
    {
        /// <summary>
        /// Gets the attribute from enum constant.
        /// </summary>
        /// <typeparam name="T">The type of attribute to obtain.</typeparam>
        /// <param name="enumerationValue">The enumeration value.</param>
        /// <returns></returns>
        public static IEnumerable<T> GetAttributesFromEnumConstant<T>(Enum enumerationValue) where T : Attribute
        {
            var type = enumerationValue.GetType();

            var memberInfo = type.GetMember(enumerationValue.ToString());

            if (memberInfo.Length == 0) yield break;

            var attrs = memberInfo[0].GetCustomAttributes(typeof(T), true);

            foreach (var attr in attrs)
            {
                yield return (T) attr;
            }
        }
    }
}
