using System;
using System.Collections.Generic;
using System.Linq;

namespace TOTD.Utility.StringHelpers
{
    public static class StringExtensions
    {
        /// <summary>
        /// Determines whether a string is null or empty
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrEmpty(this string value)
        {
            return String.IsNullOrEmpty(value);
        }

        /// <summary>
        /// Determines whether a string is null, empty or consists of only white-space characters
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static bool IsNullOrWhiteSpace(this string value)
        {
            return String.IsNullOrWhiteSpace(value);
        }

        /// <summary>
        /// Uses string.equals to compare one string to another without throwing an exception if the first string is null
        /// Specifies StringComparison.OrdinalIgnoreCase for the comparison type
        /// </summary>
        /// <param name="value"></param>
        /// <param name="compare"></param>
        /// <returns></returns>
        public static bool SafeEquals(this string value, string compare)
        {
            return SafeEquals(value, compare, StringComparison.OrdinalIgnoreCase);
        }

        /// <summary>
        /// Uses string.equals to compare one string to another without throwing an exception if the first string is null
        /// </summary>
        /// <param name="value"></param>
        /// <param name="compare"></param>
        /// <param name="comparisonType"></param>
        /// <returns></returns>
        public static bool SafeEquals(this string value, string compare, StringComparison comparisonType)
        {
            return string.Equals(value, compare, comparisonType);
        }

        /// <summary>
        /// Returns the result of string.Trim without throwing an exception if the given string is null
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string SafeTrim(this string value)
        {
            if (value == null)
            {
                return null;
            }

            return value.Trim();
        }
    }
}
