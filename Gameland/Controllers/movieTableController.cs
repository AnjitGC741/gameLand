using Gameland.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers
{
    public class movieTableController : Controller
    {
        forGameLandEntities db = new forGameLandEntities();
        // GET: adminPanelTable
        public ActionResult movieTable()
        {

            List<moviesData> all_data = db.moviesDatas.ToList();
            return View(all_data);
        }
        public ActionResult saveData(moviesData movies, HttpPostedFileBase SelectedImg)
        {
            string path = Server.MapPath("~/uploads");
            string file_name = SelectedImg.FileName;
            string new_path = path + "/" + file_name;
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            SelectedImg.SaveAs(new_path);

            movies.movieImg = "~/uploads/" + file_name;
            db.moviesDatas.Add(movies);
            db.SaveChanges();
            return RedirectToAction("movieTable");
        }
        public ActionResult Delete(string name)
        {
            moviesData data = db.moviesDatas.Find(name);
            db.moviesDatas.Remove(data);
            db.SaveChanges();
            return RedirectToAction("movieTable");
        }
        public ActionResult Edit()
        {
            return View();  
        }
    }
}