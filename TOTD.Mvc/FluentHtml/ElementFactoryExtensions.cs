using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TOTD.Mvc.FluentHtml.Elements;

namespace TOTD.Mvc.FluentHtml
{
    public static class ElementFactoryExtensions
    {
        public static FormElement Form(this ElementFactory elementFactory)
        {
            return elementFactory.CreateElement<FormElement>();
        }

        public static LabelElement Label(this ElementFactory elementFactory)
        {
            return elementFactory.CreateElement<LabelElement>();
        }

        public static LabelElement<T> Label<T>(this ElementFactory<T> elementFactory)
        {
            return elementFactory.CreateElement<LabelElement<T>>();
        }

        public static LinkElement Link(this ElementFactory elementFactory)
        {
            return elementFactory.CreateElement<LinkElement>();
        }

        public static ListItemElement ListItem(this ElementFactory elementFactory)
        {
            return elementFactory.CreateElement<ListItemElement>();
        }

        public static SpanElement Span(this ElementFactory elementFactory)
        {
            return elementFactory.CreateElement<SpanElement>();
        }

        public static ButtonElement Button(this ElementFactory elementFactory)
        {
            return elementFactory.CreateElement<ButtonElement>();
        }

        public static InputElement Input(this ElementFactory elementFactory)
        {
            return elementFactory.CreateElement<InputElement>();
        }

        public static InputElement<T> Input<T>(this ElementFactory<T> elementFactory)
        {
            return elementFactory.CreateElement<InputElement<T>>();
        }

        public static UnorderedListElement UnorderedList(this ElementFactory elementFactory)
        {
            return elementFactory.CreateElement<UnorderedListElement>();
        }
    }
}