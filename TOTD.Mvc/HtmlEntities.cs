using System;
using System.Web;
using System.Web.Mvc;

namespace TOTD.Mvc
{
    public static class HtmlEntities
    {
        private static HtmlString _ellipsis = new HtmlString("&hellip;");
        private static HtmlString _greaterThan = new HtmlString("&gt;");
        private static HtmlString _lessThan = new HtmlString("&lt;");
        private static HtmlString _nonBreakingSpace = new HtmlString("&nbsp;");
        private static HtmlString _ampersand = new HtmlString("&amp;");
        private static HtmlString _quote = new HtmlString("&quot;");
        private static HtmlString _x = new HtmlString("<span aria-hidden=\"true\">&times;</span>");

        public static HtmlString Ellipsis(HtmlHelper htmlHelper)
        {
            return _ellipsis;
        }

        public static HtmlString GreaterThan(HtmlHelper htmlHelper)
        {
            return _greaterThan;
        }

        public static HtmlString LessThan(HtmlHelper htmlHelper)
        {
            return _lessThan;
        }

        public static HtmlString NonBreakingSpace(HtmlHelper htmlHelper)
        {
            return _nonBreakingSpace;
        }

        public static HtmlString Ampersand(HtmlHelper htmlHelper)
        {
            return _ampersand;
        }

        public static HtmlString Quote(HtmlHelper htmlHelper)
        {
            return _quote;
        }

        public static HtmlString X(HtmlHelper htmlHelper)
        {
            return _x;
        }
    }
}
