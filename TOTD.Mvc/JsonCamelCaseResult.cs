using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using TOTD.Utility.StringHelpers;

namespace TOTD.Mvc
{
    public static class JsonCamelCaseResultExtensions
    {
        public static JsonCamelCaseResult JsonCamelCase(this IController controller, object data, HttpStatusCode statusCode, string contentType = null, Encoding contentEncoding = null)
        {
            return controller.JsonCamelCase(data, (int)statusCode, contentType, contentEncoding);
        }

        public static JsonCamelCaseResult JsonCamelCase(this IController controller, object data, int? statusCode = null, string contentType = null, Encoding contentEncoding = null)
        {
            return new JsonCamelCaseResult()
            {
                Data = data,
                StatusCode = statusCode
            };
        }
    }

    public class JsonCamelCaseResult : ActionResult
    {
        public JsonCamelCaseResult()
        {
            JsonRequestBehavior = JsonRequestBehavior.DenyGet;
        }

        public Encoding ContentEncoding
        {
            get;
            set;
        }

        public string ContentType
        {
            get;
            set;
        }

        public object Data
        {
            get;
            set;
        }

        public int? StatusCode
        {
            get;
            set;
        }

        public JsonRequestBehavior JsonRequestBehavior
        {
            get;
            set;
        }

        public override void ExecuteResult(ControllerContext context)
        {
            if (JsonRequestBehavior == JsonRequestBehavior.DenyGet && context.HttpContext.Request.HttpMethod.SafeEquals("GET"))
            {
                throw new InvalidOperationException("This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.");
            }

            HttpResponseBase response = context.HttpContext.Response;

            if (!ContentType.IsNullOrEmpty())
            {
                response.ContentType = ContentType;
            }
            else
            {
                response.ContentType = "application/json";
            }

            if (ContentEncoding != null)
            {
                response.ContentEncoding = ContentEncoding;
            }

            if (StatusCode != null)
            {
                response.StatusCode = StatusCode.Value;
            }

            if (Data != null)
            {
                JsonSerializerSettings jsonSerializerSettings = new JsonSerializerSettings
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver()
                };
                response.Write(JsonConvert.SerializeObject(Data, jsonSerializerSettings));
            }
        }
    }
}
