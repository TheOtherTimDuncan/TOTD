﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web.Mvc;
using TOTD.Mvc.FluentHtml.Html;

namespace TOTD.Mvc.FluentHtml.Elements
{
    public class InputTextElement : BaseInputElement<InputTextElement>
    {
        public InputTextElement(HtmlHelper htmlHelper)
            : base(HtmlInputType.Text, htmlHelper)
        {
        }
    }

    public class InputTextElement<TModel> : InputTextElement
    {
        public InputTextElement(HtmlHelper<TModel> htmlHelper)
            : base(htmlHelper)
        {
        }

        public InputTextElement For<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            SetAttributesFromModelProperty(expression);
            return this;
        }
    }
}