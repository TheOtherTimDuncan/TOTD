using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TOTD.Mvc.FluentHtml.Contracts;

namespace TOTD.Mvc.FluentHtml
{
    public class ElementFactory
    {
        private static List<IHtmlConvention> _conventions = new List<IHtmlConvention>();

        private HtmlHelper _htmlHelper;

        public ElementFactory(HtmlHelper htmlHelper)
        {
            this._htmlHelper = htmlHelper;
        }

        public virtual ElementType CreateElement<ElementType>(params object[] args) where ElementType : IElement
        {
            object[] combinedArgs = MergeElementConstructorArguments(args);
            ElementType result = (ElementType)Activator.CreateInstance(typeof(ElementType), combinedArgs);
            ApplyConventions(result);
            return result;
        }

        public static void AddConvention(IHtmlConvention convention)
        {
            _conventions.Add(convention);
        }

        protected void ApplyConventions(IElement element)
        {
            foreach (IHtmlConvention convention in _conventions)
            {
                convention.ApplyConvention(element);
            }
        }

        protected object[] MergeElementConstructorArguments(params object[] args)
        {
            if (args.Length == 0)
            {
                return new[] { _htmlHelper };
            }
            else
            {
                object[] combinedArgs = new object[args.Length + 1];
                combinedArgs[0] = _htmlHelper;
                args.CopyTo(combinedArgs, 1);
                return combinedArgs;
            }

        }
    }

    public class ElementFactory<ModelType> : ElementFactory
    {
        private HtmlHelper<ModelType> _htmlHelper;

        public ElementFactory(HtmlHelper<ModelType> htmlHelper)
            : base(htmlHelper)
        {
            this._htmlHelper = htmlHelper;
        }

        public override ElementType CreateElement<ElementType>(params object[] args)
        {
            object[] combinedArgs = MergeElementConstructorArguments(args);
            ElementType result = (ElementType)Activator.CreateInstance(typeof(ElementType), combinedArgs);
            ApplyConventions(result);
            return result;
        }
    }

    public static class ElementFactoryExtension
    {
        public static ElementFactory FluentHtml(this HtmlHelper htmlHelper)
        {
            return new ElementFactory(htmlHelper);
        }

        public static ElementFactory<T> FluentHtml<T>(this HtmlHelper<T> htmlHelper)
        {
            return new ElementFactory<T>(htmlHelper);
        }
    }
}