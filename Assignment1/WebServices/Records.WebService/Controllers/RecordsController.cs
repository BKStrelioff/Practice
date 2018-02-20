#region usings

using System;
using System.Collections.Generic;
using System.Web.Http;

using Framework.Annotations;

using Preferences.DataObjects.Get;
using Preferences.DataObjects.Post;

using Records.WebService.Models;

#endregion

namespace Records.WebService.Controllers
{

    public class RecordsController : ApiController
    {

        #region public constructors

        public RecordsController ( )
        {
            MyRecordsModel = new RecordsApiModel ( );
        }

        #endregion

        #region instance public methods

        [ NotNull ]
        [ ItemNotNull ]
        [ HttpGet ]
        [ Route ( "records/birthdate" ) ]
        public IEnumerable < GetPersonColorPreferenceModelDto > Birthdate ( )
        {
            var result = MyRecordsModel.ByBirthDate ( );

            return result;
        }

        // DELETE: records/5
        public void Delete ( int id )
        {
        }

        [ NotNull ]
        [ ItemNotNull ]
        [ Route ( "records/gender" ) ]
        [ HttpGet ]
        public IEnumerable < GetPersonColorPreferenceModelDto > Gender ( )
        {
            var result = MyRecordsModel.ByGender ( );

            return result;
        }

        // GET: records
        [ NotNull ]
        [ ItemNotNull ]
        [Route("records")]
        [HttpGet]
        public IEnumerable < GetPersonColorPreferenceModelDto > Get ( )
        {
            var result = MyRecordsModel.ByIndex ( );

            return result;
        }

        [ NotNull ]
        [ ItemNotNull ]
        [ Route ( "records/lastname" ) ]
        [ HttpGet ]
        public IEnumerable < GetPersonColorPreferenceModelDto > LastName ( )
        {
            var result = MyRecordsModel.ByLastNameDescending ( );

            return result;
        }

        [ NotNull ]
        [ ItemNotNull ]
        [ Route ( "records/name" ) ]
        [ HttpGet ]
        public IEnumerable < GetPersonColorPreferenceModelDto > Name ( )
        {
            var result = MyRecordsModel.ByName ( );

            return result;
        }

        //// POST: records
        //[HttpPost]
        //public int PostDto ( [ NotNull ]  PostPersonColorPreferenceModelDto dto )
        //{
        //    var result = MyRecordsModel.Create ( dto );

        //    return result;
        //}

        /// <summary>
        /// This API takes a single line that still contains the delimiter.
        /// </summary>
        /// <param name="line"></param>
        /// <returns></returns>
        /// <remarks>
        /// Since we are told the data fields do not contain the delimiter,
        /// we can determine the delimiter from scanning the line
        /// </remarks>
        [HttpPost]
        [Route("records")]
        public int PostLine([NotNull] object line)
        {
            var asString = line.ToString();
            var result = MyRecordsModel.Create(asString);

            return result;
        }

        #endregion

        #region instance non-public properties and indexers

        [ NotNull ]
        private RecordsApiModel MyRecordsModel
        {
            get;
        }

        #endregion

    }

}
