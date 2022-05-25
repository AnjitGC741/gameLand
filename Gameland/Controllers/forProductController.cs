using Gameland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers
{
    public class forProductController : Controller
    {
        forGameLandEntities db = new forGameLandEntities();
        // GET: forProduct
        public ActionResult gamesPage()
        {
            return View();
        }
        public ActionResult moviePage()
        {
            return View();
        }
        public ActionResult seriesPage()
        {
            return View();
        }
        public ActionResult subscriptionPage()
        {
            return View();
        }
        public ActionResult movielist()
        {
            List<moviesData> all_data = db.moviesDatas.ToList();
            return PartialView(all_data);
        }
    }
}