using System;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mvc.FluentHtml;
using TOTD.Mvc.FluentHtml.Elements;
using TOTD.Mvc.FluentHtml.Html;

namespace TOTD.Test.FluentHtml
{
    [TestClass]
    public class InputElementTests : BaseFormElementTests
    {
        [TestMethod]
        public void DefaultsToTextInputType()
        {
            new InputElement(GetHtmlHelper())
                .ToHtmlString()
                .Should()
                .Be(@"<input type=""text"" />");
        }

        [TestMethod]
        public void SetsInputTypeFromStringParameter()
        {
            new InputElement(GetHtmlHelper())
                .For(HtmlInputType.Number)
                .ToHtmlString()
                .Should()
                .Be(@"<input type=""number"" />");
        }

        [TestMethod]
        public void SetsInputTypeToNumberForNonDecoratedIntegerProperty()
        {
            TestModel model = new TestModel
            {
                StringProperty = "StringValue"
            };

            ViewDataDictionary<TestModel> viewData = GetViewData(model);
            HtmlHelper<TestModel> htmlHelper = GetHtmlHelper(viewData);
            htmlHelper
                .FluentHtml()
                .Input()
                .For(x => x.IntegerProperty)
                .ToHtmlString()
                .Should()
                .StartWith("<input")
                .And
                .EndWith("/>")
                .And
                .Contain("type=\"number\"");
        }

        [TestMethod]
        public void SetsInputTypeToEmailForPropertyDecoratedAsDataTypeEmail()
        {
            TestModel model = new TestModel();

            ViewDataDictionary<TestModel> viewData = GetViewData(model);
            HtmlHelper<TestModel> htmlHelper = GetHtmlHelper(viewData);
            htmlHelper
                .FluentHtml()
                .Input()
                .For(x => x.Email)
                .ToHtmlString()
                .Should()
                .StartWith("<input")
                .And
                .EndWith("/>")
                .And
                .Contain("type=\"email\"");
        }

        [TestMethod]
        public void SetsInputTypeToTelForPropertyDecoratedAsDataTypePhoneNumber()
        {
            TestModel model = new TestModel();

            ViewDataDictionary<TestModel> viewData = GetViewData(model);
            HtmlHelper<TestModel> htmlHelper = GetHtmlHelper(viewData);
            htmlHelper
                .FluentHtml()
                .Input()
                .For(x => x.PhoneNumber)
                .ToHtmlString()
                .Should()
                .StartWith("<input")
                .And
                .EndWith("/>")
                .And
                .Contain("type=\"tel\"");
        }

        [TestMethod]
        public void SetsInputTypeToPasswordForPropertyDecoratedAsDataTypePassword()
        {
            TestModel model = new TestModel();

            ViewDataDictionary<TestModel> viewData = GetViewData(model);
            HtmlHelper<TestModel> htmlHelper = GetHtmlHelper(viewData);
            htmlHelper
                .FluentHtml()
                .Input()
                .For(x => x.Password)
                .ToHtmlString()
                .Should()
                .StartWith("<input")
                .And
                .EndWith("/>")
                .And
                .Contain("type=\"password\"");
        }

        [TestMethod]
        public void SetsInputTypeToDateForPropertyDecoratedAsDataTypeDate()
        {
            TestModel model = new TestModel();

            ViewDataDictionary<TestModel> viewData = GetViewData(model);
            HtmlHelper<TestModel> htmlHelper = GetHtmlHelper(viewData);
            htmlHelper
                .FluentHtml()
                .Input()
                .For(x => x.DateValue)
                .ToHtmlString()
                .Should()
                .StartWith("<input")
                .And
                .EndWith("/>")
                .And
                .Contain("type=\"date\"");
        }

        [TestMethod]
        public void SetsInputTypeToDateTimeForPropertyDecoratedAsDataTypeDateTime()
        {
            TestModel model = new TestModel();

            ViewDataDictionary<TestModel> viewData = GetViewData(model);
            HtmlHelper<TestModel> htmlHelper = GetHtmlHelper(viewData);
            htmlHelper
                .FluentHtml()
                .Input()
                .For(x => x.DateTimeValue)
                .ToHtmlString()
                .Should()
                .StartWith("<input")
                .And
                .EndWith("/>")
                .And
                .Contain("type=\"datetime\"");
        }

        [TestMethod]
        public void SetsInputTypeToTimeForPropertyDecoratedAsDataTypeTime()
        {
            TestModel model = new TestModel();

            ViewDataDictionary<TestModel> viewData = GetViewData(model);
            HtmlHelper<TestModel> htmlHelper = GetHtmlHelper(viewData);
            htmlHelper
                .FluentHtml()
                .Input()
                .For(x => x.TimeValue)
                .ToHtmlString()
                .Should()
                .StartWith("<input")
                .And
                .EndWith("/>")
                .And
                .Contain("type=\"time\"");
        }

        [TestMethod]
        public void SetsInputTypeToUrlForPropertyDecoratedAsDataTypeUrl()
        {
            TestModel model = new TestModel();

            ViewDataDictionary<TestModel> viewData = GetViewData(model);
            HtmlHelper<TestModel> htmlHelper = GetHtmlHelper(viewData);
            htmlHelper
                .FluentHtml()
                .Input()
                .For(x => x.Url)
                .ToHtmlString()
                .Should()
                .StartWith("<input")
                .And
                .EndWith("/>")
                .And
                .Contain("type=\"url\"");
        }

        [TestMethod]
        public void SetsElementIDNameAndValueFromModelExpression()
        {
            TestModel model = new TestModel
            {
                StringProperty = "StringValue"
            };

            ViewDataDictionary<TestModel> viewData = GetViewData(model);
            HtmlHelper<TestModel> htmlHelper = GetHtmlHelper(viewData);
            htmlHelper
                .FluentHtml()
                .Input()
                .For(x => x.StringProperty)
                .ToHtmlString()
                .Should()
                .StartWith("<input")
                .And
                .EndWith("/>")
                .And
                .Contain("id=\"StringProperty\"")
                .And
                .Contain("name=\"StringProperty\"")
                .And
                .Contain("type=\"text\"")
                .And
                .Contain("value=\"StringValue\"");
        }

        [TestMethod]
        public void SetsPlaceholderValueFromPlaceholderAttribute()
        {
            TestModel model = new TestModel();

            ViewDataDictionary<TestModel> viewData = GetViewData(model);
            HtmlHelper<TestModel> htmlHelper = GetHtmlHelper(viewData);
            htmlHelper
                .FluentHtml()
                .Input()
                .For(x => x.StringProperty)
                .ToHtmlString()
                .Should()
                .StartWith("<input")
                .And
                .EndWith("/>")
                .And
                .Contain("placeholder=\"Placeholder\"");
        }

        [TestMethod]
        public void CanBeUsedAsBootstrap()
        {
            new InputElement(GetHtmlHelper())
                .ForBootstrap()
                .ToHtmlString()
                .Should()
                .Contain("class=\"form-control\"");
        }
    }
}
