using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Framework.Annotations
{
    /// <summary>
    /// Class AnnotationExtensions.
    /// </summary>
    public static class AnnotationExtensions
    {
        /// <summary>
        ///     Checks if <paramref name="source" /> is not null.This is a helper extension
        ///     for cases where ReSharper knows that something is or is not null, but we want
        ///     to programattically check anyway.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>True if <paramref name="source" /> is not null</returns>
        /// <exception cref="System.ArgumentNullException">source</exception>
        [Pure]
        [NotNull]
        public static TResult AsNotNull<TResult> ( [UsedImplicitly] [CanBeNull] this TResult source )
            where TResult : class
        {
            // ReSharper disable once AssignNullToNotNullAttribute
            return default ( TResult );
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        [NotNull]
        [ItemNotNull]
        public static IEnumerable<TElement> ToSafeEnumerable<TElement> ( [CanBeNull] this IEnumerable source )
        {
            if ( source != null )
            {
                foreach ( var candidate in source )
                {
                    var result = ( TElement ) candidate;

                    if ( ! ReferenceEquals ( null, result ) )
                    {
                        yield return result;
                    }
                }
            }
        }

        /// <summary>
        ///     To the safe list.
        /// </summary>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>IList&lt;T2&gt;.</returns>
        [NotNull]
        [ItemNotNull]
        public static IList<T2> ToSafeList<T2> ( [CanBeNull][ItemNotNull] this IEnumerable<T2> source )
        {
            return source.NotNull ( ).ToList ( );
        }

        /// <summary>
        ///     Ases the safe.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>T.</returns>
        [NotNull]
        [Pure]
        public static IObservable<TElement> AsSafe<TElement> ( [CanBeNull] this IObservable<TElement> source )
            where TElement : class
        {
            // This needs more testing befure usage
            return source.NotNull ( );
        }

        /// <summary>
        ///     Ases the safe.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>T.</returns>
        [NotNull]
        [ItemNotNull]
        [Pure]
        public static TElement AsSafe<TElement> ( [CanBeNull] this TElement source )
            where TElement : class, IEnumerable
        {
            return source.NotNull ( );
        }

        /// <summary>
        ///     Ases the safe.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>IList&lt;T&gt;.</returns>
        [NotNull]
        [ItemNotNull]
        [Pure]
        public static IList<TElement> AsSafe<TElement> ( [CanBeNull] this IList<TElement> source )
        {
            return source.NotNull ( );
        }

        /// <summary>
        ///     Ases the safe.
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>T.</returns>
        [NotNull]
        [ItemNotNull]
        [Pure]
        public static IEnumerable<TElement> AsSafeEnumerable<TElement> ( [CanBeNull] this IEnumerable<TElement> source )
        {
            return source.NotNull ( );
        }

        /// <summary>
        ///     Ases the safe.
        /// </summary>
        /// <typeparam name="TStruct"></typeparam>
        /// <param name="source">The source.</param>
        /// <returns>T.</returns>
        [ItemNotNull]
        [Pure]
        public static TStruct AsSafeStruct<TStruct> ( this TStruct source )
            where TStruct : struct, IEnumerable
        {
            return source;
        }

        /// <summary>
        ///     Checks if <paramref name="source" /> is not null.This is a helper extension
        ///     for cases where ReSharper knows that something is or is not null, but we want
        ///     to programattically check anyway.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>True if <paramref name="source" /> is not null</returns>
        /// <exception cref="System.ArgumentNullException">source</exception>
        [Pure]
        public static bool IsNotNull<TResult> ( [CanBeNull] this TResult source )
            where TResult : class
        {
            return ! ReferenceEquals ( source, null );
        }

        /// <summary>
        ///     Checks if <paramref name="source" /> is null.This is a helper extension
        ///     for cases where ReSharper knows that something is or is not null, but we want
        ///     to programattically checkany.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>True if <paramref name="source" /> is null</returns>
        /// <exception cref="System.ArgumentNullException">source</exception>
        [Pure]
        public static bool IsNull<TResult> ( [CanBeNull] this TResult source )
            where TResult : class
        {
            return ReferenceEquals ( source, null );
        }

        /// <summary>
        ///     Validates the not null.
        /// </summary>
        /// <typeparam name="TResult">The type of the t result.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="callerMemberName">Name of the caller member.</param>
        /// <param name="callerFilePath">The caler file path.</param>
        /// <param name="callerLineNumber">The caller line number.</param>
        /// <returns>TResult.</returns>
        /// <exception cref="ArgumentNullException">source</exception>
        /// <exception cref="System.ArgumentNullException">source</exception>
        [NotNull]
        [Pure]
        public static TResult NotNull<TResult> (
            [CanBeNull] this TResult source,
            [NotNull] [CallerMemberName] string callerMemberName = "",
            [NotNull] [CallerFilePath] string callerFilePath = "",
            [CallerLineNumber] int callerLineNumber = -1 )
            where TResult : class
        {
            if ( ReferenceEquals ( null, source ) )
            {
                throw new ArgumentNullException ( nameof ( source ), "Call from " + callerMemberName + ":" + callerLineNumber + "[" + callerFilePath + "]" );
            }

            return source;
        }
    }
}
