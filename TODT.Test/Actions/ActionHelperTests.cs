using System;
using System.Diagnostics;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TODT.Test.Fakes;
using TOTD.Mvc.Actions;
using TOTD.Mvc.FluentHtml;

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

            Assert.AreEqual("NoArea", helperResult.RouteValues[RouteValueKeys.Area]);
        }

        [TestMethod]
        public void GetsAreaFromAttributeOnController()
        {
            ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestControllerWithArea>(x => x.TestAction(1));
            Assert.AreEqual("TestArea", helperResult.RouteValues[RouteValueKeys.Area]);
        }

        [TestMethod]
        public void SetsAreaToEmptyStringByDefault()
        {
            ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestController>(x => x.OtherAction());
            Assert.AreEqual("", helperResult.RouteValues[RouteValueKeys.Area]);
        }

        [TestMethod]
        public void CanGetControllerNameWithoutControllerSuffixFromActionClass()
        {
            ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestController>(x => x.TestAction(1));
            Assert.AreEqual("Test", helperResult.ControllerName);
        }

        [TestMethod]
        public void CanGetActionNameFromMethod()
        {
            ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestController>(x => x.TestAction(1));
            Assert.AreEqual("TestAction", helperResult.ActionName);
        }

        [TestMethod]
        public void CanGetActionNameFromAsyncMethod()
        {
            ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestController>(x => x.TestActionAsync(1));
            Assert.AreEqual("TestActionAsync", helperResult.ActionName);
        }

        [TestMethod]
        public void AddsMethodParametersToRouteValues()
        {
            ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestController>(x => x.TestAction(1));
            Assert.IsTrue(helperResult.RouteValues.ContainsKey("actionID"));
            object value = helperResult.RouteValues["actionID"];
            Assert.AreEqual(1, value);
        }

        [TestMethod]
        public void CanHandleModelClassAsParameter()
        {
            TestModel model = new TestModel()
            {
                TestValue = "test"
            };

            ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestController>(x => x.ModelAction(model));

            Assert.IsTrue(helperResult.RouteValues.ContainsKey("TestValue"));
            object value1 = helperResult.RouteValues["TestValue"];
            Assert.AreEqual(model.TestValue, value1);
        }

        [TestMethod]
        public void CanHandleModelClassAsParameterWhenModelIsNull()
        {
            ActionHelperResult helperResult = ActionHelper.GetRouteValues<TestController>(x => x.ModelAction(null));

            // Only route value value should be area
            helperResult.RouteValues.Should().HaveCount(1);
            helperResult.RouteValues[RouteValueKeys.Area].Should().Be(string.Empty);
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
