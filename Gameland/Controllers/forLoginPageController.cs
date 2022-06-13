using Gameland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers
{
    public class forLoginPageController : Controller
    {
        forGameLandEntities1 db = new forGameLandEntities1();
        // GET: forLoginPage
        public ActionResult loginPage()
        {
            Session["totalUsers"]=db.usersDatas.Count(); 
            return View();
        }
        public ActionResult check(string userName, string password)
        {
            var countUserName = db.usersDatas.Where(x => x.userName == userName);
            var countPassword = db.usersDatas.Where(x => x.password == password);
            if (countUserName.Count() == 0 || countPassword.Count() == 0)
            {
                Session["error"] = "false";
                return RedirectToAction("loginPage");
            }
            Session["userName"] = userName;

            return RedirectToAction("homePage", "forHomePage");
        }
       
    }
}