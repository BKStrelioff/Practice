#region usings

using System;
using System.Runtime.Serialization;

using Preferences.Interfaces;

#endregion

namespace Preferences.DataObjects.Get
{

    [ DataContract ]
    public class GetPersonColorPreferenceModelDto : IPersonColorPreferenceModel
    {

        #region instance public methods

        /// <inheritdoc />
        public void PopulateFrom ( IPersonColorPreferenceModel source )
        {
            DateOfBirth = source.DateOfBirth;
            FavoriteColor = source.FavoriteColor;
            FirstName = source.FirstName;
            Gender = source.Gender;
            Id = source.Id;
            LastName = source.LastName;
        }

        #endregion

        #region instance public properties and indexers

        /// <inheritdoc />
        [ DataMember ]
        public string DateOfBirth
        {
            get;
            set;
        }

        /// <inheritdoc />
        public DateTime DateTimeBirth
        {
            get;
        }

        /// <inheritdoc />
        [ DataMember ]
        public string FavoriteColor
        {
            get;
            set;
        }

        /// <inheritdoc />
        [ DataMember ]
        public string FirstName
        {
            get;
            set;
        }

        /// <inheritdoc />
        public string FirstNameUpper
        {
            get;
        }

        /// <inheritdoc />
        [ DataMember ]
        public string Gender
        {
            get;
            set;
        }

        /// <inheritdoc />
        [ DataMember ]
        public int Id
        {
            get;
            set;
        }

        /// <inheritdoc />
        [ DataMember ]
        public string LastName
        {
            get;
            set;
        }

        /// <inheritdoc />
        public string LastNameUpper
        {
            get;
        }

        #endregion

    }

}
