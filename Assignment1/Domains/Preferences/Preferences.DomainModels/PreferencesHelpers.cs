﻿#region usings

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

using Framework.Annotations;
using Framework.Helpers;

using Preferences.Extensions;
using Preferences.Interfaces;

#endregion

namespace Preferences.DomainModels
{

    public static class PreferencesHelpers
    {

        #region class public methods

        public static char AssociatedDelimiter ( [ NotNull ] FileSystemInfo fileInfo )
        {
            var extension = fileInfo.Extension.ToUpperInvariant ( );
            char result;

            switch ( extension )
            {
                case ".CSV":
                    result = ',';
                    break;
                case ".TXT":
                    result = ' ';
                    break;
                case ".PIPE":
                    result = '|';
                    break;
                default:
                    result = char.MinValue;
                    break;
            }

            return result;
        }

        public static char DecideDelimiterFromLine ( [ NotNull ] string line )
        {
            var which = SupportedDelimiters.Where ( line.Contains ).OrderBy ( c => c ).ToList ( );
            var nonBlank = which.Where ( c => c != ' ' ).ToList ( );
            if ( nonBlank.Count > 1 )
            {
                throw new InvalidOperationException ( );
            }

            var delimiter = nonBlank.Count == 1 ? nonBlank [ 0 ] : ' ';
            return delimiter;
        }

        [ NotNull ]
        public static IEnumerable < IPersonColorPreferenceModel > GenerateRandomRecords ( int count, [ NotNull ] Random randomProvider, int randomLimit )
        {
            var result = new List < IPersonColorPreferenceModel > ( );
            var epoch = new DateTime ( 1970, 1, 1 );
            var daysSinceEpoch = ( int ) ( DateTime.Today - epoch ).TotalDays;
            var genderValues = new [ ]
            {
                "Female",
                "Male"
            };
            for ( var index = 0; index < count; index += 1 )
            {
                var dateTimeBirth = epoch.AddDays ( randomProvider.Next ( 0, daysSinceEpoch ) );
                var dateOfBirth = dateTimeBirth.AsPreferenceFormat ( );
                var genderValue = genderValues [ dateTimeBirth.Date.Day % 2 ];
                result.Add ( new PersonColorPreferenceModel
                {
                    FavoriteColor = RandomHelpers.RandomString ( randomProvider, 3, 10, "color" ),
                    FirstName = RandomHelpers.RandomString ( randomProvider, 3, 10, "firstFirst" ),
                    LastName = RandomHelpers.RandomString ( randomProvider, 3, 10, "familyFamily'-" ),
                    DateOfBirth = dateOfBirth,
                    Gender = genderValue
                } );
            }

            return result;
        }

        public static void Load ( [ NotNull ] PreferencesModel model, [ NotNull ] FileInfo fileInfo )
        {
            var delimiterChar = AssociatedDelimiter ( fileInfo );

            var lines = ReadLines ( fileInfo );

            model.Add ( lines, delimiterChar );
        }

        [ NotNull ]
        public static PersonColorPreferenceModel Parse ( [ NotNull ] string line, char delimiter )
        {
            var parts = line.Split ( delimiter ).AsSafeEnumerable ( ).Select ( l => l.Trim ( ) ).ToList ( );
            if ( parts.Count != 5 )
            {
                throw new InvalidOperationException ( );
            }

            var lastName = parts [ 0 ].NotNull ( );
            var firstName = parts [ 1 ].NotNull ( );
            var gender = parts [ 2 ].NotNull ( );
            var favoriteColor = parts [ 3 ].NotNull ( );
            var dateOfBirth = parts [ 4 ].NotNull ( );

            var record = new PersonColorPreferenceModel
            {
                LastName = lastName,
                FirstName = firstName,
                Gender = gender,
                FavoriteColor = favoriteColor,
                DateOfBirth = dateOfBirth
            };
            return record;
        }

        [ NotNull ]
        [ ItemNotNull ]
        public static IEnumerable < string > ReadLines ( [ NotNull ] FileInfo fileInfo )
        {
            var streamReader = fileInfo.OpenText ( );
            var readToEnd = streamReader.ReadToEnd ( );
            var lines = readToEnd.Split ( new [ ]
                {
                    Environment.NewLine
                },
                StringSplitOptions.RemoveEmptyEntries );

            return lines;
        }

        #endregion

        #region class public properties

        /// <summary>
        /// </summary>
        [ NotNull ]
        public static IEnumerable < char > SupportedDelimiters
        {
            get
            {
                return new [ ]
                {
                    ',',
                    ' ',
                    '|'
                };
            }
        }

        #endregion

    }

}
