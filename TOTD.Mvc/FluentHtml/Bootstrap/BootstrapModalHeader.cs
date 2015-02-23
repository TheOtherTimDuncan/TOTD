using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TOTD.Mvc.FluentHtml.Elements;
using TOTD.Mvc.FluentHtml.Html;

namespace TOTD.Mvc.FluentHtml.Bootstrap
{
    public class BootstrapModalHeader : BaseContainerElement<BootstrapModalHeader>
    {
        public BootstrapModalHeader(HtmlHelper htmlHelper)
            : base(HtmlTag.Div, htmlHelper)
        {
            Class("modal-header");
        }

        public ButtonElement CreateCloseButton()
        {
            return CreateElement<ButtonElement>()
                .CanDismissBootstrapModal()
                .Class("close")
                .InnerHtml(HtmlEntities.X);
        }

        public HeadingElement CreateTitle(string title)
        {
            return CreateElement<HeadingElement>(4)
                .Class("modal-title")
                .Text(title);
        }
    }
}
