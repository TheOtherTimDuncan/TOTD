using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mvc.FluentHtml.Elements;

namespace TOTD.Test.FluentHtml
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
