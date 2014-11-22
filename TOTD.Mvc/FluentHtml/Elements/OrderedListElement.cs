using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOTD.Mvc.FluentHtml.Html;

namespace TOTD.Mvc.FluentHtml.Elements
{
    public class OrderedListElement : BaseListElement<OrderedListElement>
    {
        public OrderedListElement(HtmlHelper htmlHelper)
            : base(HtmlTag.ListOrdered, htmlHelper)
        {
        }
    }
}