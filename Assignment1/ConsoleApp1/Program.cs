#region usings

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

using Framework.Annotations;
using Framework.Extensions;

using Preferences.DomainModels;
using Preferences.Interfaces;

#endregion

namespace ConsoleApp1
{

    internal class Program
    {

        #region class non-public methods


        /// <summary>
        ///     Defines the entry point of the application.
        /// </summary>
        /// <param name="args">The arguments.</param>
        static void Main ( [ NotNull ] [ ItemNotNull ] string [ ] args )
        {
            var programName = Process.GetCurrentProcess ( ).ProcessName;

            if ( args.Length == 1 )
            {
                var fileName = args [ 0 ];
                var fileInfo = new FileInfo ( fileName );

                if ( ! fileInfo.Exists )
                {
                    Console.WriteLine ( $"File '{fileInfo.FullName} does not exist" );
                }

                var preferencesModel = new PreferencesModel ( );
                PreferencesHelpers.Load (preferencesModel, fileInfo );

                var byGender = preferencesModel.ByGenderLastName ( );
                WriteRecords ( "By gender, then last name ascending", byGender );

                var byBirthDate = preferencesModel.ByBirthDate ( );
                WriteRecords ( "By birth date", byBirthDate );

                var byLastNameDescending = preferencesModel.ByLastNameDescending ( );
                WriteRecords ( "By last name descending", byLastNameDescending );

                var byName = preferencesModel.ByName ( );
                WriteRecords ( "By name", byName );
            }
            else if ( args.Length == 2 )
            {
                if ( ! int.TryParse ( args [ 1 ], out var recordsToGenerate ) )
                {
                    throw new InvalidOperationException ( );
                }
                var fileName = args [ 0 ];
                var fileInfo = new FileInfo ( fileName );
                var format = fileInfo.Extension.ToUpperInvariant ( );

                if ( fileInfo.Exists )
                {
                    Console.WriteLine ( $"File '{fileInfo.FullName} already exists, you must remove it manually" );
                }

                var randomRecords = PreferencesHelpers.GenerateRandomRecords ( recordsToGenerate, new Random ( ), 7 );
                using ( var writer = new StreamWriter ( fileInfo.FullName, false ) )
                {
                    var delimiterChar = PreferencesHelpers.AssociatedDelimiter ( fileInfo );
                    var delimiterString = delimiterChar.ToString ( );
                    randomRecords.ForEach ( r =>
                    {
                        var strings = new [ ]
                        {
                            r.LastName,
                            r.FirstName,
                            r.Gender,
                            r.FavoriteColor,
                            r.DateOfBirth
                        }.ToList ( );
                        var line = string.Join ( delimiterString, strings );
                        writer.WriteLine ( line );
                    } );
                }
            }
            else
            {
                WriteUsageInfo ( );
            }
        }

        private static void WriteRecords ([NotNull] string caption,[NotNull][ItemNotNull] IEnumerable < IPersonColorPreferenceModel > records )
        {
            Console.WriteLine ( );
            Console.WriteLine ( caption );
            records.ForEach ( r => Console.WriteLine ( r.ToString ( ) ) );
        }

        private static void WriteUsageInfo ( )
        {
            Console.WriteLine ( "Usage to use existing Data: {processName} [ name of existing data file ]" );
            Console.WriteLine ( "Usage to generate data: {processName} [ name of data file ] [ number of records to create ]" );
            Console.WriteLine ( "Delimiter is determined by file extension: CSV/',', PIPE/'|', TXT/' '" );
        }

        #endregion

    }

}
