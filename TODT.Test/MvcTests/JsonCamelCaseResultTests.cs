using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using TOTD.Mvc;

namespace TODT.Test.MvcTests
{
    [TestClass]
    public class JsonCamelCaseResultTests
    {
        [TestMethod]
        public void GetRequestIsBlocked()
        {
            Mock<ControllerContext> mockControllerContext = new Mock<ControllerContext>();
            mockControllerContext.Setup(x => x.HttpContext.Request.HttpMethod).Returns("GET");

            JsonCamelCaseResult result = new JsonCamelCaseResult();

            Action action = () => result.ExecuteResult(mockControllerContext.Object);

            action.ShouldThrow<InvalidOperationException>().WithMessage("This request has been blocked because sensitive information could be disclosed to third party web sites when this is used in a GET request. To allow GET requests, set JsonRequestBehavior to AllowGet.");
        }
    }
}
