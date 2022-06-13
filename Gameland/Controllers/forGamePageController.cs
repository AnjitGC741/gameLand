using Gameland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers.Front_end
{
    public class forGamePageController : Controller
    {
        forGameLandEntities1 db = new forGameLandEntities1();
        // GET: forGamePage
        public ActionResult gamePage()
        {
            List<gamesData> all_data = db.gamesDatas.ToList();
            return PartialView(all_data);

        }
        public ActionResult Search(string name)
        {
            var data = db.gamesDatas.Where(x => x.gameName == name).ToList();
            return PartialView("gamePage", data);
        }
    }
}