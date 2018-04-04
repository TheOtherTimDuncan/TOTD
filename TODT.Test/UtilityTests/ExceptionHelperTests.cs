using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Utility.ExceptionHelpers;
using FluentAssertions;

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
                Action action = () =>
                {
                    string argument = "test";
                    ThrowIf.Argument.IsNull(argument, "argument");
                };
                action.Should().NotThrow("test argument is not null");
            }

            [TestMethod]
            public void IsNullThrowsExceptionForNullValue()
            {
                Action action = () =>
                {
                    string argument = null;
                    ThrowIf.Argument.IsNull(argument, "argument");
                };
                action
                    .Should().Throw<ArgumentNullException>()
                    .And
                    .ParamName
                        .Should()
                        .Be("argument");
            }

            [TestMethod]
            public void IsNullOrEmptyDoesNotThrowExceptionForNonNullAndNonEmptyValue()
            {
                Action action = () =>
                {
                    string argument = "test";
                    ThrowIf.Argument.IsNullOrEmpty(argument, "argument");
                };
                action.Should().NotThrow("argument has value");
            }

            [TestMethod]
            public void IsNullOrEmptyThrowsExceptionForNullValue()
            {
                Action action = () =>
                {
                    string argument = null;
                    ThrowIf.Argument.IsNullOrEmpty(argument, "argument");
                };
                action
                    .Should().Throw<ArgumentNullException>("argument value is null")
                    .And
                    .ParamName
                        .Should()
                        .Be("argument");
            }

            [TestMethod]
            public void IsNullOrEmptyThrowsExceptionForEmptyValue()
            {
                Action action = () =>
                {
                    string argument = "";
                    ThrowIf.Argument.IsNullOrEmpty(argument, "argument");
                };
                action
                    .Should().Throw<ArgumentNullException>("argument is empty string")
                    .And
                    .ParamName
                        .Should()
                        .Be("argument");
            }

            [TestMethod]
            public void IsLessThanDoesNotThrowExceptionIfArgumentExceedsValue()
            {
                Action action = () =>
                {
                    int argument = 1;
                    ThrowIf.Argument.IsLessThan(argument, "argument", 0);
                };
                action.Should().NotThrow("argument value is not less than limit");

            }

            [TestMethod]
            public void IsLessThanDoesNotThrowExceptionIfArgumentEqualsValue()
            {
                Action action = () =>
                {
                    int argument = 0;
                    ThrowIf.Argument.IsLessThan(argument, "argument", 0);
                };
                action.Should().NotThrow("argument value is not less than limit");
            }

            [TestMethod]
            public void IsLessThrowsExceptionIfArgumentIsLessThanValue()
            {
                Action action = () =>
                {
                    int argument = -1;
                    ThrowIf.Argument.IsLessThan(argument, "argument", 0);
                };
                action
                    .Should().Throw<ArgumentOutOfRangeException>("argument value is less than limit")
                    .And
                    .ParamName
                        .Should()
                        .Be("argument");
            }
        }
    }
}
