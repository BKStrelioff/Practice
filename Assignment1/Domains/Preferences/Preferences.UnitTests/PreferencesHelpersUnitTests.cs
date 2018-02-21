#region usings

using System;
using System.IO;
using System.Linq;

using Framework.Annotations;

using Preferences.DomainModels;

using Xunit;

#endregion

namespace Preferences.UnitTests
{

    /// <summary>
    ///     Class PreferencesHelpersUnitTests. This class cannot be inherited.
    /// </summary>
    [ UsedImplicitly ]
    public sealed class PreferencesHelpersUnitTests
    {

        #region class public methods

        /// <summary>
        ///     Tests that a single delimiter with blanks also is properly recognized.
        /// </summary>
        [ Fact ]
        public static void Test_that_a_single_delimiter_with_blanks_also_is_properly_recognized ( )
        {
            foreach ( var delimiter in PreferencesHelpers.SupportedDelimiters )
            {
                var separator = new string ( new [ ]
                {
                    delimiter,
                    ' '
                } );
                var line = string.Join ( separator, Guid.NewGuid ( ).ToString ( ), Guid.NewGuid ( ).ToString ( ), Guid.NewGuid ( ).ToString ( ) );

                var actual = PreferencesHelpers.DecideDelimiterFromLine ( line );

                Assert.Equal ( delimiter, actual );
            }
        }

        /// <summary>
        ///     Tests that an exception is thrown if multiple nonblank delimiters present.
        /// </summary>
        [ Fact ]
        public static void Test_that_an_exception_is_thrown_if_multiple_nonblank_delimiters_present ( )
        {
            var multipleSeparator = new string ( PreferencesHelpers.SupportedDelimiters.ToArray ( ) );
            var line = string.Join ( multipleSeparator, Guid.NewGuid ( ).ToString ( ), Guid.NewGuid ( ).ToString ( ), Guid.NewGuid ( ).ToString ( ) );

            var exception = Record.Exception ( ( ) => PreferencesHelpers.DecideDelimiterFromLine ( line ) );
            Assert.NotNull ( exception );
            Assert.IsType < InvalidOperationException > ( exception );
        }

        /// <summary>
        ///     Tests that an unknown file is associated with character minimum value.
        /// </summary>
        [ Fact ]
        public static void Test_that_an_unknown_file_is_associated_with_char_minValue ( )
        {
            var fileInfo = new FileInfo ( "something.bin" );
            var actual = PreferencesHelpers.AssociatedDelimiter ( fileInfo );
            Assert.Equal ( char.MinValue, actual );
        }

        /// <summary>
        ///     Tests that blank is associated delimiter for text files.
        /// </summary>
        [ Fact ]
        public static void Test_that_blank_is_associated_delimiter_for_txt_files ( )
        {
            var fileInfo = new FileInfo ( "something.tXt" );
            var actual = PreferencesHelpers.AssociatedDelimiter ( fileInfo );
            Assert.Equal ( ' ', actual );
        }

        /// <summary>
        ///     Tests that comma is associated delimiter for CSV files.
        /// </summary>
        [ Fact ]
        public static void Test_that_comma_is_associated_delimiter_for_csv_files ( )
        {
            var fileInfo = new FileInfo ( "something.csv" );
            var actual = PreferencesHelpers.AssociatedDelimiter ( fileInfo );
            Assert.Equal ( ',', actual );
        }

        /// <summary>
        ///     Tests  that pipe is associated delimiter for pipe files.
        /// </summary>
        [ Fact ]
        public static void Test_that_pipe_is_associated_delimiter_for_pipe_files ( )
        {
            var fileInfo = new FileInfo ( "something.pIpE" );
            var actual = PreferencesHelpers.AssociatedDelimiter ( fileInfo );
            Assert.Equal ( '|', actual );
        }

        #endregion

    }

}
