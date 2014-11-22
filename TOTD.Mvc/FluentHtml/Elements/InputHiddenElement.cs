﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;
using System.Web.Mvc;
using TOTD.Mvc.FluentHtml.Html;

namespace TOTD.Mvc.FluentHtml.Elements
{
    public class InputHiddenElement : BaseInputElement<InputHiddenElement>
    {
        public InputHiddenElement(HtmlHelper htmlHelper)
            : base(HtmlInputType.Hidden, htmlHelper)
        {
        }
    }

    public class InputHiddenElement<TModel> : InputHiddenElement
    {
        public InputHiddenElement(HtmlHelper<TModel> htmlHelper)
            : base(htmlHelper)
        {
        }

        public InputHiddenElement For<TProperty>(Expression<Func<TModel, TProperty>> expression)
        {
            SetAttributesFromModelProperty(expression);
            return this;
        }
    }
}