using System;
using System.Collections.Generic;
using System.Linq;
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
                Assert.IsTrue(test.IsNullOrEmpty());
            }

            [TestMethod]
            public void ReturnsTrueForEmptyValue()
            {
                Assert.IsTrue(string.Empty.IsNullOrEmpty());
            }

            [TestMethod]
            public void ReturnsFalseForTextValue()
            {
                Assert.IsFalse("test".IsNullOrEmpty());
            }
        }

        [TestClass]
        public class IsNullOrWhiteSpaceMethod
        {
            [TestMethod]
            public void ReturnsTrueForNullValue()
            {
                string test = null;
                Assert.IsTrue(test.IsNullOrWhiteSpace());
            }

            [TestMethod]
            public void ReturnsTrueForEmptyValue()
            {
                Assert.IsTrue(string.Empty.IsNullOrWhiteSpace());
            }

            [TestMethod]
            public void ReturnsFalseForTextValue()
            {
                Assert.IsFalse("test".IsNullOrWhiteSpace());
            }

            [TestMethod]
            public void ReturnsTrueForWhiteSpace()
            {
                Assert.IsTrue(" ".IsNullOrWhiteSpace());
            }
        }

        [TestClass]
        public class SafeEqualsMethod
        {
            [TestMethod]
            public void ReturnsTrueForEqualStrings()
            {
                Assert.IsTrue("Test".SafeEquals("Test"));
            }

            [TestMethod]
            public void ReturnsFalseForNonEqualStrings()
            {
                Assert.IsFalse("Test".SafeEquals("Not Test"));
            }

            [TestMethod]
            public void ReturnsFalseIfUsingNullString()
            {
                string test = null;
                Assert.IsFalse(test.SafeEquals("Test"));
            }

            [TestMethod]
            public void DefaultsToCaseInsensitiveComparison()
            {
                Assert.IsTrue("Test".SafeEquals("TEST"));
            }
        }

        [TestClass]
        public class SafeTrimMethod
        {
            [TestMethod]
            public void ReturnsNullForNull()
            {
                string test = null;
                Assert.IsNull(test.SafeTrim());
            }

            [TestMethod]
            public void ReturnsTrimmedString()
            {
                Assert.AreEqual("Test", "  Test  ".SafeTrim());
            }
        }
    }
}
