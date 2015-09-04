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

        /// <summary>
        /// Returns a string array that contains the substrings in this instance that are delimited by elements of a specified string or Unicode character array.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="separator"></param>
        /// <returns>An array whose elements contain the substrings in this instance that are delimited by one or more characters in separator; returns an empty array if value is null</returns>
        public static string[] NullSafeSplit(this string value, params char[] separator)
        {
            if (value == null)
            {
                return new string[] { };
            }

            return value.Split(separator);
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this instance that are delimited by elements of a specified string or Unicode character array.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="separator"></param>
        /// <param name="options"></param>
        /// <returns>An array whose elements contain the substrings in this instance that are delimited by one or more characters in separator; returns an empty array if value is null</returns>
        public static string[] NullSafeSplit(this string value, char[] separator, StringSplitOptions options)
        {
            if (value == null)
            {
                return new string[] { };
            }

            return value.Split(separator, options);
        }

        /// <summary>
        /// Returns a string array that contains the substrings in this instance that are delimited by elements of a specified string or Unicode character array.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="separator"></param>
        /// <param name="options"></param>
        /// <returns>An array whose elements contain the substrings in this instance that are delimited by one or more characters in separator; returns an empty array if value is null</returns>
        public static string[] NullSafeSplit(this string value, string[] separator, StringSplitOptions options)
        {
            if (value == null)
            {
                return new string[] { };
            }

            return value.Split(separator, options);
        }

        /// <summary>
        /// Converts empty string values to null
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Null if the string is null or empty; returns the original value otherwise</returns>
        public static string EmptyToNull(this string value)
        {
            if (value.IsNullOrEmpty())
            {
                return null;
            }

            return value;
        }

        /// <summary>
        /// Returns a copy of this string converted to uppercase.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>The uppercase equivalent of the current string. Returns null if the current string is null.</returns>
        public static string NullSafeToUpper(this string value)
        {
            if (value == null)
            {
                return value;
            }

            return value.ToUpper();
        }

        /// <summary>
        /// Returns a new string in which all occurrences of a specified string in the current instance are replaced with another specified string.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="oldValue"></param>
        /// <param name="newValue"></param>
        /// <returns
        /// A string that is equivalent to the current string except that all instances of
        //  oldValue are replaced with newValue. If oldValue is not found in the current
        //  instance, the method returns the current instance unchanged. Returns null if the current string is null.
        /// </returns>
        public static string NullSafeReplace(this string value, string oldValue, string newValue)
        {
            if (value == null)
            {
                return value;
            }

            return value.Replace(oldValue, newValue);
        }

        /// <summary>
        /// Returns a new string in which all occurrences of a specified Unicode character in this instance are replaced with another specified Unicode character.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="oldChar"></param>
        /// <param name="newChar"></param>
        /// <returns>>
        /// A string that is equivalent to this instance except that all instances of oldChar
        //  are replaced with newChar. If oldChar is not found in the current instance, the
        //  method returns the current instance unchanged. Returns null if this string is null.
        /// </returns>
        public static string NullSafeReplace(this string value, char oldChar, char newChar)
        {
            if (value == null)
            {
                return value;
            }

            return value.Replace(oldChar, newChar);
        }
    }
}
