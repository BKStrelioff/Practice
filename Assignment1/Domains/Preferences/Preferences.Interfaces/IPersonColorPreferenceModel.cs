#region usings

using System;

using Framework.Annotations;

#endregion

namespace Preferences.Interfaces
{

    /// <summary>
    /// Interface IPersonColorPreferenceModel
    /// </summary>
    public interface IPersonColorPreferenceModel
    {
        int Id
        {
            get;
            set;
        }
        #region instance public properties and indexers

        [NotNull]
        string DateOfBirth
        {
            get;
            set;
        }

        [NotNull]
        string FavoriteColor
        {
            get;
            set;
        }

        [NotNull]
        string FirstName
        {
            get;
            set;
        }

        [NotNull]
        string Gender
        {
            get;
            set;
        }

        [NotNull]
        string LastName
        {
            get;
            set;
        }

        #endregion

        /// <summary>
        /// Gets or sets the date time birth.
        /// </summary>
        /// <value>The date time birth.</value>
        DateTime DateTimeBirth
        {
            get;
            set;
        }

        [NotNull]
        string LastNameUpper
        {
            get;
            set;
        }

        [ NotNull ]
        string FirstNameUpper
        {
            get;
            set;
        }
    }

}
