#region usings

using System;

using Framework.Annotations;

using Preferences.Extensions;
using Preferences.Interfaces;

#endregion

namespace Preferences.DomainModels
{

    public class PersonColorPreferenceModel : IPersonColorPreferenceModel
    {

        #region instance non-public fields

        [ NotNull ]
        private string _dateOfBirth;

        [ NotNull ]
        private string _firstName;

        [ NotNull ]
        private string _lastName;

        #endregion

        #region public constructors        
        /// <summary>
        /// Initializes a new instance of the <see cref="PersonColorPreferenceModel"/> class.
        /// </summary>
        public PersonColorPreferenceModel ( )
        {
            _dateOfBirth = "";
            _firstName = "";
            _lastName = "";

            DateTimeBirth = DateTime.MinValue;
            FirstNameUpper = "";
            LastNameUpper = "";

            FavoriteColor = "";
            Gender = "";
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PersonColorPreferenceModel"/> class.
        /// </summary>
        /// <param name="source">The source.</param>
        public PersonColorPreferenceModel ( [ NotNull ] IPersonColorPreferenceModel source )
        {
            _dateOfBirth = source.DateOfBirth;
            _firstName = source.FirstName;
            _lastName = source.LastName;

            DateTimeBirth = source.DateTimeBirth;
            FirstNameUpper = source.FirstNameUpper;
            LastNameUpper = source.LastNameUpper;

            FavoriteColor = source.FavoriteColor;
            Gender = source.Gender;
        }

        #endregion

        #region instance public methods

        /// <inheritdoc />
        public override string ToString ( )
        {
            return $"[ Id: {Id}, Gender: {Gender}, First: {FirstName}, Last: {LastName}, DOB: {DateOfBirth}, FavoriteColor: {FavoriteColor} ]";
        }

        #endregion

        #region instance public properties and indexers

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
                if ( ! string.IsNullOrWhiteSpace ( _dateOfBirth ) )
                {
                    DateTimeBirth = _dateOfBirth.FromPreferenceFormat ( );
                }
                else
                {
                    DateTimeBirth = DateTime.MinValue;
                }
            }
        }

        /// <inheritdoc />
        public DateTime DateTimeBirth
        {
            get;
            private set;
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
        public string FirstNameUpper
        {
            get;
            private set;
        }

        /// <inheritdoc />
        public string Gender
        {
            get;
            set;
        }

        /// <inheritdoc />
        public int Id
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
        public string LastNameUpper
        {
            get;
           private set;
        }

        #endregion

    }

}
