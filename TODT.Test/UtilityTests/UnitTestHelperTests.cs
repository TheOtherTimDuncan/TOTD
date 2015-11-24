using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Utility.Misc;

namespace TODT.Test.UtilityTests
{
    [TestClass]
    public class UnitTestHelperTests
    {
        [TestMethod]
        public void GetAsyncVoidMethodsReturnsAsyncVoidMethods()
        {
            IEnumerable<MethodInfo> methods = UnitTestHelper.GetAsyncVoidMethods(GetType().Assembly);
            methods.Any(x => x.Name == "BadAsyncMethod").Should().BeTrue();
            methods.Any(x => x.Name == "GoodAsyncMethod").Should().BeFalse();
        }

#pragma warning disable CS1998 // Needed for unit test
        private async void BadAsyncMethod()
#pragma warning restore CS1998 
        {
        }

#pragma warning disable CS1998 // Needed for unit test
        private async Task GoodAsyncMethod()
#pragma warning restore CS1998 
        {
        }
    }
}
