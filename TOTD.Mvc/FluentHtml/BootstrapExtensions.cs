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

        public static BootstrapModalContainer BootstrapModalContainer(this ElementFactory elementFactory)
        {
            return elementFactory.CreateElement<BootstrapModalContainer>();
        }

        public static ButtonElement CanDismissBootstrapModal(this ButtonElement buttonElement)
        {
            return buttonElement.Data("dismiss", "modal");
        }

        public static ButtonElement AsBootstrapPrimary(this ButtonElement buttonElement)
        {
            return buttonElement.Class("btn btn-primary");
        }

        public static ButtonElement AsBootstrapDefault(this ButtonElement buttonElement)
        {
            return buttonElement.Class("btn btn-default");
        }

        public static ButtonElement AsBootstrapSuccess(this ButtonElement buttonElement)
        {
            return buttonElement.Class("btn btn-success");
        }

        public static ButtonElement AsBootstrapInfo(this ButtonElement buttonElement)
        {
            return buttonElement.Class("btn btn-info");
        }

        public static ButtonElement AsBootstrapWarning(this ButtonElement buttonElement)
        {
            return buttonElement.Class("btn btn-warning");
        }

        public static ButtonElement AsBootstrapDanger(this ButtonElement buttonElement)
        {
            return buttonElement.Class("btn btn-danger");
        }
    }
}