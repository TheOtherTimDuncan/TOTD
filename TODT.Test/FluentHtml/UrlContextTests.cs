﻿using System;
using FluentAssertions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TOTD.Mvc.FluentHtml;

namespace TOTD.Test.FluentHtml
{
    [TestClass]
    public class UrlContextTests
    {
        [TestClass]
        public class InternalUrlContextTests
        {
            [TestMethod]
            public void CorrectlyParsesAreaNameFromRouteValues()
            {
                InternalUrlContext urlContext = new InternalUrlContext("action", "controller", new
                {
                    area = "area"
                });

                urlContext.Area.Should().Be("area");
                urlContext.ControllerName.Should().Be("controller");
                urlContext.ActionName.Should().Be("action");
            }

            [TestMethod]
            public void MatchesToContextWithoutArea()
            {
                InternalUrlContext context1 = new InternalUrlContext("action", "controller");
                InternalUrlContext context2 = new InternalUrlContext("action", "controller");
                context1.Matches(context2).Should().BeTrue();
            }
        }
    }
}
