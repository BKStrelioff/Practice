#region usings

using System;
using System.Linq;

using Framework.Annotations;

#endregion

namespace Framework.Helpers
{

    /// <summary>
    ///     Class Randomizer.
    /// </summary>
    public static class RandomHelpers
    {

        #region class public methods

        /// <summary>
        ///     Randoms the string.
        /// </summary>
        /// <param name="randomProvider">The random provider.</param>
        /// <param name="minLength">The minimum length.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <param name="characterDistribution">The character distribution.</param>
        /// <returns>System.String.</returns>
        [ NotNull ]
        public static string RandomString ( [ NotNull ] Random randomProvider, int minLength, int maxLength, [ NotNull ] string characterDistribution )
        {
            var distributionLength = characterDistribution.Length;
            var characters = Enumerable.Range ( minLength, maxLength ).Select ( i => characterDistribution [ randomProvider.Next ( 0, distributionLength ) ] ).ToArray ( );

            var result = new string ( characters );

            return result;
        }

        #endregion

    }

}
