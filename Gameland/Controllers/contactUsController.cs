using Gameland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers
{
    public class contactUsController : Controller
    {
        forGameLandEntities1 db = new forGameLandEntities1();
        // GET: contactUs
        public ActionResult contactUsPage()
        {
            return View();
        }
        public ActionResult saveMessage(messageBoxData1 msg)
        {
            db.messageBoxData1.Add(msg);
            db.SaveChanges();   
            return RedirectToAction("contactUsPage");
        }
    }
}