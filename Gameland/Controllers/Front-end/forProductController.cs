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
        forGameLandEntities1 db = new forGameLandEntities1();
        // GET: forProduct
        public ActionResult moviePage()
        {
            List<moviesData> all_data = db.moviesDatas.ToList();
            return PartialView(all_data);
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
            Session["totalMovies"] = db.moviesDatas.Count();
            return PartialView(all_data);
        }
        public ActionResult Search(string name1)
        {
            var data1 = db.moviesDatas.Where(x => x.movieName == name1).ToList();
            return View("moviePage", data1);
        }
        public ActionResult Sort(string name2)
        {
            var data1 = db.moviesDatas.Where(x => x.movieType == name2).ToList();
            return View("moviePage", data1);
        }

    }
}