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

        private static char AssociatedDelimiter ([ NotNull ] FileSystemInfo fileInfo )
        {
            var extension = fileInfo.Extension.ToUpperInvariant ( );
            var result = ' ';
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
                    WriteUsageInfo ( );
                    Environment.Exit ( 1 );
                    break;
            }

            return result;
        }

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

                var delimiterChar = AssociatedDelimiter ( fileInfo );
                var delimiterString = delimiterChar.ToString ( );

                var preferencesModel = new PreferencesModel ( );
                var streamReader = fileInfo.OpenText();
                var readToEnd = streamReader.ReadToEnd();
                var lines = readToEnd.Split ( new [ ]
                    {
                        Environment.NewLine
                    },
                    StringSplitOptions.RemoveEmptyEntries );
                foreach ( var line in lines )
                {
                    var parts = line.Split ( delimiterChar ).Select(l => l.Trim()).ToList();
                    if ( parts.Count != 5 )
                    {
                        throw new InvalidOperationException ( );
                    }

                    var record = new PersonColorPreferenceModel
                    {
                        LastName = parts[0],
                        FirstName = parts[1],
                        Gender = parts[2],
                        FavoriteColor = parts[3],
                        DateOfBirth = parts[4]
                    };

                    preferencesModel.Add ( record );
                }

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

                var randomRecords = PreferencesModel.GenerateRandomRecords ( recordsToGenerate, new Random ( ), 7 );
                using ( var writer = new StreamWriter ( fileInfo.FullName, false ) )
                {
                    var delimiterChar = AssociatedDelimiter ( fileInfo );
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
