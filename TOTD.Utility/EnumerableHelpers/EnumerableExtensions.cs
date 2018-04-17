using System;
using System.Collections.Generic;
using System.Linq;
using TOTD.Utility.ExceptionHelpers;

namespace TOTD.Utility.EnumerableHelpers
{
    public static class EnumerableExtensions
    {
        /// <summary>
        /// Determines whether a sequence is null or contains no elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns>
        /// True if the source sequence is null or contains no elements; otherwise false
        /// </returns>
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> source)
        {
            return source == null || !source.Any();
        }

        /// <summary>
        /// Returns the specified number of elements starting at the beginning of the specified page
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="page">The 1-based number of the page to skip to</param>
        /// <param name="pageSize">The number of elements in a page</param>
        /// <returns></returns>
        public static IEnumerable<T> TakePage<T>(this IEnumerable<T> source, int page, int pageSize)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.Skip((page - 1) * pageSize).Take(pageSize);
        }

        /// <summary>
        /// Determines whether a sequence contains any elements
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns>Returns true if the source sequence contains any elements; returns false if otherwise or if the source is null</returns>
        public static bool NullSafeAny<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                return false;
            }

            return source.Any(predicate);
        }

        /// <summary>
        /// Filters a sequence of values based on a predicate.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns>An IEnumerable{T} that contains elements from the input sequence that satisfy the condition; returns an empty IEnumerable{T} if the source is null</returns>
        public static IEnumerable<T> NullSafeWhere<T>(this IEnumerable<T> source, Func<T, bool> predicate)
        {
            if (source == null)
            {
                return Enumerable.Empty<T>();
            }

            return source.Where(predicate);
        }

        /// <summary>
        /// Projects each element of a sequence into a new form
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns>An IEnumerable{TResult} whose elements are the result of invoking the transform fucntion on each element of {TSource}; returns an empty IEnumerable{TResult} if the source is null</returns>
        public static IEnumerable<TResult> NullSafeSelect<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            if (source == null)
            {
                return Enumerable.Empty<TResult>();
            }

            return source.Select(selector);
        }

        /// <summary>
        ///  Returns the only element of a sequence, and throws an exception if there is not exactly one element in the sequence.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns>
        /// The single element of the input sequence, or default(TSource) if source is null
        /// </returns>
        public static TSource NullSafeSingle<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                return default(TSource);
            }

            return source.Single();
        }

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition,
        /// and throws an exception if more than one such element exists.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns>The single element of the input sequence that satisfies a condition, or default(TSource) if source is null</returns>
        public static TSource NullSafeSingle<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                return default(TSource);
            }

            return source.SingleOrDefault(predicate);
        }

        /// <summary>
        /// Returns the only element of a sequence, or a default value if the sequence
        /// is empty; this method throws an exception if there is more than one element
        /// in the sequence.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <returns>The single element of the input sequence, or default(TSource) if the sequence is null or contains no elements</returns>
        public static TSource NullSafeSingleOrDefault<TSource>(this IEnumerable<TSource> source)
        {
            if (source == null)
            {
                return default(TSource);
            }

            return source.SingleOrDefault();
        }

        /// <summary>
        /// Returns the only element of a sequence that satisfies a specified condition
        /// or a default value if no such element exists; this method throws an exception
        /// if more than one element satisfies the condition.
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="predicate"></param>
        /// <returns>
        /// The single element of the input sequence that satisfies the condition, or 
        /// default(TSource) if no element found or source is null
        /// </returns>
        public static TSource NullSafeSingleOrDefault<TSource>(this IEnumerable<TSource> source, Func<TSource, bool> predicate)
        {
            if (source == null)
            {
                return default(TSource);
            }

            return source.SingleOrDefault(predicate);
        }

        /// <summary>
        /// Returns the number of elements in a sequence
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="source"></param>
        /// <returns>The number of elements in the input sequence; returns 0 if the source is null</returns>
        public static int NullSafeCount<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                return 0;
            }

            return source.Count();
        }

        /// <summary>
        /// Sorts the elements of a sequence in ascending order according to a key
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns>An IEnumerable{TSource} whose elements are sorted according to a key or an empty IEnumerable{TSource} if the source is null</returns>
        public static IEnumerable<TSource> NullSafeOrderBy<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
            {
                return Enumerable.Empty<TSource>();
            }

            return source.OrderBy(keySelector);
        }

        /// <summary>
        /// Sorts the elements of a sequence in descending order according to a key
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TKey"></typeparam>
        /// <param name="source"></param>
        /// <param name="keySelector"></param>
        /// <returns>An IEnumerable{TSource} whose elements are sorted according to a key or an empty IEnumerable{TSource} if the source is null</returns>
        public static IEnumerable<TSource> NullSafeOrderByDescending<TSource, TKey>(this IEnumerable<TSource> source, Func<TSource, TKey> keySelector)
        {
            if (source == null)
            {
                return Enumerable.Empty<TSource>();
            }

            return source.OrderByDescending(keySelector);
        }

        /// <summary>
        /// Performs the specified action on each element of the given sequence
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        public static void ForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            ThrowIf.Argument.IsNull(source, nameof(source));
            ThrowIf.Argument.IsNull(action, nameof(action));

            foreach (TSource s in source)
            {
                action(s);
            }
        }

        /// <summary>
        /// Performs the specified action on each element of the given sequence or does nothing the sequence is null
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <param name="source"></param>
        /// <param name="action"></param>
        /// <exception cref="ArgumentNullException">Thrown if action or source is null</exception>
        public static void NullSafeForEach<TSource>(this IEnumerable<TSource> source, Action<TSource> action)
        {
            if (source == null)
            {
                return;
            }

            foreach (TSource s in source)
            {
                action(s);
            }
        }

        /// <summary>
        /// Concatenates the members of the given sequence using the specified separator between each member
        /// </summary>
        /// <param name="source"></param>
        /// <param name="separator"></param>
        /// <returns>A string that consists of the members of the sequence delimited by the separator. Returns null if the sequence is null.</returns>
        public static string NullSafeJoin<T>(this IEnumerable<T> source, string separator)
        {
            if (source == null)
            {
                return null;
            }

            return String.Join(separator, source);
        }

        /// <summary>
        /// Concatenates the members of the given sequence using the specified separator between each member
        /// </summary>
        /// <param name="source"></param>
        /// <param name="separator"></param>
        /// <returns>A string that consists of the members of the sequence delimited by the separator. Returns String.Empty if the sequence is empty.</returns>
        /// <exception cref="System.ArgumentNullException">sequence is null</exception>
        public static string Join<T>(this IEnumerable<T> source, string separator)
        {
            return String.Join(separator, source);
        }

        public static void BatchForEach<TSource>(this IEnumerable<TSource> source, int batchSize, Action<IEnumerable<TSource>> action)
        {
            if (source.IsNullOrEmpty())
            {
                return;
            }

            int skip = 0;
            IEnumerable<TSource> batch = source.Skip(skip).Take(batchSize);
            while (batch.Any())
            {
                action(batch);
                skip += batchSize;
                batch = source.Skip(skip).Take(batchSize);
            }
        }

        /// <summary>
        /// Projects each element of a sequence into a new form and immediately invokes the projection by calling ToList
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="selector"></param>
        /// <returns> 
        /// A System.Collections.Generic.IEnumerable`1  whose elements are the result of 
        /// invoking the transform function on each element of source.
        /// </returns>
        public static List<TResult> SelectToList<TSource, TResult>(this IEnumerable<TSource> source, Func<TSource, TResult> selector)
        {
            return source.Select(selector).ToList();
        }
    }
}
