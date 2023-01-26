using Gameland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers
{
    public class forSeriesController : Controller
    {
        forGameLandEntities1 db = new forGameLandEntities1();
        // GET: forSeries
        public ActionResult seriesList()
        {
            List<seriesData> all_data = db.seriesDatas.ToList();
            return PartialView(all_data);
        }
        public ActionResult seriesPage()
        {
            List<seriesData> all_data = db.seriesDatas.ToList();
            return PartialView(all_data);
        }
        public ActionResult Search(string name1)
        {
            var data1 = db.seriesDatas.Where(x => x.seriesName == name1).ToList();
            return View("seriesPage", data1);
        }
        public ActionResult Sort(string name2)
        {
            var data1 = db.seriesDatas.Where(x => x.seriesType == name2).ToList();
            return View("seriesPage", data1);
        }
    }
}