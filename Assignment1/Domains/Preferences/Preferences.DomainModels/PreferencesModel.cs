#region usings

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

using Framework.Annotations;
using Framework.Extensions;
using Framework.Helpers;

using Preferences.Extensions;
using Preferences.Interfaces;

#endregion

namespace Preferences.DomainModels
{

    public class PreferencesModel : IPreferencesModel
    {

        #region instance non-public fields

        [ NotNull ]
        private readonly IDictionary < int, IPersonColorPreferenceModel > _byId;

        private int _recordsAdded;

        #endregion

        #region public constructors

        public PreferencesModel ( )
        {
            _byId = new Dictionary < int, IPersonColorPreferenceModel > ( );
        }

        #endregion

        #region class public methods

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

        #endregion

        #region instance public methods

        /// <inheritdoc />
        public void Add ( IPersonColorPreferenceModel modifiable )
        {
            modifiable.Id = Interlocked.Increment ( ref _recordsAdded );

            _byId [ modifiable.Id ] = modifiable;
        }

        /// <inheritdoc />
        public void Add ( IEnumerable < IPersonColorPreferenceModel > modifiable )
        {
            modifiable.ForEach ( Add );
        }

        /// <inheritdoc />
        public void Add ( IEnumerable < string > lines, char delimiter )
        {
            throw new NotImplementedException ( );
        }

        /// <inheritdoc />
        public IEnumerable < IPersonColorPreferenceModel > ByBirthDate ( )
        {
            var result = _byId.Values.OrderBy ( s => s.DateTimeBirth ).ToList ( );

            return result;
        }

        public IEnumerable < IPersonColorPreferenceModel > ByGenderLastName ( )
        {
            var result = _byId.Values.OrderBy ( r => r.Gender ).ThenBy ( r => r.LastNameUpper ).ToList ( );

            return result;
        }

        /// <inheritdoc />
        public IEnumerable < IPersonColorPreferenceModel > ByLastNameDescending ( )
        {
            var result = _byId.Values.OrderByDescending ( r => r.LastNameUpper ).ToList ( );

            return result;
        }

        /// <inheritdoc />
        public IEnumerable < IPersonColorPreferenceModel > ByName ( )
        {
            var result = _byId.Values.OrderBy ( r => r.LastNameUpper ).ThenBy ( r => r.FirstNameUpper ).ToList ( );

            return result;
        }

        /// <inheritdoc />
        public override string ToString ( )
        {
            return _byId.Count + " entries";
        }

        #endregion

        #region instance public properties and indexers

        /// <inheritdoc />
        public IEnumerable < IPersonColorPreferenceModel > PersonColorPreferences
        {
            get;
        }

        #endregion

    }

}
