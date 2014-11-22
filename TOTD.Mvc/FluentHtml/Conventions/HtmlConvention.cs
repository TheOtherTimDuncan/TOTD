using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOTD.Mvc.FluentHtml.Contracts;

namespace TOTD.Mvc.FluentHtml.Conventions
{
    public class HtmlConvention<T> : IHtmlConvention where T : IElement
    {
        private Action<T> _action;

        public HtmlConvention(Action<T> action)
        {
            this._action = action;
        }

        public void ApplyConvention(IElement element)
        {
            if (element is T)
            {
                _action((T)element);
            }
        }
    }
}