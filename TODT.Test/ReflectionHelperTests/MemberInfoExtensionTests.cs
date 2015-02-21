using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Utility.ReflectionHelpers;

namespace TODT.Test.ReflectionHelperTests
{
    [TestClass]
    public class MemberInfoExtensionTests
    {
        public class TestClass
        {
            [DataType(DataType.EmailAddress)]
            public string Email
            {
                get;
                set;
            }

            public string Value
            {
                get;
                set;
            }
        }

        [TestClass]
        public class GetAttributeMethod
        {
            [TestMethod]
            public void ThrowsExceptionIfMemberInfofNull()
            {
                MemberInfo test = null;
                Action action = () =>
                {
                    DataTypeAttribute attribute = test.GetAttribute<DataTypeAttribute>();
                };
                action.ShouldThrow<ArgumentNullException>().And.ParamName.Should().Be("member");
            }

            [TestMethod]
            public void ReturnsSpecifiedAttribute()
            {
                PropertyInfo property = typeof(TestClass).GetProperty("Email");
                property.Should().NotBeNull();

                DataTypeAttribute testAttribute = property.GetAttribute<DataTypeAttribute>();
                testAttribute.Should().NotBeNull();
                testAttribute.DataType.Should().Be(DataType.EmailAddress);
            }

            [TestMethod]
            public void ReturnsNullIfAttributeNotFound()
            {
                PropertyInfo property = typeof(TestClass).GetProperty("Value");
                property.Should().NotBeNull();

                DataTypeAttribute testAttribute = property.GetAttribute<DataTypeAttribute>();
                testAttribute.Should().BeNull();
            }
        }
    }
}
