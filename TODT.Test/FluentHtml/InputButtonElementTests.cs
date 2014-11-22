using System;
using TOTD.Mvc.FluentHtml.Elements;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CH.Test.FluentHtml
{
    [TestClass]
    public class InputButtonElementTests : BaseFormElementTests
    {
        [TestMethod]
        public void SuccessfullySetsInputType()
        {
            new InputButtonElement(GetHtmlHelper())
                .ToHtmlString()
                .Should()
                .Be(@"<input type=""button"" />");
        }
    }
}
