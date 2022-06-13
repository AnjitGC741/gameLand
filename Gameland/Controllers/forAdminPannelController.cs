using Gameland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers
{
    public class forAdminPannelController : Controller
    {
        forGameLandEntities1 db = new forGameLandEntities1();
        // GET: forAdminPannel
        public ActionResult dashboardPage()
        {
            List<recentlyPurchaseProduct> all_data = db.recentlyPurchaseProducts.ToList();
            var countGame = db.recentlyPurchaseProducts.Where(x => x.purchaseType == "Game");
            var countMovie = db.recentlyPurchaseProducts.Where(x => x.purchaseType == "Movie");
            var countSeries = db.recentlyPurchaseProducts.Where(x => x.purchaseType == "Series");
            var countSubscription = db.recentlyPurchaseProducts.Where(x => x.purchaseType == "Subscription");
            Session["totalMovieDownload"] = countMovie.Count();
            Session["totalGameDownload1"] = countGame.Count();
            Session["totalSeriesDownload"] = countSeries.Count();
            Session["totalSubscriptionDownload"] = countSubscription.Count();
            return View(all_data);
        }
    }
}