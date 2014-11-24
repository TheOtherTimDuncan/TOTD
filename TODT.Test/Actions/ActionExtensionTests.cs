using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TODT.Test.Fakes;
using TOTD.Mvc.Actions;

namespace TOTD.Test.Actions
{
    [TestClass]
    public class ActionExtensionTests : BaseHtmlTest
    {
        public UrlHelper GetUrlHelper()
        {
            RouteData routeData = new RouteData();
            routeData.Values["controller"] = "test";
            routeData.Values["action"] = "action";

            return new UrlHelper(new RequestContext(GetHttpContext(), routeData), GetRouteCollection());
        }

        [TestMethod]
        public void UrlHelperReturnsCorrectUrlForAction()
        {
            UrlHelper urlHelper = GetUrlHelper();
            string defaultUrl = urlHelper.Action("TestAction", "Test", new
            {
                actionID = 1
            });
            urlHelper.Action<TestController>(x => x.TestAction(1)).Should().Be(defaultUrl);
        }

        [TestMethod]
        public void UrlHelperReturnsCorrectUrlForAsyncAction()
        {
            UrlHelper urlHelper = GetUrlHelper();
            string defaultUrl = urlHelper.Action("TestActionAsync", "Test", new
            {
                actionID = 1
            });
            urlHelper.Action<TestController>(x => x.TestActionAsync(1)).Should().Be(defaultUrl);
        }
    }
}
