using System;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mvc.FluentHtml.Elements;

namespace TOTD.Test.FluentHtml
{
    [TestClass]
    public class SpanElementTests : BaseHtmlTest
    {
        [TestMethod]
        public void CreatesValidHtmlForElement()
        {
            new SpanElement(GetHtmlHelper())
                .ToHtmlString()
                .Should()
                .Be("<span></span>");
        }

        [TestMethod]
        public void CorrectlySetsInnerText()
        {
            new SpanElement(GetHtmlHelper())
                .Text("text")
                .ToHtmlString()
                .Should()
                .Be("<span>text</span>");
        }

        [TestMethod]
        public void HtmlEncodesInnerText()
        {
            new SpanElement(GetHtmlHelper())
                .Text(@"<br/>")
                .ToHtmlString()
                .Should()
                .Be("<span>&lt;br/&gt;</span>");
        }
    }
}
