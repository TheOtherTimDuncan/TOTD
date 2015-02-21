using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using TOTD.Mvc.FluentHtml.Bootstrap;
using TOTD.Mvc.FluentHtml.Elements;

namespace TOTD.Mvc.FluentHtml
{
    public static class BootstrapExtensions
    {
        public static BootstrapNav BootstrapNav(this ElementFactory elementFactory)
        {
            return elementFactory.CreateElement<BootstrapNav>();
        }

        public static BootstrapNavItem BootstrapNavItem(this ElementFactory elementFactory)
        {
            return elementFactory.CreateElement<BootstrapNavItem>();
        }

        public static T ForBootstrap<T>(this BaseInputElement<T> formElement) where T : BaseInputElement<T>
        {
            return formElement.Class("form-control");
        }
    }
}