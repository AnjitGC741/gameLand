using Gameland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers.Front_end
{
    public class forHomeGamesController : Controller
    {
        forGameLandEntities1 db = new forGameLandEntities1();
        // GET: forHomeGames
        public ActionResult game1List()
        {
            List<gamesData> all_data = db.gamesDatas.ToList();
            return PartialView(all_data);
        }
    }
}