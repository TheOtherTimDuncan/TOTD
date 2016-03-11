﻿using System;
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
        /// <summary>
        /// Returns the specified number of elements starting at the beginning of the specified page
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="page">The 1-based number of the page to skip to</param>
        /// <param name="pageSize">The number of elements in a page</param>
        /// <returns></returns>
        public static IQueryable<T> TakePage<T>(this IQueryable<T> source, int? page, int pageSize)
        {
            ThrowIf.Argument.IsNull(source, "source");

            int skipCount = ((page ?? 1) - 1) * pageSize;

            // Lambda version of Skip/Take will parameterize page values which will improve query plan
            return source.Skip(() => skipCount).Take(() => pageSize);
        }

        /// <summary>
        /// Returns the specified number of elements starting at the beginning of the specified page and immediately invokes the query by calling ToListAsync
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="page">The 1-based number of the page to skip to</param>
        /// <param name="pageSize">The number of elements in a page</param>
        /// <returns></returns>
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

        /// <summary>
        /// Projects each element of a sequence into a new form and returns the only element from the new form
        /// Throws an exception if there is not exactly one element in the new form
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns>The single element of the new form</returns>
        public static TResult SelectSingle<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)
        {
            return source.Select(selector).Single();
        }

        /// <summary>
        /// Projects each element of a sequence into a new form and returns the only element from the new form
        /// Throws an exception if there is not exactly one element in the new form
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns>The single element of the new form</returns>
        public static async Task<TResult> SelectSingleAsync<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)
        {
            return await source.Select(selector).SingleAsync();
        }

        /// <summary>
        /// Projects each element of a sequence into a new form and returns the only element from the new form
        /// or a default value if the new form is empty
        /// Throws an exception if there is not exactly one element in the new form
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns>The single element of the new form or default(TSource) if the new form is empty</returns>
        public static TResult SelectSingleOrDefault<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)
        {
            return source.Select(selector).SingleOrDefault();
        }

        /// <summary>
        /// Projects each element of a sequence into a new form and returns the only element from the new form
        /// or a default value if the new form is empty
        /// Throws an exception if there is not exactly one element in the new form
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns>The single element of the new form or default(TSource) if the new form is empty</returns>
        public static async Task<TResult> SelectSingleOrDefaultAsync<TSource, TResult>(this IQueryable<TSource> source, Expression<Func<TSource, TResult>> selector)
        {
            return await source.Select(selector).SingleOrDefaultAsync();
        }
    }
}
