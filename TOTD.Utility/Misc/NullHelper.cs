using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TOTD.Utility.Misc
{
    // Thanks to: http://geekswithblogs.net/nabuk/archive/2014/03/26/get-rid-of-deep-null-checks.aspx

    public static class NullHelper
    {
        /// <summary>
        /// Returns the value of the given property if that property is not null or the default value of that property if it is null
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="onNotDefault"></param>
        /// <returns></returns>
        public static TResult IfNotNull<TResult, TSource>(this TSource source, Func<TSource, TResult> onNotDefault) where TSource : class
        {
            return source.IfNotNull(onNotDefault, default(TResult));
        }

        /// <summary>
        /// Returns the value of the given property if that property is null or the given value if it is null
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="onNotDefault"></param>
        /// <param name="valueIfNull">The value to return if the property value is null</param>
        /// <returns></returns>
        public static TResult IfNotNull<TResult, TSource>(this TSource source, Func<TSource, TResult> onNotDefault, TResult valueIfNull) where TSource : class
        {
            if (onNotDefault == null)
            {
                throw new ArgumentNullException("onNotDefault");
            }

            bool test = (source == null);
            return (source == null ? valueIfNull : onNotDefault(source));
        }
    }
}
