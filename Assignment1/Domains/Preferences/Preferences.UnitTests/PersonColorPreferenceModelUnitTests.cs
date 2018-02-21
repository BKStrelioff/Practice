#region usings

using System;

using Preferences.DomainModels;
using Preferences.Extensions;

using Xunit;

#endregion

namespace Preferences.UnitTests
{

    /// <summary>
    ///     Class PersonColorPreferenceModelUnitTests. This class cannot be inherited.
    /// </summary>
    public sealed class PersonColorPreferenceModelUnitTests
    {

        #region instance public methods

        /// <summary>
        ///     Setting DateOfBirth to empty is allowed, resets DateTimeBirth to DateTime.MinValue.
        /// </summary>
        [ Fact ]
        public void DateTimeBirthInvalidTracking ( )
        {
            var now = DateTime.Now.Date;
            var nowString = now.ToPreferenceFormat ( );
            var actual = new PersonColorPreferenceModel
            {
                DateOfBirth = nowString
            };

            Assert.Equal ( nowString, actual.DateOfBirth );
            Assert.Equal ( now, actual.DateTimeBirth );

            actual.DateOfBirth = "";
            Assert.Equal ( DateTime.MinValue, actual.DateTimeBirth );
        }

        /// <summary>
        ///     Setting DateOfBirth to valid value is allowed, resets DateTimeBirth to match new value.
        /// </summary>
        [ Fact ]
        public void DateTimeBirthValidTracking ( )
        {
            var actual = new PersonColorPreferenceModel ( );
            Assert.Equal ( DateTime.MinValue, actual.DateTimeBirth );

            var now = DateTime.Now.Date;
            actual.DateOfBirth = now.ToPreferenceFormat ( );
            Assert.Equal ( now, actual.DateTimeBirth );
        }

        /// <summary>
        ///     Test that the default constructor works.
        ///     This is to ensure that reflection based code
        ///     that requires a default constructor will not fail.
        /// </summary>
        [ Fact ]
        public void DefaultConstructor ( )
        {
            var actual = new PersonColorPreferenceModel ( );
            Assert.NotNull ( actual );
        }

        /// <summary>
        ///     Test to ensure the default Id is always 0, and not
        ///     based on number of allocations.
        /// </summary>
        [ Fact ]
        public void DefaultId ( )
        {
            var first = new PersonColorPreferenceModel ( );
            Assert.Equal ( 0, first.Id );

            var second = new PersonColorPreferenceModel ( );
            Assert.Equal ( 0, second.Id );
        }

        /// <summary>
        ///     Tests that no string property is null.
        ///     This should be reflection based and tied to use of the [NotNull] attribute.
        /// </summary>
        [ Fact ]
        public void DefaultNoNulls ( )
        {
            var actual = new PersonColorPreferenceModel ( );

            Assert.NotNull ( actual.LastName );
            Assert.NotNull ( actual.LastNameUpper );
            Assert.NotNull ( actual.FirstName );
            Assert.NotNull ( actual.FirstNameUpper );
            Assert.NotNull ( actual.FavoriteColor );
            Assert.NotNull ( actual.Gender );
            Assert.NotNull ( actual.DateOfBirth );
        }

        /// <summary>
        ///     Test that the default values are as expected.
        /// </summary>
        [ Fact ]
        public void DefaultValues ( )
        {
            var actual = new PersonColorPreferenceModel ( );

            Assert.Equal ( "", actual.LastName );
            Assert.Equal ( "", actual.LastNameUpper );
            Assert.Equal ( "", actual.FirstName );
            Assert.Equal ( "", actual.FirstNameUpper );
            Assert.Equal ( "", actual.FavoriteColor );
            Assert.Equal ( "", actual.Gender );
            Assert.Equal ( "", actual.DateOfBirth );

            Assert.Equal ( DateTime.MinValue, actual.DateTimeBirth );
        }

        /// <summary>
        ///     Test that modifying the FirstName also updates the computed
        ///     FirstNameUpper property.
        /// </summary>
        [ Fact ]
        public void FirstNameUpperTracking ( )
        {
            var actual = new PersonColorPreferenceModel ( );
            Assert.Equal ( "", actual.FirstName );
            Assert.Equal ( "", actual.FirstNameUpper );

            var firstGuid = Guid.NewGuid ( ).ToString ( );
            actual.FirstName = firstGuid;
            Assert.Equal ( firstGuid, actual.FirstName );
            Assert.Equal ( firstGuid.ToUpperInvariant ( ), actual.FirstNameUpper );

            var secondGuid = Guid.NewGuid ( ).ToString ( );
            actual.FirstName = secondGuid;
            Assert.Equal ( secondGuid, actual.FirstName );
            Assert.Equal ( secondGuid.ToUpperInvariant ( ), actual.FirstNameUpper );
        }

        /// <summary>
        ///     Test that changing the Id in one instance does not
        ///     impact subsequent instances (i.e. default is not sequence based)
        /// </summary>
        [ Fact ]
        public void IdInstance ( )
        {
            var data = Guid.NewGuid ( ).GetHashCode ( );

            var first = new PersonColorPreferenceModel ( );
            Assert.Equal ( 0, first.Id );
            first.Id = data;

            var second = new PersonColorPreferenceModel ( );
            Assert.Equal ( 0, second.Id );

            Assert.Equal ( data, first.Id );
        }

        /// <summary>
        ///     Test that modifying the LastName also updates the computed
        ///     LastNameUpper property.
        /// </summary>
        [ Fact ]
        public void LastNameUpperTracking ( )
        {
            var actual = new PersonColorPreferenceModel ( );
            Assert.Equal ( "", actual.LastName );
            Assert.Equal ( "", actual.LastNameUpper );

            var firstGuid = Guid.NewGuid ( ).ToString ( );
            actual.LastName = firstGuid;
            Assert.Equal ( firstGuid, actual.LastName );
            Assert.Equal ( firstGuid.ToUpperInvariant ( ), actual.LastNameUpper );

            var secondGuid = Guid.NewGuid ( ).ToString ( );
            actual.LastName = secondGuid;
            Assert.Equal ( secondGuid, actual.LastName );
            Assert.Equal ( secondGuid.ToUpperInvariant ( ), actual.LastNameUpper );
        }

        /// <summary>
        ///     Test that changes to values are reflected in subsequent ToString() calls.
        /// </summary>
        [ Fact ]
        public void ToStringTracking ( )
        {
            var now = DateTime.Now.Date;
            var nowString = now.ToPreferenceFormat ( );
            var favoriteColor = Guid.NewGuid ( ).ToString ( );
            var firstName = Guid.NewGuid ( ).ToString ( );
            var gender = Guid.NewGuid ( ).ToString ( );
            var lastName = Guid.NewGuid ( ).ToString ( );

            var target = new PersonColorPreferenceModel
            {
                DateOfBirth = nowString,
                FavoriteColor = favoriteColor,
                FirstName = firstName,
                Gender = gender,
                LastName = lastName
            };
            Assert.Equal ( nowString, target.DateOfBirth );
            Assert.Equal ( favoriteColor, target.FavoriteColor );
            Assert.Equal ( firstName, target.FirstName );
            Assert.Equal ( lastName, target.LastName );

            var actual = target.ToString ( );
            Assert.Contains ( nowString, actual );
            Assert.Contains ( favoriteColor, actual );
            Assert.Contains ( firstName, actual );
            Assert.Contains ( gender, actual );
            Assert.Contains ( lastName, actual );
        }

        #endregion

    }

}
