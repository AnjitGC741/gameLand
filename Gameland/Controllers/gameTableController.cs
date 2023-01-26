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
        public ActionResult updateData(gamesData games, HttpPostedFileBase SelectedImg)
        {
            gamesData value1 = db.gamesDatas.Find(games.gameName);
            value1.gameName = games.gameName;
            value1.gamePrice = games.gamePrice;
            value1.gameType = games.gameType;
            value1.productType = games.productType;
            string path = Server.MapPath("~/uploads");
            string file_name = SelectedImg.FileName;
            string new_path = path + "/" + file_name;
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            SelectedImg.SaveAs(new_path);
            value1.gamesImg = "~/uploads/" + file_name;

            db.Entry(value1).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("gameTable");

        }
        public ActionResult Search(string name1)
        {
            var data1 = db.gamesDatas.Where(x => x.gameName == name1).ToList();
            return View("gameTable", data1);
        }
        public ActionResult projectDemo()
        {
            List<gamesData> all_data = db.gamesDatas.ToList();
            return View(all_data);
        }

    }
}