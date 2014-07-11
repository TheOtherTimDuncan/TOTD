using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
                Assert.IsNull(testClass.IfNotNull(x => x.TestProperty));
            }

            [TestMethod]
            public void ReturnsValueIfSourceIsNotNull()
            {
                TestClass testClass = new TestClass();
                testClass.TestProperty = "test";
                Assert.AreEqual(testClass.TestProperty, testClass.IfNotNull(x => x.TestProperty));
            }

            [TestMethod]
            public void ReturnsSpecifiedValueIfNull()
            {
                TestClass testClass = null;
                Assert.AreEqual("test", testClass.IfNotNull(x => x.TestProperty, "test"));
            }
        }
    }
}
