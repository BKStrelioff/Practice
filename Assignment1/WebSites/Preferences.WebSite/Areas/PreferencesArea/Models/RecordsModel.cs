#region usings

using System;
using System.Collections.Generic;

using Framework.Annotations;

using Preferences.DataObjects;
using Preferences.DataObjects.Get;
using Preferences.DataObjects.Post;
using Preferences.DomainModels;

#endregion

namespace Preferences.WebSite.Areas.PreferencesArea.Models
{

    public class RecordsModel
    {

        #region non-public constructors

        static RecordsModel ( )
        {
            CurrentModel = new PreferencesModel ( );

            // Add some random records
            var generatedRecords = PreferencesModel.GenerateRandomRecords ( 10, new Random ( ), 7 );
            CurrentModel.Add ( generatedRecords );
        }

        #endregion

        #region class public properties

        [ NotNull ]
        public static PreferencesModel CurrentModel
        {
            get;
        }

        #endregion

        #region instance public methods

        [ NotNull ]
        [ ItemNotNull ]
        public IEnumerable < GetPersonColorPreferenceModelDto > ByBirthDate ( )
        {
            var result = CurrentModel.ByBirthDate ( ).To < GetPersonColorPreferenceModelDto > ( );

            return result;
        }

        [ NotNull ]
        [ ItemNotNull ]
        public IEnumerable < GetPersonColorPreferenceModelDto > ByGender ( )
        {
            var result = CurrentModel.ByGenderLastName ( ).To < GetPersonColorPreferenceModelDto > ( );

            return result;
        }

        [ NotNull ]
        [ ItemNotNull ]
        public IEnumerable < GetPersonColorPreferenceModelDto > ByIndex ( )
        {
            var result = CurrentModel.PersonColorPreferences.To < GetPersonColorPreferenceModelDto > ( );

            return result;
        }

        [ NotNull ]
        [ ItemNotNull ]
        public IEnumerable < GetPersonColorPreferenceModelDto > ByLastNameDescending ( )
        {
            var result = CurrentModel.ByLastNameDescending ( ).To < GetPersonColorPreferenceModelDto > ( );

            return result;
        }

        [ NotNull ]
        [ ItemNotNull ]
        public IEnumerable < GetPersonColorPreferenceModelDto > ByName ( )
        {
            var result = CurrentModel.ByName ( ).To < GetPersonColorPreferenceModelDto > ( );

            return result;
        }

        public void Create ( [ NotNull ] PostPersonColorPreferenceModelDto dto )
        {
            var record = dto.To < PersonColorPreferenceModel > ( );

            CurrentModel.Add ( record );
        }

        #endregion

    }

}
