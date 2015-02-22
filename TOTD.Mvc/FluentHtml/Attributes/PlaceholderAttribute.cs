using System;

namespace TOTD.Mvc.FluentHtml.Attributes
{
    public class PlaceholderAttribute : Attribute
    {
        public PlaceholderAttribute(string placeholder)
        {
            this.Placeholder = placeholder;
        }

        public string Placeholder
        {
            get;
            set;
        }
    }
}
