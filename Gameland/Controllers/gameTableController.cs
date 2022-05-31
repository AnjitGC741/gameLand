using Gameland.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers
{
    public class gameTableController : Controller
    {
        forGameLandEntities1 db = new forGameLandEntities1();
        // GET: gameTable
        public ActionResult gameTable()
        {
            List<gamesData> all_data = db.gamesDatas.ToList();
            return View(all_data);  
        }
        public ActionResult saveData(gamesData games, HttpPostedFileBase SelectedImg)
        {
            string path = Server.MapPath("~/uploads");
            string file_name = SelectedImg.FileName;
            string new_path = path + "/" + file_name;
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            SelectedImg.SaveAs(new_path);

            games.gamesImg = "~/uploads/" + file_name;
            db.gamesDatas.Add(games);
            db.SaveChanges();
            return RedirectToAction("gameTable");
        }
        public ActionResult Delete1(string name)
        {
            gamesData data = db.gamesDatas.Find(name);
            db.gamesDatas.Remove(data);
            db.SaveChanges();
            return RedirectToAction("gameTable");
        }
    }
}