using Gameland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers.Front_end
{
    public class forCreateAccountController : Controller
    {
        forGameLandEntities1 db = new forGameLandEntities1();
        // GET: forCreateAccount
        public ActionResult createAccountPage()
        {
            return View();
        }
        public ActionResult saveData1(string userName, string country, string gender,string email, string password)
        {
            var countUserName = db.usersDatas.Where(x => x.userName == userName);
            if (countUserName.Count() >= 1 )
            {
                Session["userNameTaken"] = "false";
                return RedirectToAction("createAccountPage");
            }
            Session["userName"] = userName;
            usersData value = new usersData();
            value.userName = userName;
            value.gender = gender;
            value.country = country;
            value.email = email;
            value.password = password;
            db.usersDatas.Add(value);
            db.SaveChanges();
            Session["userName"] = userName;
            return RedirectToAction("homePage", "forHomePage");

        }
    }
}
