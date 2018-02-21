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

    /// <summary>
    /// Class PreferencesHelpers.
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for PreferencesHelpers
    public static class PreferencesHelpers
    {

        #region class public methods

        /// <summary>
        /// Associateds the delimiter.
        /// </summary>
        /// <param name="fileInfo">The file information.</param>
        /// <returns>System.Char.</returns>
        /// <remarks>
        /// Maybe change to throw an exception, and add a Try* variant?
        /// </remarks>
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

        /// <summary>
        /// Decides the delimiter from line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns>System.Char.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for DecideDelimiterFromLine
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

        /// <summary>
        /// Generates the random records.
        /// </summary>
        /// <param name="count">The count.</param>
        /// <param name="randomProvider">The random provider.</param>
        /// <param name="randomLimit">The random limit.</param>
        /// <returns>IEnumerable&lt;IPersonColorPreferenceModel&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for GenerateRandomRecords
        [NotNull ]
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
                var dateOfBirth = dateTimeBirth.ToPreferenceFormat ( );
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

        /// <summary>
        /// Loads the specified model.
        /// </summary>
        /// <param name="model">The model.</param>
        /// <param name="fileInfo">The file information.</param>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Load
        public static void Load ( [ NotNull ] PreferencesModel model, [ NotNull ] FileInfo fileInfo )
        {
            var delimiterChar = AssociatedDelimiter ( fileInfo );

            var lines = ReadLines ( fileInfo );

            model.Add ( lines, delimiterChar );
        }

        /// <summary>
        /// Parses the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <param name="delimiter">The delimiter.</param>
        /// <returns>PersonColorPreferenceModel.</returns>
        /// <exception cref="InvalidOperationException"></exception>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Parse
        [NotNull ]
        public static PersonColorPreferenceModel Parse ( [ NotNull ] string line, char delimiter )
        {
            var parts = line.Split ( delimiter ).ToSafeList().Select ( l => l.Trim ( ) ).ToList ( );
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

        /// <summary>
        /// Reads the lines.
        /// </summary>
        /// <param name="fileInfo">The file information.</param>
        /// <returns>IEnumerable&lt;System.String&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ReadLines
        [NotNull ]
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
        /// Gets the supported delimiters.
        /// </summary>
        /// <value>The supported delimiters.</value>
        [NotNull ]
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
