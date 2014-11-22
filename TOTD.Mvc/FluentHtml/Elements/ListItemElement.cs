using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using TOTD.Mvc.FluentHtml.Contracts;

namespace TOTD.Mvc.FluentHtml.Elements
{
    public class ListItemElement : BaseListItemElement<ListItemElement>
    {
        public ListItemElement(HtmlHelper htmlHelper)
            : base(htmlHelper)
        {
        }
    }
}