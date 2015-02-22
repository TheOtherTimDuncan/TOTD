using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using TOTD.Mvc.FluentHtml.Html;

namespace TOTD.Mvc.FluentHtml.Elements
{
    public class InputElement : BaseInputElement<InputElement>
    {
        public InputElement(HtmlHelper htmlHelper)
            : base(HtmlInputType.Text, htmlHelper)
        {
        }
    }

    public class InputElement<TModel> : InputElement
    {
        public InputElement(HtmlHelper<TModel> htmlHelper)
            : base(htmlHelper)
        {
        }

        public InputElement For<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            SetAttributesFromModelProperty(expression);
            return this;
        }
    }
}