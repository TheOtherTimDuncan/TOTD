﻿using System;
using System.Collections.Generic;
using System.Linq;
using TOTD.Mvc.FluentHtml.Contracts;
using TOTD.Utility.StringHelpers;

namespace TOTD.Mvc.FluentHtml
{
    public class ExternalUrlContext : IUrlContext
    {
        public ExternalUrlContext(string url)
        {
            this.Url = url;
        }

        public string Url
        {
            get;
            private set;
        }

        public bool Matches(IUrlContext urlContext)
        {
            ExternalUrlContext otherUrl = urlContext as ExternalUrlContext;
            if (otherUrl == null)
            {
                return false;
            }

            return otherUrl.Url.SafeEquals(this.Url);
        }
    }
}