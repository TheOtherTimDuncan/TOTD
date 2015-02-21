using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mvc;

namespace TODT.Test.MvcTests
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

        [TestMethod]
        public void GetControllerActionsMissingValidateAntiForgeryTokenAttributeReturnsPostActionsWithoutAttribute()
        {
            IEnumerable<MethodInfo> actions = UnitTestHelper.GetControllerActionsMissingValidateAntiForgeryTokenAttribute<TestController>();
            actions.Any(x => x.Name == "Get").Should().BeFalse("HttpGet methods should be excluded");
            actions.Any(x => x.Name == "PostWithAntiForgeryToken").Should().BeFalse("action has correct attribute");
            actions.Any(x => x.Name == "PostWithoutAntiForgeryToken").Should().BeTrue("action is missing attribute");
        }

        private async void BadAsyncMethod()
        {
        }

        private async Task GoodAsyncMethod()
        {
        }
    }

    public class TestController : Controller
    {
        [HttpPost]
        public ActionResult PostWithoutAntiForgeryToken()
        {
            return null;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PostWithAntiForgeryToken()
        {
            return null;
        }

        [HttpGet]
        public ActionResult Get()
        {
            return null;
        }
    }
}
