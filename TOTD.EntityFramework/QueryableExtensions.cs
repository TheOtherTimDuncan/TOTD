using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using TOTD.Utility.ExceptionHelpers;

namespace TOTD.EntityFramework
{
    public static class QueryableExtensions
    {
        public static IQueryable<T> TakePage<T>(this IQueryable<T> source, int? page, int pageSize)
        {
            ThrowIf.Argument.IsNull(source, "source");

            int skipCount = ((page ?? 1) - 1) * pageSize;

            // Lambda version of Skip/Take will parameterize page values which will improve query plan
            return source.Skip(() => skipCount).Take(() => pageSize);
        }

        public static async Task<IEnumerable<T>> TakePageToListAsync<T>(this IQueryable<T> source, int? page, int pageSize)
        {
            ThrowIf.Argument.IsNull(source, "source");

            return await source.TakePage(page, pageSize).ToListAsync();
        }

        /// <summary>
        /// Projects each element of a sequence into a new form and immediately invokes the projection by calling ToList
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns> 
        /// A System.Linq.IQueryable`1 whose elements are the result of 
        /// invoking the transform function on each element of source.
        /// </returns>
        public static IEnumerable<TResult> SelectToList<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)
        {
            return source.Select(selector).ToList();
        }

        /// <summary>
        /// Projects each element of a sequence into a new form and immediately invokes the projection by calling ToListAsync
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns> 
        /// A System.Linq.IQueryable`1 whose elements are the result of 
        /// invoking the transform function on each element of source.
        /// </returns>
        public static async Task<IEnumerable<TResult>> SelectToListAsync<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)
        {
            return await source.Select(selector).ToListAsync();
        }
    }
}
