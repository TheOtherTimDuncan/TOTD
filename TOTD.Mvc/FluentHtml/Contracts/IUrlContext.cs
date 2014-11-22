using System;
using System.Collections.Generic;

namespace TOTD.Mvc.FluentHtml.Contracts
{
    public interface IUrlContext
    {
        bool Matches(IUrlContext urlContext);
    }
}
