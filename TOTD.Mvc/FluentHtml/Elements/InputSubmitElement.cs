﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOTD.Mvc.FluentHtml.Html;

namespace TOTD.Mvc.FluentHtml.Elements
{
    public class InputSubmitElement : BaseInputElement<InputSubmitElement>
    {
        public InputSubmitElement(HtmlHelper htmlHelper)
            : base(HtmlInputType.Submit, htmlHelper)
        {
        }
    }
}