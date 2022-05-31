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
            return View(all_data);
        }
    }
}