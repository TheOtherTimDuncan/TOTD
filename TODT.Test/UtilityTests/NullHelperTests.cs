using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Utility.Misc;

namespace TODT.Test.UtilityTests
{
    [TestClass]
    public class NullHelperTests
    {
        public class TestClass
        {
            public string TestProperty
            {
                get;
                set;
            }
        }

        [TestClass]
        public class IfNotNullMethod : NullHelperTests
        {
            [TestMethod]
            public void ReturnsNullIfSourceIsNull()
            {
                TestClass testClass = null;
                testClass.IfNotNull(x => x.TestProperty)
                    .Should()
                    .BeNull("source class is null and referencing property should not throw an exception");
            }

            [TestMethod]
            public void ReturnsValueIfSourceIsNotNull()
            {
                TestClass testClass = new TestClass();
                testClass.TestProperty = "test";
                testClass.IfNotNull(x => x.TestProperty)
                    .Should()
                    .Be(testClass.TestProperty, "source class is not null");
            }

            [TestMethod]
            public void ReturnsSpecifiedValueIfNull()
            {
                TestClass testClass = null;
                testClass.IfNotNull(x => x.TestProperty, "test")
                    .Should()
                    .Be("test", "source class is null and a default value is specified");
            }
        }
    }
}
