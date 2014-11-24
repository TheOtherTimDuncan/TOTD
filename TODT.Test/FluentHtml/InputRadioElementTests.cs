using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
