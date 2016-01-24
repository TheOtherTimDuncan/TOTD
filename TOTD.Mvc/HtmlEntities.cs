using System;
using System.Web;

namespace TOTD.Mvc
{
    public class HtmlEntities
    {
        private static HtmlString _ellipsis;
        private static HtmlString _greaterThan;
        private static HtmlString _lessThan;
        private static HtmlString _nonBreakingSpace;
        private static HtmlString _ampersand;
        private static HtmlString _quote;
        private static HtmlString _x;

        public static HtmlString Ellipsis
        {
            get
            {
                if (_ellipsis == null)
                {
                    _ellipsis = new HtmlString("&hellip;");
                }
                return _ellipsis;
            }
        }

        public static HtmlString GreaterThan
        {
            get
            {
                if (_greaterThan == null)
                {
                    _greaterThan = new HtmlString("&gt;");
                }
                return _greaterThan;
            }
        }

        public static HtmlString LessThan
        {
            get
            {
                if (_lessThan == null)
                {
                    _lessThan = new HtmlString("&lt;");
                }
                return _lessThan;
            }
        }

        public static HtmlString NonBreakingSpace
        {
            get
            {
                if (_nonBreakingSpace == null)
                {
                    _nonBreakingSpace = new HtmlString("&nbsp;");
                }
                return _nonBreakingSpace;
            }
        }

        public static HtmlString Ampersand
        {
            get
            {
                if (_ampersand == null)
                {
                    _ampersand = new HtmlString("&amp;");
                }
                return _ampersand;
            }
        }

        public static HtmlString Quote
        {
            get
            {
                if (_quote == null)
                {
                    _quote = new HtmlString("&quot;");
                }
                return _quote;
            }
        }

        public static HtmlString X
        {
            get
            {
                if (_x == null)
                {
                    _x = new HtmlString("<span aria-hidden=\"true\">&times;</span>");
                }
                return _x;
            }
        }
    }
}
