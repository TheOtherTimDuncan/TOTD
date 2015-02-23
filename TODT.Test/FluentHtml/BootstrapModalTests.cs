using System;
using System.Collections.Generic;
using System.Linq;
using TOTD.Test;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mvc.FluentHtml.Bootstrap;
using System.Web.Mvc;
using System.IO;
using System.Text;

namespace TODT.Test.FluentHtml
{
    [TestClass]
    public class BootstrapModalTests : BaseHtmlTest
    {
        [TestMethod]
        public void CanCreateHtmlForBootstrapModal()
        {
            HtmlHelper htmlHelper = GetHtmlHelper();
            StringBuilder builder = new StringBuilder();
            htmlHelper.ViewContext.Writer = new StringWriter(builder);

            using (BootstrapModalContainer container = new BootstrapModalContainer(htmlHelper).Begin())
            {
                using (BootstrapModalDialog dialog = container.CreateDialog().Begin())
                {
                    using (BootstrapModalContent content = dialog.CreateModalContent().Begin())
                    {
                        using (BootstrapModalHeader header = content.CreateHeader().Begin())
                        {
                        }
                        using (BootstrapModalFooter footer = content.CreateFooter().Begin())
                        {
                        }
                    }
                }
            }

            string result = builder.ToString();
            result.Should().Be("<div class=\"modal fade\" tabindex=\"-1\"><div class=\"modal-dialog\"><div class=\"modal-content\"><div class=\"modal-header\"></div><div class=\"modal-footer\"></div></div></div></div>");
        }

        [TestMethod]
        public void BootstrapHeaderCreatesCloseButtonWithCorrectHtml()
        {
            new BootstrapModalHeader(GetHtmlHelper())
                .CreateCloseButton()
                .ToHtmlString()
                .Should()
                .StartWith("<button")
                .And
                .EndWith("</button>")
                .And
                .Contain("class=\"close\"")
                .And
                .Contain("data-dismiss=\"modal\"")
                .And
                .Contain("&times;");
        }

        [TestMethod]
        public void BootstrapHeaderCreatesTitleWithCorrectHtml()
        {
            new BootstrapModalHeader(GetHtmlHelper())
                .CreateTitle("title")
                .ToHtmlString()
                .Should()
                .StartWith("<h4")
                .And
                .EndWith("</h4>")
                .And
                .Contain("class=\"modal-title\"")
                .And
                .Contain("title");
        }
    }
}
