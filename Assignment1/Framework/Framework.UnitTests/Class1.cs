#region usings

using System;
using System.Collections.Generic;
using System.Linq;

using Framework.Extensions;

using Xunit;

#endregion

namespace Framework.UnitTests
{

    public sealed class LinqExtensionsUnitTests
    {

        #region class public methods

        [ Fact ]
        public static void ForEachActionUnitTest1 ( )
        {
            var random = new Random ( );
            var list = Enumerable.Range ( 0, 100 ).Select ( i => random.Next ( 1, 1000 ) ).ToList ( );

            // List does have a ForEach defined
            var sum1 = list.Sum ( i => i );

            var sum2 = 0;
            var asEnumerable = ( IEnumerable < int > ) list;
            asEnumerable.ForEach ( i => sum2 += i );

            Assert.Equal ( sum1, sum2 );
        }

        #endregion

    }

}
