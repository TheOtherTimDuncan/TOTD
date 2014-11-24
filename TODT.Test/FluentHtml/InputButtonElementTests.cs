using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mvc.FluentHtml.Elements;

namespace TOTD.Test.FluentHtml
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
