using System;
using System.Collections.Generic;

namespace TOTD.Mvc.FluentHtml.Contracts
{
    public interface IHtmlConvention
    {
        void ApplyConvention(IElement element);
    }
}
