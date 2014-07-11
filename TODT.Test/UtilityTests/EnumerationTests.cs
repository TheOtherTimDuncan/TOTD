using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Utility.Misc;

namespace TODT.Test.UtilityTests
{
    [TestClass]
    public class EnumerationTests
    {
        public class TestEnumeration : Enumeration<TestEnumeration>
        {
            public static readonly TestEnumeration Value1 = new TestEnumeration(0, "Value 1");
            public static readonly TestEnumeration Value2 = new TestEnumeration(0, "Value 2");

            private TestEnumeration()
            {
            }

            private TestEnumeration(int value, string displayName)
                : base(value, displayName)
            {
            }
        }

        [TestMethod]
        public void GetAllReturnsAllFields()
        {
            IEnumerable<TestEnumeration> all = TestEnumeration.GetAll();
            Assert.AreEqual(2, all.Count());
            Assert.IsTrue(all.Any(x => x.Value == TestEnumeration.Value1.Value && x.DisplayName == TestEnumeration.Value1.DisplayName));
            Assert.IsTrue(all.Any(x => x.Value == TestEnumeration.Value2.Value && x.DisplayName == TestEnumeration.Value2.DisplayName));
        }

        [TestMethod]
        public void ReturnsCorrectFieldFromValue()
        {
            TestEnumeration result = TestEnumeration.FromValue(0);
            Assert.AreEqual(0, result.Value);
        }

        [TestMethod]
        public void ReturnsCorrectFieldFromDisplayName()
        {
            TestEnumeration result = TestEnumeration.FromDisplayName("Value 1");
            Assert.AreEqual("Value 1", result.DisplayName);
        }
    }
}
