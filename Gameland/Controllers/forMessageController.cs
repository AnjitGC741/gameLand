using Gameland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers
{
    public class forMessageController : Controller
    {
        forGameLandEntities1 db = new forGameLandEntities1();
        // GET: forMessage
        public ActionResult userMessage()
        {
            List<messageBoxData1> all_data = db.messageBoxData1.ToList();
            return View(all_data);
        }
        public ActionResult Delete(int name)
        {
            messageBoxData1 data = db.messageBoxData1.Find(name);
            db.messageBoxData1.Remove(data);
            db.SaveChanges();
            return RedirectToAction("userMessage");
        }
        public ActionResult calender()
        {
            List<messageBoxData1> all_data = db.messageBoxData1.ToList();
            return View(all_data);
        }
    }
}