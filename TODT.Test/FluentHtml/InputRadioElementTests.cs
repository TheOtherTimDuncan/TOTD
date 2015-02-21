using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mvc.FluentHtml;
using TOTD.Mvc.FluentHtml.Elements;

namespace TOTD.Test.FluentHtml
{
    [TestClass]
    public class InputRadioElementTests : BaseFormElementTests
    {
        [TestMethod]
        public void SuccessfullySetsInputType()
        {
            new InputRadioElement(GetHtmlHelper())
                .ToHtmlString()
                .Should()
                .Be(@"<input type=""radio"" />");
        }

        [TestMethod]
        public void CanBeUsedAsBootstrap()
        {
            new InputRadioElement(GetHtmlHelper())
                .ForBootstrap()
                .ToHtmlString()
                .Should()
                .Contain("class=\"form-control\"");
        }
    }
}
