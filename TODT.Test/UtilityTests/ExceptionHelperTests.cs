using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Utility.ExceptionHelpers;

namespace TODT.Test.UtilityTests
{
    [TestClass]
    public class ExceptionHelperTests
    {
        [TestClass]
        public class ThrowIfTests
        {
            [TestMethod]
            public void IsNullDoesNotThrowExceptionForNonNullValue()
            {
                string argument = "test";
                ThrowIf.Argument.IsNull(argument, "argument");
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void IsNullThrowsExceptionForNullValue()
            {
                string argument = null;
                ThrowIf.Argument.IsNull(argument, "argument");
            }

            [TestMethod]
            public void IsNullOrEmptyDoesNotThrowExceptionForNonNullAndNonEmptyValue()
            {
                string argument = "test";
                ThrowIf.Argument.IsNullOrEmpty(argument, "argument");
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void IsNullOrEmptyThrowsExceptionForNullValue()
            {
                string argument = null;
                ThrowIf.Argument.IsNullOrEmpty(argument, "argument");
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentNullException))]
            public void IsNullOrEmptyThrowsExceptionForEmptyValue()
            {
                string argument = "";
                ThrowIf.Argument.IsNullOrEmpty(argument, "argument");
            }

            [TestMethod]
            public void IsLessThanDoesNotThrowExceptionIfArgumentExceedsValue()
            {
                int argument = 1;
                ThrowIf.Argument.IsLessThan(argument, "argument", 0);
            }

            [TestMethod]
            public void IsLessThanDoesNotThrowExceptionIfArgumentEqualsValue()
            {
                int argument = 0;
                ThrowIf.Argument.IsLessThan(argument, "argument", 0);
            }

            [TestMethod]
            [ExpectedException(typeof(ArgumentOutOfRangeException))]
            public void IsLessThrowsExceptionIfArgumentIsLessThanValue()
            {
                int argument = -1;
                ThrowIf.Argument.IsLessThan(argument, "argument", 0);
            }
        }
    }
}
