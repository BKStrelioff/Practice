using System;

using Preferences.Extensions;
using Preferences.Interfaces;

namespace Preferences.DomainModels
{

    public class PersonColorPreferenceModel : IPersonColorPreferenceModel
    {

        private string _dateOfBirth;

        private string _firstName;

        private string _lastName;

        #region Implementation of IPersonColorPreferenceModel

        /// <inheritdoc />
        public int Id
        {
            get;
            set;
        }

        /// <inheritdoc />
        public string DateOfBirth
        {
            get
            {
                return _dateOfBirth;
            }
            set
            {
                _dateOfBirth = value;
                DateTimeBirth = _dateOfBirth.FromPreferenceFormat ( );
            }
        }

        /// <inheritdoc />
        public string FavoriteColor
        {
            get;
            set;
        }

        /// <inheritdoc />
        public string FirstName
        {
            get
            {
                return _firstName;
            }
            set
            {
                _firstName = value;
                FirstNameUpper = _firstName.ToUpperInvariant ( );
            }
        }

        /// <inheritdoc />
        public string Gender
        {
            get;
            set;
        }

        /// <inheritdoc />
        public string LastName
        {
            get
            {
                return _lastName;
            }
            set
            {
                _lastName = value;
                LastNameUpper = _lastName.ToUpperInvariant ( );
            }
        }

        /// <inheritdoc />
        public DateTime DateTimeBirth
        {
            get;
            set;
        }

        /// <inheritdoc />
        public string LastNameUpper
        {
            get;
            set;
        }

        /// <inheritdoc />
        public string FirstNameUpper
        {
            get;
            set;
        }

        #endregion

        #region Overrides of Object

        /// <inheritdoc />
        public override string ToString ( )
        {
            return $"[ Id: {Id}, Gender: {Gender}, First: {FirstName}, Last: {LastName}, DOB: {DateOfBirth}, FavoriteColor: {FavoriteColor} ]";
        }

        #endregion

    }

}