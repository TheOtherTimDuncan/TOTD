using System;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mvc.FluentHtml;
using TOTD.Mvc.FluentHtml.Elements;

namespace TOTD.Test.FluentHtml
{
    [TestClass]
    public class InputTextElementTests : BaseFormElementTests
    {
        [TestMethod]
        public void SuccessfullySetsInputType()
        {
            new InputTextElement(GetHtmlHelper())
                .ToHtmlString()
                .Should()
                .Be(@"<input type=""text"" />");
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
                .InputText()
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
        public void CanBeUsedAsBootstrap()
        {
            new InputTextElement(GetHtmlHelper())
                .ForBootstrap()
                .ToHtmlString()
                .Should()
                .Contain("class=\"form-control\"");
        }
    }
}
