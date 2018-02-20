#region usings

using System;
using System.Linq;

using Preferences.DomainModels;
using Preferences.Extensions;

using Xunit;

#endregion

namespace Preferences.UnitTests
{

    /// <summary>
    ///     Class PreferencesModelUnitTests. This class cannot be inherited.
    /// </summary>
    public sealed class PreferencesModelUnitTests
    {

        #region instance public methods

        /// <summary>
        ///     Make sure there is a default constructor.
        ///     This should be done via reflection and attributes.
        /// </summary>
        [ Fact ]
        public void DefaultConstructor ( )
        {
            var actual = new PreferencesModel ( );
            Assert.NotNull ( actual );
        }

        /// <summary>
        ///     Test default result for PersonColorPreferences, make sure results are distinct enumerables.
        /// </summary>
        [ Fact ]
        public void DefaultPersonColorPreferences ( )
        {
            var actual = new PreferencesModel ( );
            Assert.NotNull ( actual );

            var enum1 = actual.PersonColorPreferences;
            var enum2 = actual.PersonColorPreferences;
            Assert.False ( ReferenceEquals ( enum1, enum2 ) );

            var records1 = actual.PersonColorPreferences.ToList ( );
            Assert.Equal ( 0, records1.Count );

            var records2 = actual.PersonColorPreferences.ToList ( );
            Assert.Equal ( 0, records2.Count );
        }

        /// <summary>
        ///     Test that the Id field is set during Add, and that the record added
        ///     is in fact a copy of the record passed in.
        /// </summary>
        [ Fact ]
        public void IdDeterminedByAdd ( )
        {
            // Set the second last bit to ensure not 0 or 1;
            var id = Guid.NewGuid ( ).GetHashCode ( ) | 0x02;
            var now = DateTime.Now.Date;
            var nowString = now.AsPreferenceFormat ( );
            var favoriteColor = Guid.NewGuid ( ).ToString ( );
            var firstName = Guid.NewGuid ( ).ToString ( );
            var gender = Guid.NewGuid ( ).ToString ( );
            var lastName = Guid.NewGuid ( ).ToString ( );

            var target = new PersonColorPreferenceModel
            {
                Id = id,
                DateOfBirth = nowString,
                FavoriteColor = favoriteColor,
                FirstName = firstName,
                Gender = gender,
                LastName = lastName
            };

            var model = new PreferencesModel ( );
            model.Add ( target );

            Assert.Equal ( id, target.Id );

            var records = model.PersonColorPreferences.ToList ( );
            var notAdded = records.FirstOrDefault ( r => r.Id == id);
            Assert.Null ( notAdded ); 

            var added = records.Single ( r => r.Id == 1 );
            Assert.True ( ReferenceEquals ( added, records.Single ( r => r.DateOfBirth == nowString ) ) );
            Assert.True ( ReferenceEquals ( added, records.Single ( r => r.FavoriteColor == favoriteColor ) ) );
            Assert.True ( ReferenceEquals ( added, records.Single ( r => r.FirstName == firstName ) ) );
            Assert.True ( ReferenceEquals ( added, records.Single ( r => r.Gender == gender ) ) );
            Assert.True ( ReferenceEquals ( added, records.Single ( r => r.LastName == lastName ) ) );
        }

        #endregion

    }

}
