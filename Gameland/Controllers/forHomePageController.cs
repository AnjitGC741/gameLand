using Gameland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers
{
    public class forHomePageController : Controller
    {
        forGameLandEntities1 db = new forGameLandEntities1();
        // GET: forHomePage
        public ActionResult homePage()
        {
            Session["totalOrder"] = db.cartDatas.Count();
            return View();
        }
        public ActionResult aboutUs()
        {
         
            return View();
        }
    }
}