using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOTD.Mvc.FluentHtml.Html;

namespace TOTD.Mvc.FluentHtml.Elements
{
    public class ButtonElement : BaseContainerElement<ButtonElement>
    {
        public ButtonElement(HtmlHelper htmlHelper)
            : base(HtmlTag.Button, htmlHelper)
        {
            Attribute("type", "button");
        }

        public ButtonElement ForSubmit()
        {
            Attribute("type", "submit");
            return this;
        }

        public ButtonElement ForReset()
        {
            Attribute("type", "reset");
            return this;
        }

        public ButtonElement Text(string text)
        {
            AddInnerHtml(text);
            return this;
        }

        public ButtonElement InnerHtml(IHtmlString htmlString)
        {
            AddInnerHtml(htmlString);
            return this;
        }
    }
}
