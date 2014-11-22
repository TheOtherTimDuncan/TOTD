using System;
using TOTD.Mvc.FluentHtml.Elements;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CH.Test.FluentHtml
{
    [TestClass]
    public class InputSubmitElementTests : BaseFormElementTests
    {
        [TestMethod]
        public void SuccessfullySetsInputType()
        {
            new InputSubmitElement(GetHtmlHelper())
                .ToHtmlString()
                .Should()
                .Be(@"<input type=""submit"" />");
        }
    }
}
