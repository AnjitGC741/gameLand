using Gameland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers
{
    public class adminLoginPageController : Controller
    {
        forGameLandEntities1 db = new forGameLandEntities1();
        // GET: adminLoginPage
        public ActionResult loginPageForAdmin()
        {
            return View();
        }
        public ActionResult checkID(int adminId, string password)
        {
            var countId = db.adminDatas.Where(x => x.adminId == adminId);
            var countPassword = db.adminDatas.Where(x => x.password == password);
            if (countId.Count() == 0 || countPassword.Count() == 0)
            {
                Session["error1"] = "false";
                return RedirectToAction("loginPageForAdmin");
            }
            Session["totalMovies"]=db.moviesDatas.Count();
            Session["totalGames"] = db.gamesDatas.Count();
            Session["totalSeries"] = db.seriesDatas.Count();
            Session["totalSubs"] = db.subscriptionsDatas.Count();

            return RedirectToAction("dashboardPage", "forAdminPannel");
        }
    }
}