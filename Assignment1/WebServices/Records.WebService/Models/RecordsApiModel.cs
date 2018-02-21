﻿#region usings

using System;
using System.Collections.Generic;

using Framework.Annotations;

using Preferences.DataObjects;
using Preferences.DataObjects.Get;
using Preferences.DataObjects.Post;
using Preferences.DomainModels;

#endregion

namespace Records.WebService.Models
{

    /// <summary>
    ///     Class RecordsApiModel.
    /// </summary>
    /// <autogeneratedoc />
    /// TODO Edit XML Comment Template for RecordsApiModel
    public class RecordsApiModel
    {

        #region non-public constructors

        /// <summary>
        ///     Initializes static members of the <see cref="RecordsApiModel" /> class.
        /// </summary>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for #ctor
        static RecordsApiModel ( )
        {
            CurrentModel = new PreferencesModel ( );

            // Add some random records
            var generatedRecords = PreferencesHelpers.GenerateRandomRecords ( 10, new Random ( ), 7 );
            CurrentModel.Add ( generatedRecords );
        }

        #endregion

        #region class public properties

        /// <summary>
        ///     Gets the current model.
        /// </summary>
        /// <value>The current model.</value>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for CurrentModel
        [ NotNull ]
        public static PreferencesModel CurrentModel
        {
            get;
        }

        #endregion

        #region instance public methods

        /// <summary>
        ///     Bies the birth date.
        /// </summary>
        /// <returns>IEnumerable&lt;GetPersonColorPreferenceModelDto&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ByBirthDate
        [ NotNull ]
        [ ItemNotNull ]
        public IEnumerable < GetPersonColorPreferenceModelDto > ByBirthDate ( )
        {
            var result = CurrentModel.ByBirthDate ( ).To < GetPersonColorPreferenceModelDto > ( );

            return result;
        }

        /// <summary>
        ///     Bies the gender.
        /// </summary>
        /// <returns>IEnumerable&lt;GetPersonColorPreferenceModelDto&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ByGender
        [ NotNull ]
        [ ItemNotNull ]
        public IEnumerable < GetPersonColorPreferenceModelDto > ByGender ( )
        {
            var result = CurrentModel.ByGenderLastName ( ).To < GetPersonColorPreferenceModelDto > ( );

            return result;
        }

        /// <summary>
        ///     Bies the index.
        /// </summary>
        /// <returns>IEnumerable&lt;GetPersonColorPreferenceModelDto&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ByIndex
        [ NotNull ]
        [ ItemNotNull ]
        public IEnumerable < GetPersonColorPreferenceModelDto > ByIndex ( )
        {
            var result = CurrentModel.PersonColorPreferences.To < GetPersonColorPreferenceModelDto > ( );

            return result;
        }

        /// <summary>
        ///     Bies the last name descending.
        /// </summary>
        /// <returns>IEnumerable&lt;GetPersonColorPreferenceModelDto&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ByLastNameDescending
        [ NotNull ]
        [ ItemNotNull ]
        public IEnumerable < GetPersonColorPreferenceModelDto > ByLastNameDescending ( )
        {
            var result = CurrentModel.ByLastNameDescending ( ).To < GetPersonColorPreferenceModelDto > ( );

            return result;
        }

        /// <summary>
        ///     Bies the name.
        /// </summary>
        /// <returns>IEnumerable&lt;GetPersonColorPreferenceModelDto&gt;.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for ByName
        [ NotNull ]
        [ ItemNotNull ]
        public IEnumerable < GetPersonColorPreferenceModelDto > ByName ( )
        {
            var result = CurrentModel.ByName ( ).To < GetPersonColorPreferenceModelDto > ( );

            return result;
        }

        ///// <summary>
        /////     Creates the specified dto.
        ///// </summary>
        ///// <param name="dto">The dto.</param>
        ///// <returns>System.Int32.</returns>
        ///// <autogeneratedoc />
        ///// TODO Edit XML Comment Template for Create
        //public int Create ( [ NotNull ] PostPersonColorPreferenceModelDto dto )
        //{
        //    var record = dto.To < PersonColorPreferenceModel > ( );

        //    var result = CurrentModel.Add ( record );

        //    return result;
        //}

        /// <summary>
        ///     Creates the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns>System.Int32.</returns>
        /// <autogeneratedoc />
        /// TODO Edit XML Comment Template for Create
        public int Create ( [ NotNull ] string line )
        {
            var result = CurrentModel.Add ( line );

            return result;
        }

        ///// <summary>
        /////     Creates the specified line.
        ///// </summary>
        ///// <param name="line">The line.</param>
        ///// <param name="delimiter">The delimiter.</param>
        ///// <returns>System.Int32.</returns>
        ///// <exception cref="NotImplementedException"></exception>
        ///// <autogeneratedoc />
        ///// TODO Edit XML Comment Template for Create
        //public int Create ( [ NotNull ] string line, char delimiter )
        //{
        //    throw new NotImplementedException ( );
        //}

        ///// <summary>
        /////     Posts the specified line.
        ///// </summary>
        ///// <param name="line">The line.</param>
        ///// <returns>System.Int32.</returns>
        ///// <exception cref="NotImplementedException"></exception>
        ///// <autogeneratedoc />
        ///// TODO Edit XML Comment Template for Post
        //public int Post ( [ NotNull ] string line )
        //{
        //    throw new NotImplementedException ( );
        //}

        #endregion

    }

}
