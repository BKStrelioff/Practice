#region usings

using System;
using System.Threading.Tasks;

using Preferences.Extensions;

using Xunit;

#endregion

namespace Preferences.UnitTests
{

    public sealed class DateExtensionsUnitTests
    {

        #region instance public methods

        [ Fact ]
        public void BadLeap ( )
        {
            var exception = Record.Exception ( ( ) => "2/29/2017".FromPreferenceFormat ( ) );
            Assert.NotNull ( exception );
            Assert.IsType < FormatException > ( exception );
        }

        [ Fact ]
        public void DayMissing ( )
        {
            var exception = Record.Exception ( ( ) => "1//2017".FromPreferenceFormat ( ) );
            Assert.NotNull ( exception );
            Assert.IsType < FormatException > ( exception );
        }

        [ Fact ]
        public void DayMonthOrder ( )
        {
            var exception = Record.Exception ( ( ) => "31/1/2017".FromPreferenceFormat ( ) );
            Assert.NotNull ( exception );
            Assert.IsType < FormatException > ( exception );
        }

        [ Fact ]
        public void MonthBlank ( )
        {
            var exception = Record.Exception ( ( ) => "31/ 1/2017".FromPreferenceFormat ( ) );
            Assert.NotNull ( exception );
            Assert.IsType < FormatException > ( exception );
        }

        [ Fact ]
        public void MonthLeft0 ( )
        {
            var exception = Record.Exception ( ( ) => "31/001/2017".FromPreferenceFormat ( ) );
            Assert.NotNull ( exception );
            Assert.IsType < FormatException > ( exception );
        }

        [ Fact ]
        public void RoundTrip ( )
        {
            var epoch = new DateTime ( 1800, 1, 1 );

            Parallel.For ( 0,
                300 * 366,
                day =>
                {
                    var target = epoch.AddDays ( day );
                    var asString1 = target.AsPreferenceFormat ( );
                    var asDateTime = asString1.FromPreferenceFormat ( );
                    var asString2 = asDateTime.AsPreferenceFormat ( );

                    Assert.Equal ( target, asDateTime );

                    Assert.Equal ( asString1, asString2 );

                    Assert.Equal ( target, target.AsPreferenceFormat ( ).FromPreferenceFormat ( ) );
                } );
        }

        [ Fact ]
        public void YearFormat ( )
        {
            var exception = Record.Exception ( ( ) => "1/1/17".FromPreferenceFormat ( ) );
            Assert.NotNull ( exception );
            Assert.IsType < FormatException > ( exception );
        }

        #endregion

    }

}
