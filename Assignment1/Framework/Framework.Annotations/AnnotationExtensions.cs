#region usings

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

#endregion

namespace Framework.Annotations
{

    /// <summary>
    ///     Class AnnotationExtensions.
    /// </summary>
    public static class AnnotationExtensions
    {

        #region class public methods

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
        [ NotNull ]
        [ Pure ]
        public static TResult NotNull < TResult > (
            [ CanBeNull ] this TResult source,
            [ NotNull ] [ CallerMemberName ] string callerMemberName = "",
            [ NotNull ] [ CallerFilePath ] string callerFilePath = "",
            [ CallerLineNumber ] int callerLineNumber = -1 )
            where TResult : class
        {
            if ( ReferenceEquals ( null, source ) )
            {
                throw new ArgumentNullException ( nameof ( source ), "Call from " + callerMemberName + ":" + callerLineNumber + "[" + callerFilePath + "]" );
            }

            return source;
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="TElement"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        [ NotNull ]
        [ ItemNotNull ]
        public static IEnumerable < TElement > ToSafeEnumerable < TElement > ( [ CanBeNull ] this IEnumerable source )
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
        ///     To safe list.
        /// </summary>
        /// <typeparam name="T2">The type of the t2.</typeparam>
        /// <param name="source">The source.</param>
        /// <returns>IList&lt;T2&gt;.</returns>
        [ NotNull ]
        [ ItemNotNull ]
        public static IList < T2 > ToSafeList < T2 > ( [ CanBeNull ] [ ItemNotNull ] this IEnumerable < T2 > source )
        {
            return source.NotNull ( ).ToSafeEnumerable < T2 > ( ).ToList ( );
        }

        #endregion

    }

}
