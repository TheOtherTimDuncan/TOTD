using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TOTD.Mvc.FluentHtml.Contracts;

namespace TOTD.Mvc.FluentHtml.Conventions
{
    public class HtmlConventionBuilder
    {
        public HtmlConventionBuilder AddConvention<T>(Action<T> action) where T : IElement
        {
            IHtmlConvention convention = new HtmlConvention<T>(action);
            ElementFactory.AddConvention(convention);
            return this;
        }
    }
}