using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mvc.FluentHtml;
using TOTD.Mvc.FluentHtml.Elements;
using TOTD.Test;

namespace TODT.Test.FluentHtml
{
    [TestClass]
    public class ButtonElementTests : BaseHtmlTest
    {
        [TestMethod]
        public void CreatesValidHtmlForElement()
        {
            new ButtonElement(GetHtmlHelper())
                .ToHtmlString()
                .Should()
                .Be("<button type=\"button\"></button>");
        }

        [TestMethod]
        public void ForSubmitSetsButtonTypeToSubmit()
        {
            new ButtonElement(GetHtmlHelper())
                .ForSubmit()
                .ToHtmlString()
                .Should()
                .Be("<button type=\"submit\"></button>");
        }

        [TestMethod]
        public void ForResetSetsButtonTypeToReset()
        {
            new ButtonElement(GetHtmlHelper())
                .ForReset()
                .ToHtmlString()
                .Should()
                .Be("<button type=\"reset\"></button>");
        }

        [TestMethod]
        public void SetsInnerText()
        {
            new ButtonElement(GetHtmlHelper())
                .Text("test")
                .ToHtmlString()
                .Should()
                .Be("<button type=\"button\">test</button>");
        }

        [TestMethod]
        public void SetsCorrectClassesForBootstrapDefault()
        {
            new ButtonElement(GetHtmlHelper())
                .AsBootstrapDefault()
                .ToHtmlString()
                .Should()
                .Contain("class=\"btn btn-default\"");
        }

        [TestMethod]
        public void SetsCorrectClassesForBootstrapPrimary()
        {
            new ButtonElement(GetHtmlHelper())
                .AsBootstrapPrimary()
                .ToHtmlString()
                .Should()
                .Contain("class=\"btn btn-primary\"");
        }

        [TestMethod]
        public void SetsCorrectClassesForBootstrapSuccess()
        {
            new ButtonElement(GetHtmlHelper())
                .AsBootstrapSuccess()
                .ToHtmlString()
                .Should()
                .Contain("class=\"btn btn-success\"");
        }

        [TestMethod]
        public void SetsCorrectClassesForBootstrapInfo()
        {
            new ButtonElement(GetHtmlHelper())
                .AsBootstrapInfo()
                .ToHtmlString()
                .Should()
                .Contain("class=\"btn btn-info\"");
        }

        [TestMethod]
        public void SetsCorrectClassesForBootstrapWarning()
        {
            new ButtonElement(GetHtmlHelper())
                .AsBootstrapWarning()
                .ToHtmlString()
                .Should()
                .Contain("class=\"btn btn-warning\"");
        }

        [TestMethod]
        public void SetsCorrectClassesForBootstrapDanger()
        {
            new ButtonElement(GetHtmlHelper())
                .AsBootstrapDanger()
                .ToHtmlString()
                .Should()
                .Contain("class=\"btn btn-danger\"");
        }
    }
}
