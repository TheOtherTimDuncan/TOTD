using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TOTD.Mvc.FluentHtml.Elements;
using TOTD.Mvc.FluentHtml.Html;

namespace TOTD.Mvc.FluentHtml.Bootstrap
{
    public class BootstrapModalDialog : BaseContainerElement<BootstrapModalDialog>
    {
        public BootstrapModalDialog(HtmlHelper htmlHelper)
            : base(HtmlTag.Div, htmlHelper)
        {
            Class("modal-dialog");
        }

        public BootstrapModalContent CreateModalContent()
        {
            return CreateElement<BootstrapModalContent>();
        }
    }
}
