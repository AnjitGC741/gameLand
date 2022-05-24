using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers
{
    public class forProductController : Controller
    {
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
    }
}