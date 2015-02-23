using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mvc.FluentHtml.Elements;
using TOTD.Test;

namespace TODT.Test.FluentHtml
{
    [TestClass]
    public class HeadingElementTests : BaseHtmlTest
    {
        [TestMethod]
        public void CreatesValidHtmlForElement()
        {
            new HeadingElement(GetHtmlHelper(),1)
                .ToHtmlString()
                .Should()
                .Be("<h1></h1>");
        }

        [TestMethod]
        public void SetsInnerText()
        {
            new HeadingElement(GetHtmlHelper(),1)
                .Text("test")
                .ToHtmlString()
                .Should()
                .Be("<h1>test</h1>");
        }
    }
}
