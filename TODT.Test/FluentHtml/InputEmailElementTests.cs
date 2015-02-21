using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mvc.FluentHtml;
using TOTD.Mvc.FluentHtml.Elements;
using TOTD.Test.FluentHtml;

namespace TODT.Test.FluentHtml
{
    [TestClass]
    public class InputEmailElementTests : BaseFormElementTests
    {
        [TestMethod]
        public void SuccessfullySetsInputType()
        {
            new InputEmailElement(GetHtmlHelper())
                .ToHtmlString()
                .Should()
                .Be(@"<input type=""email"" />");
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
                .InputEmail()
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
                .Contain("type=\"email\"")
                .And
                .Contain("value=\"StringValue\"");
        }

        [TestMethod]
        public void CanBeUsedAsBootstrap()
        {
            new InputEmailElement(GetHtmlHelper())
                .ForBootstrap()
                .ToHtmlString()
                .Should()
                .Contain("class=\"form-control\"");
        }
    }
}
