using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TOTD.Mvc.FluentHtml.Html;

namespace TOTD.Mvc.FluentHtml.Elements
{
    public class BaseListItemElement<T> : BaseContainerElement<T> where T : BaseListItemElement<T>
    {
        public BaseListItemElement(HtmlHelper htmlHelper)
            : base(HtmlTag.ListItem, htmlHelper)
        {
        }

        public T Text(string text)
        {
            AddInnerHtml(text);
            return (T)this;
        }
    }
}