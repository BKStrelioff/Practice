#region usings

using System.Collections.Generic;
using System.Linq;
using System.Threading;

using Framework.Annotations;
using Framework.Extensions;

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

        #region instance public methods

        /// <inheritdoc />
        public int Add ( IPersonColorPreferenceModel modifiable )
        {
            var copy = new PersonColorPreferenceModel ( modifiable );
            var newId = Interlocked.Increment ( ref _recordsAdded );
            copy.Id = newId;

            _byId [ newId ] = copy;

            return newId;
        }

        /// <inheritdoc />
        public int Add ( string line, char delimiter )
        {
            var record = PreferencesHelpers.Parse ( line, delimiter );

            var result = Add ( record );

            return result;
        }

        /// <inheritdoc />
        public int Add ( string line )
        {
            var delimiter = PreferencesHelpers.DecideDelimiterFromLine ( line );
            var result = Add ( line, delimiter );

            return result;
        }

        /// <inheritdoc />
        public void Add ( IEnumerable < IPersonColorPreferenceModel > modifiable )
        {
            var personColorPreferenceModels = modifiable.ToSafeList ( );
            personColorPreferenceModels.ForEach ( r => Add ( r ) );
        }

        /// <inheritdoc />
        public void Add ( IEnumerable < string > lines, char delimiter )
        {
            foreach ( var line in lines )
            {
                Add ( line, delimiter );
            }
        }

        /// <inheritdoc />
        public IEnumerable < IPersonColorPreferenceModel > ByBirthDate ( )
        {
            var personColorPreferenceModels = _byId.Values.ToSafeList ( );
            var result = personColorPreferenceModels.OrderBy ( s => s.DateTimeBirth ).ToList ( );

            return result;
        }

        public IEnumerable < IPersonColorPreferenceModel > ByGenderLastName ( )
        {
            var personColorPreferenceModels = _byId.Values.ToSafeList ( );
            var result = personColorPreferenceModels.OrderBy ( r => r.Gender ).ThenBy ( r => r.LastNameUpper ).ToList ( );

            return result;
        }

        /// <inheritdoc />
        public IEnumerable < IPersonColorPreferenceModel > ByLastNameDescending ( )
        {
            var personColorPreferenceModels = _byId.Values.ToSafeList ( );
            var result = personColorPreferenceModels.OrderByDescending ( r => r.LastNameUpper ).ToList ( );

            return result;
        }

        /// <inheritdoc />
        public IEnumerable < IPersonColorPreferenceModel > ByName ( )
        {
            var personColorPreferenceModels = _byId.Values.ToSafeList ( );
            var result = personColorPreferenceModels.OrderBy ( r => r.LastNameUpper ).ThenBy ( r => r.FirstNameUpper ).ToList ( );

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
            get
            {
                return _byId.Values.ToList ( );
            }
        }

        #endregion

    }

}
