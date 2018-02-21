﻿#region usings

using System;
using System.Collections.Generic;

using Framework.Annotations;

#endregion

namespace Framework.Extensions
{

    /// <summary>
    /// Class LinqExtensions.
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for LinqExtensions
    public static class LinqExtensions
    {

        #region class public methods

        /// <summary>
        /// Fors the each.
        /// </summary>
        /// <typeparam name="TElement">The type of the t element.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="action">The action.</param>
        public static void ForEach < TElement > ( [ NotNull ] [ ItemNotNull ] this IEnumerable < TElement > source, [ NotNull ] Action < TElement > action )
        {
            foreach ( var item in source )
            {
                action ( item );
            }
        }

        /// <summary>
        /// Fors the each.
        /// </summary>
        /// <typeparam name="TElement">The type of the t element.</typeparam>
        /// <param name="source">The source.</param>
        /// <param name="predicate">The predicate.</param>
        /// <param name="action">The action.</param>
        public static void ForEach < TElement > (
            [ NotNull ] [ ItemNotNull ] this IEnumerable < TElement > source,
            [ NotNull ] Predicate < TElement > predicate,
            [ NotNull ] Action < TElement > action )
        {
            foreach ( var item in source )
            {
                if ( predicate ( item ) )
                {
                    action ( item );
                }
            }
        }

        #endregion

    }

}
