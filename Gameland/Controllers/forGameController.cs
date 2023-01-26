using Gameland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers
{
    public class forGameController : Controller
    {
        forGameLandEntities1 db = new forGameLandEntities1();
        // GET: forGame
        public ActionResult gameList()
        {
            List<gamesData> all_data = db.gamesDatas.ToList();
            return PartialView(all_data);
        }
        public ActionResult gamePage()
        {
            List<gamesData> all_data = db.gamesDatas.ToList();
            return PartialView(all_data);
        }
        public ActionResult Search(string name1)
        {
            var data1 = db.gamesDatas.Where(x => x.gameName == name1).ToList();
            return View("gamePage", data1);
        }
        public ActionResult Sort(string name2)
        {
            var data1 = db.gamesDatas.Where(x => x.gameType == name2).ToList();
            return View("gamePage", data1);
        }
    }
}