using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TOTD.Mvc.FluentHtml.Elements
{
    public class HeadingElement : BaseContainerElement<HeadingElement>
    {
        public HeadingElement(HtmlHelper htmlHelper, int level)
            : base("h" + level.ToString(), htmlHelper)
        {
        }

        public HeadingElement Text(string text)
        {
            AddInnerHtml(text);
            return this;
        }

        public HeadingElement InnerHtml(IHtmlString htmlString)
        {
            AddInnerHtml(htmlString);
            return this;
        }
    }
}
