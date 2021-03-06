﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Utility.StringHelpers;

namespace TODT.Test.UtilityTests
{
    [TestClass]
    public class StringExtensionsTests
    {
        [TestClass]
        public class IsNullOrEmptyMethod
        {
            [TestMethod]
            public void ReturnsTrueForNullValue()
            {
                string test = null;
                test.IsNullOrEmpty()
                    .Should()
                    .BeTrue("because string value is null");
            }

            [TestMethod]
            public void ReturnsTrueForEmptyValue()
            {
                string.Empty.IsNullOrEmpty()
                    .Should()
                    .BeTrue("string value is empty string");
            }

            [TestMethod]
            public void ReturnsFalseForTextValue()
            {
                "test".IsNullOrEmpty()
                    .Should()
                    .BeFalse("string value is not null or empty");
            }
        }

        [TestClass]
        public class IsNullOrWhiteSpaceMethod
        {
            [TestMethod]
            public void ReturnsTrueForNullValue()
            {
                string test = null;
                test.IsNullOrWhiteSpace()
                    .Should()
                    .BeTrue("string value is null");
            }

            [TestMethod]
            public void ReturnsTrueForEmptyValue()
            {
                string.Empty.IsNullOrWhiteSpace()
                    .Should()
                    .BeTrue("string value is an empty string");
            }

            [TestMethod]
            public void ReturnsFalseForTextValue()
            {
                "test".IsNullOrWhiteSpace()
                    .Should()
                    .BeFalse("string value is not null, empty or whitespace");
            }

            [TestMethod]
            public void ReturnsTrueForWhiteSpace()
            {
                " ".IsNullOrWhiteSpace()
                    .Should()
                    .BeTrue("string value is whitespace");
            }
        }

        [TestClass]
        public class SafeEqualsMethod
        {
            [TestMethod]
            public void ReturnsTrueForEqualStrings()
            {
                "Test".SafeEquals("Test")
                    .Should()
                    .BeTrue("string values are the same");
            }

            [TestMethod]
            public void ReturnsFalseForNonEqualStrings()
            {
                "Test".SafeEquals("Not Test")
                    .Should()
                    .BeFalse("string values are different");
            }

            [TestMethod]
            public void ReturnsFalseIfUsingNullString()
            {
                string test = null;
                test.SafeEquals("test")
                    .Should()
                    .BeFalse("null comparison should be false and not throw an exception");
            }

            [TestMethod]
            public void DefaultsToCaseInsensitiveComparison()
            {
                "Test".SafeEquals("TEST")
                    .Should()
                    .BeTrue("string comparison is case-insensitive by default");
            }
        }

        [TestClass]
        public class SafeTrimMethod
        {
            [TestMethod]
            public void ReturnsNullForNull()
            {
                string test = null;
                test.SafeTrim()
                    .Should()
                    .BeNull("trimming a null string should return null instead of throwing an exception");
            }

            [TestMethod]
            public void ReturnsTrimmedString()
            {
                "  Test  ".SafeTrim()
                    .Should()
                    .Be("Test", "original Trim should still work");
            }
        }

        [TestClass]
        public class SafeSplitWithCharMethod
        {
            [TestMethod]
            public void ReturnsEmptyArrayForNull()
            {
                ((string)null)
                    .NullSafeSplit(',')
                    .Should()
                    .BeEmpty();
            }

            [TestMethod]
            public void ReturnsArrayFromString()
            {
                "1,2"
                    .NullSafeSplit(',')
                    .Should()
                    .Equal(new[] { "1", "2" });
            }
        }

        [TestClass]
        public class SafeSplitWithCharAndOptionsMethod
        {
            [TestMethod]
            public void ReturnsEmptyArrayForNull()
            {
                ((string)null)
                    .NullSafeSplit(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Should()
                    .BeEmpty();
            }

            [TestMethod]
            public void ReturnsArrayFromString()
            {
                "1,,2"
                    .NullSafeSplit(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Should()
                    .Equal(new[] { "1", "2" });
            }
        }

        [TestClass]
        public class SafeSplitWithStringAndOptionsMethod
        {
            [TestMethod]
            public void ReturnsEmptyArrayForNull()
            {
                ((string)null)
                  .NullSafeSplit(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                  .Should()
                  .BeEmpty();
            }

            [TestMethod]
            public void ReturnsArrayFromString()
            {
                "1,,2"
                    .NullSafeSplit(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries)
                    .Should()
                    .Equal(new[] { "1", "2" });
            }
        }

        [TestClass]
        public class EmptyToNullMethod
        {
            [TestMethod]
            public void ReturnsNullForNullValue()
            {
                ((string)null).EmptyToNull().Should().BeNull();
            }

            [TestMethod]
            public void ReturnsNullForEmptyStringValue()
            {
                "".EmptyToNull().Should().BeNull();
            }

            [TestMethod]
            public void ReturnsValueUnchangedIfNotNullOrEmpty()
            {
                "test".EmptyToNull().Should().Be("test");
            }
        }

        [TestClass]
        public class NullSafeToUpperMethod
        {
            [TestMethod]
            public void ReturnsNullForNullValue()
            {
                ((string)null).NullSafeToUpper().Should().BeNull();
            }

            [TestMethod]
            public void ReturnsValueWithToUppperAppliedIfValueNotNull()
            {
                "abc".NullSafeToUpper().Should().Be("ABC");
            }
        }

        [TestClass]
        public class NullSafeReplaceMethod
        {
            [TestMethod]
            public void ReturnsNullForNullValueWhenReplacingChar()
            {
                ((string)null).NullSafeReplace('a', 'b').Should().BeNull();
            }

            [TestMethod]
            public void ReturnsNullForNullValueWhenReplacingString()
            {
                ((string)null).NullSafeReplace("a", "b").Should().BeNull();
            }

            [TestMethod]
            public void ReturnsStringWithReplacedCharactersIfValueNotNull()
            {
                "aabbcc".NullSafeReplace('a', 'z').Should().Be("zzbbcc");
            }

            [TestMethod]
            public void ReturnsStringWithReplacedStringsIfValueNotNull()
            {
                "aabbcc".NullSafeReplace("aa", "zz").Should().Be("zzbbcc");
            }
        }
    }
}
