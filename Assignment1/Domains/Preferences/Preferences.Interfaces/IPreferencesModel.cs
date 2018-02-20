#region usings

using System.Collections.Generic;
using System.IO;

using Framework.Annotations;

#endregion

namespace Preferences.Interfaces
{

    /// <summary>
    ///     Interface IPreferencesModel
    /// </summary>
    public interface IPreferencesModel
    {

        #region instance public methods

        /// <summary>
        ///     Adds the specified modifiable.
        /// </summary>
        /// <param name="modifiable">The modifiable.</param>
        /// <returns>IPersonColorPreferenceModel.</returns>
        int Add ( [ NotNull ] IPersonColorPreferenceModel modifiable );

        /// <summary>
        ///     Adds the specified lines.
        /// </summary>
        /// <param name="lines">The lines.</param>
        /// <param name="delimiter">The delimiter.</param>
        void Add ( [ NotNull ] [ ItemNotNull ] IEnumerable < string > lines, char delimiter );

        /// <summary>
        ///     Adds the specified lines.
        /// </summary>
        void Add ( [ NotNull ] [ ItemNotNull ] IEnumerable < IPersonColorPreferenceModel > records );

        int Add ( [ NotNull ] string line, char delimiter );

        int Add ( [ NotNull ] string line );

        [ NotNull ]
        [ ItemNotNull ]
        IEnumerable < IPersonColorPreferenceModel > ByBirthDate ( );

        [ NotNull ]
        [ ItemNotNull ]
        IEnumerable < IPersonColorPreferenceModel > ByGenderLastName ( );

        [ NotNull ]
        [ ItemNotNull ]
        IEnumerable < IPersonColorPreferenceModel > ByLastNameDescending ( );

        [ NotNull ]
        [ ItemNotNull ]
        IEnumerable < IPersonColorPreferenceModel > ByName ( );

        #endregion

        #region instance public properties and indexers

        /// <summary>
        ///     Gets the preferences.
        /// </summary>
        /// <value>The preferences.</value>
        [ NotNull ]
        [ ItemNotNull ]
        IEnumerable < IPersonColorPreferenceModel > PersonColorPreferences
        {
            get;
        }

        #endregion

    }

}
