using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TODT.Test.Fakes;
using TOTD.Mvc;
using TOTD.Mvc.Actions;

namespace TOTD.Test
{
    [TestClass]
    public class ActionHelperTests
    {
        [TestMethod]
        public void DoesNotOverrideAreaIfAlreadyExists()
        {
            RouteValueDictionary routeValues = new RouteValueDictionary();
            routeValues.Add(RouteValueKeys.Area, "NoArea");

            ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestControllerWithArea>(x => x.TestAction(1), routeValues);

            helperResult.RouteValues[RouteValueKeys.Area].Should().Be("NoArea");
        }

        [TestMethod]
        public void GetsAreaFromAttributeOnController()
        {
            ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestControllerWithArea>(x => x.TestAction(1));
            helperResult.RouteValues[RouteValueKeys.Area].Should().Be("TestArea");
        }

        [TestMethod]
        public void SetsAreaToEmptyStringByDefault()
        {
            ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestController>(x => x.OtherAction());
            helperResult.RouteValues[RouteValueKeys.Area].Should().Be("");
        }

        [TestMethod]
        public void CanGetControllerNameWithoutControllerSuffixFromActionClass()
        {
            ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestController>(x => x.TestAction(1));
            helperResult.ControllerName.Should().Be("Test");
        }

        [TestMethod]
        public void CanGetActionNameFromMethod()
        {
            ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestController>(x => x.TestAction(1));
            helperResult.ActionName.Should().Be("TestAction");
        }

        [TestMethod]
        public void CanGetActionNameFromAsyncMethod()
        {
            ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestController>(x => x.TestActionAsync(1));
            helperResult.ActionName.Should().Be("TestActionAsync");
        }

        [TestMethod]
        public void AddsMethodParameterToRouteValues()
        {
            ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestController>(x => x.TestAction(1));
            helperResult.RouteValues.Should().ContainKey("actionID");
            helperResult.RouteValues["actionID"].Should().Be(1);
        }

        [TestMethod]
        public void AddsMultipleMethodParametersToRouteValues()
        {
            ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestController>(x => x.TestAction2(1, "test"));

            helperResult.RouteValues.Should().ContainKey("actionID");
            helperResult.RouteValues.Should().ContainKey("value");

            helperResult.RouteValues["actionID"].Should().Be(1);
            helperResult.RouteValues["value"].Should().Be("test");
        }

        [TestMethod]
        public void CanHandleModelClassAsParameter()
        {
            TestModel model = new TestModel()
            {
                TestValue = "test"
            };

            ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestController>(x => x.ModelAction(model));

            helperResult.RouteValues.Should().ContainKey("TestValue");
            helperResult.RouteValues["TestValue"].Should().Be(model.TestValue);
        }

        [TestMethod]
        public void CanHandleModelClassAsParameterWhenModelIsNull()
        {
            ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestController>(x => x.ModelAction(null));

            // Only route value value should be area
            helperResult.RouteValues.Should().HaveCount(1);
            helperResult.RouteValues[RouteValueKeys.Area].Should().Be(string.Empty);
        }

        [TestMethod]
        public void GetControllerRouteNameStripsControllerFromControllerName()
        {
            ActionHelper.GetControllerRouteName("TestController").Should().Be("Test");
        }

        [TestMethod]
        public void GetControllerRouteNameReturnsOriginalNameIfItDoesNotEndWithController()
        {
            ActionHelper.GetControllerRouteName("Test").Should().Be("Test");
        }

        //[TestMethod]
        public void TestTiming()
        {
            Stopwatch watch = Stopwatch.StartNew();
            int max = 1000000;
            for (var i = 1; i <= max; i++)
            {
                ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestController>(x => x.TestAction(1));
            }
            watch.Stop();
            Console.WriteLine("Total time: {0}; Average time: {1}", watch.ElapsedMilliseconds, (double)watch.ElapsedMilliseconds / max);
        }
    }
}
