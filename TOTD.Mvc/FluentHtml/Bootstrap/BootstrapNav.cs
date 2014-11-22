using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TOTD.Mvc.FluentHtml.Elements;
using TOTD.Mvc.FluentHtml.Html;

namespace TOTD.Mvc.FluentHtml.Bootstrap
{
    public class BootstrapNav : BaseListElement<BootstrapNav>
    {
        public BootstrapNav(HtmlHelper htmlHelper)
            : base(HtmlTag.ListUnordered, htmlHelper)
        {
        }

        public BootstrapNav AsNavBar()
        {
            return Class("nav").Class("navbar-nav");

        }

        public BootstrapNav AsDropdown()
        {
            return Class("dropdown-menu");
        }
    }
}