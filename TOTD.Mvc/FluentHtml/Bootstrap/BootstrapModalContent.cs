using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TOTD.Mvc.FluentHtml.Elements;
using TOTD.Mvc.FluentHtml.Html;

namespace TOTD.Mvc.FluentHtml.Bootstrap
{
    public class BootstrapModalContent : BaseContainerElement<BootstrapModalContent>
    {
        public BootstrapModalContent(HtmlHelper htmlHelper)
            : base(HtmlTag.Div, htmlHelper)
        {
            Class("modal-content");
        }

        public BootstrapModalHeader CreateHeader()
        {
            return CreateElement<BootstrapModalHeader>();
        }

        public BootstrapModalBody CreateBody()
        {
            return CreateElement<BootstrapModalBody>();
        }

        public BootstrapModalFooter CreateFooter()
        {
            return CreateElement<BootstrapModalFooter>();
        }
    }
}
