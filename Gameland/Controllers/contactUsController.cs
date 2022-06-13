using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers
{
    public class contactUsController : Controller
    {
        // GET: contactUs
        public ActionResult contactUsPage()
        {
            return View();
        }
    }
}