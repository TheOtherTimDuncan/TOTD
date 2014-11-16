using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
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
            TestEnumeration.GetAll()
                .Should()
                .Equal(new TestEnumeration[] { TestEnumeration.Value1, TestEnumeration.Value2 });
        }

        [TestMethod]
        public void ReturnsCorrectFieldFromValue()
        {
            TestEnumeration.FromValue(0).Value
                .Should()
                .Be(0, "FromValue should return TestEnumeration.Value1");
        }

        [TestMethod]
        public void ReturnsCorrectFieldFromDisplayName()
        {
            TestEnumeration.FromDisplayName("Value 1").DisplayName
                .Should().Be("Value 1", "FromDisplayName should return TestEnumeration.Value1");
        }
    }
}
