using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
    }
}
