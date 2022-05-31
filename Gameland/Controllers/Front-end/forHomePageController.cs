using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers
{
    public class forHomePageController : Controller
    {
        // GET: forHomePage
        public ActionResult homePage()
        {
            return View();
        }
    }
}