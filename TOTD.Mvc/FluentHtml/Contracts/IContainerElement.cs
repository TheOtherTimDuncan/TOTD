using System;
using System.Collections.Generic;

namespace TOTD.Mvc.FluentHtml.Contracts
{
    public interface IContainerElement : IElement
    {
        IEnumerable<IElement> Children
        {
            get;
        }
    }
}
