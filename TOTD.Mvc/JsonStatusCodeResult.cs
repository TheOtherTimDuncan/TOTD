using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace TOTD.Mvc
{
    internal static class JsonStatusCodeResultExtensions
    {
        public static JsonStatusCodeResult JsonStatusCode(this IController controller, HttpStatusCode statusCode, object data)
        {
            return controller.JsonStatusCode((int)statusCode, data);
        }

        public static JsonStatusCodeResult JsonStatusCode(this IController controller, int statusCode, object data)
        {
            return new JsonStatusCodeResult()
            {
                Data = data,
                StatusCode = statusCode
            };
        }
    }

    public class JsonStatusCodeResult : JsonResult
    {
        public int? StatusCode
        {
            get;
            set;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            base.ExecuteResult(context);

            if (StatusCode != null)
            {
                context.HttpContext.Response.StatusCode = StatusCode.Value;
            }
        }
    }
}
