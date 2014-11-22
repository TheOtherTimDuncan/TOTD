using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace TOTD.Mvc.FluentHtml.Elements
{
    public class BaseListElement<T> : BaseContainerElement<T> where T : BaseListElement<T>
    {
        public BaseListElement(string tag, HtmlHelper htmlHelper)
            : base(tag, htmlHelper)
        {
        }
    }
}