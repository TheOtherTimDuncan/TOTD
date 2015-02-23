using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TOTD.Mvc.FluentHtml.Elements;
using TOTD.Mvc.FluentHtml.Html;

namespace TOTD.Mvc.FluentHtml.Bootstrap
{
    public class BootstrapModalContainer : BaseContainerElement<BootstrapModalContainer>
    {
        public BootstrapModalContainer(HtmlHelper htmlHelper)
            : base(HtmlTag.Div, htmlHelper)
        {
            Class("modal fade");
            Attribute("tabindex", "-1");
        }

        public BootstrapModalDialog CreateDialog()
        {
            return CreateElement<BootstrapModalDialog>();
        }
    }
}
