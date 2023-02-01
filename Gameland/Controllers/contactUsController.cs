using Gameland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers
{
    public class Global1 : HttpApplication
    {
        void Session_Start(object sender, EventArgs e)
        {
            Session["message"] = "no";
        }
    }
    public class contactUsController : Controller
    {
        forGameLandEntities1 db = new forGameLandEntities1();
        // GET: contactUs
        public ActionResult contactUsPage() {
            return View();
        }
        public ActionResult saveMessage(messageBoxData1 msg)
        {
            Session["message"] = "yes";
            db.messageBoxData1.Add(msg);
            db.SaveChanges();   
            return RedirectToAction("contactUsPage");
        }
        public ActionResult messageReceived()
        {
            Session["message"] = "no";
            return RedirectToAction("contactUsPage");
        }
    }
}