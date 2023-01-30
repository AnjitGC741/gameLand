using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers
{
    public class Global : HttpApplication
    {
        void Session_Start(object sender, EventArgs e)
        {
            Session["userName"] = null;
        }
    }

    public class forHeaderController : Controller
    {
        // GET: forHeader
        public ActionResult header()
        { 
            return View();
        }
    }
}