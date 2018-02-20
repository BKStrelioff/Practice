#region usings

using System.Collections.Generic;
using System.Linq;

using Framework.Annotations;

using Preferences.Interfaces;

#endregion

namespace Preferences.DataObjects
{
    /// <summary>
    /// 
    /// </summary>
    public static class MappingExtensions
    {

        #region class public methods

        /// <summary>
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        [ NotNull ]
        [ ItemNotNull ]
        public static IEnumerable < TTo > To <  TTo > ( [ NotNull ] [ ItemNotNull ] this IEnumerable <IPersonColorPreferenceModel> source )
            where TTo : class, IPersonColorPreferenceModel, new ( )
        {
            var result = source.Select ( r => r.To < TTo > ( ) ).ToList ( );

            return result;
        }

        /// <summary>
        /// </summary>
        /// <typeparam name="TTo"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        [ NotNull ]
        public static TTo To < TTo > ( [ NotNull ] this IPersonColorPreferenceModel source )
            where TTo : class, IPersonColorPreferenceModel, new ( )
        {
            var result = new TTo ( );
            result.PopulateFrom ( source );

            return result;
        }

        #endregion

    }

}
