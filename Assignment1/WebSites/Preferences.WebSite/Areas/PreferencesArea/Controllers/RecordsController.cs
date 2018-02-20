#region usings

using System.Web.Mvc;

using Framework.Annotations;

using Preferences.DataObjects;
using Preferences.DataObjects.Post;
using Preferences.WebSite.Areas.PreferencesArea.Models;

#endregion

namespace Preferences.WebSite.Areas.PreferencesArea.Controllers
{

    public class RecordsController : Controller
    {

        #region public constructors

        public RecordsController ( )
        {
            MyRecordsModel = new RecordsModel ( );
        }

        #endregion

        #region instance public methods

        [ NotNull ]
        public ActionResult Birthdate ( )
        {
            var viewModel = MyRecordsModel.ByBirthDate ( );
            return View ( viewModel );
        }

        // GET: PreferencesArea/Records/Create
        [ Route ( "/records" ) ]
        public ActionResult Create ( )
        {
            return View ( );
        }

        // POST: PreferencesArea/Records/Create
        [ HttpPost ]
        [ Route ( "/records" ) ]
        public ActionResult Create ( [ NotNull ] PostPersonColorPreferenceModelDto dto )
        {
            try
            {
                MyRecordsModel.Create ( dto );

                return RedirectToAction ( "RecordsIndex" );
            }
            catch
            {
                return View ( );
            }
        }

        // GET: PreferencesArea/Records/Delete/5
        public ActionResult Delete ( int id )
        {
            return View ( );
        }

        // POST: PreferencesArea/Records/Delete/5
        [ HttpPost ]
        public ActionResult Delete ( int id, FormCollection collection )
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction ( "RecordsIndex" );
            }
            catch
            {
                return View ( );
            }
        }

        // GET: PreferencesArea/Records/Details/5
        public ActionResult Details ( int id )
        {
            return View ( );
        }

        // GET: PreferencesArea/Records/Edit/5
        public ActionResult Edit ( int id )
        {
            return View ( );
        }

        // POST: PreferencesArea/Records/Edit/5
        [ HttpPost ]
        public ActionResult Edit ( int id, FormCollection collection )
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction ( "RecordsIndex" );
            }
            catch
            {
                return View ( );
            }
        }

        // GET: PreferencesArea/Records
        [ NotNull ]
        public ActionResult Gender ( )
        {
            var viewModel = MyRecordsModel.ByGender ( );
            return View ( viewModel );
        }

        [ NotNull ]
        public ActionResult Name ( )
        {
            var viewModel = MyRecordsModel.ByName ( );
            return View ( viewModel );
        }

        // GET: PreferencesArea/Records
        [ NotNull ]
        public ActionResult RecordsIndex ( )
        {
            var viewModel = MyRecordsModel.ByIndex ( );
            return View ( viewModel );
        }

        #endregion

        #region instance non-public properties and indexers

        [ NotNull ]
        private RecordsModel MyRecordsModel
        {
            get;
        }

        #endregion

    }

}
