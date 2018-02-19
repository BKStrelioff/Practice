#region usings

using System;
using System.Globalization;

using Framework.Annotations;

#endregion

namespace Preferences.Extensions
{

    public static class DateTimeExtensions
    {

        #region class public methods

        [ NotNull ]
        public static string AsPreferenceFormat ( this DateTime source )
        {
            var result = source.ToString ( "M/d/yyyy", DateTimeFormatInfo.InvariantInfo );
            return result;
        }

        public static DateTime FromPreferenceFormat ( [ NotNull ] this string source )
        {
            // Use invariant in case process uses a different culture
            var result = DateTime.ParseExact ( source, "M/d/yyyy", DateTimeFormatInfo.InvariantInfo );

            return result;
        }

        #endregion

    }

}
