using Gameland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers
{
    public class forGameListController : Controller
    {
        forGameLandEntities1 db = new forGameLandEntities1();
        // GET: movieList
        public ActionResult gamesPage()
        {
            List<gamesData> all_data = db.gamesDatas.ToList();
            return PartialView(all_data);
        }
        public ActionResult gamelist()
        {
            List<gamesData> all_data = db.gamesDatas.ToList();
            return PartialView(all_data);
        }
        public ActionResult Search(string name)
        {
            var data = db.gamesDatas.Where(x => x.gameName == name).ToList();
            return View("gamesPage", data);
        }
    }
}