using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TOTD.Mvc.FluentHtml.Html;

namespace TOTD.Mvc.FluentHtml.Elements
{
    public class UnorderedListElement : BaseListElement<UnorderedListElement>
    {
        public UnorderedListElement(HtmlHelper htmlHelper)
            : base(HtmlTag.ListUnordered, htmlHelper)
        {
        }
    }
}