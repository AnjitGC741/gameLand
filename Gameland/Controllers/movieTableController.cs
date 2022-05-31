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
        forGameLandEntities1 db = new forGameLandEntities1();
        // GET: adminPanelTable
        public ActionResult movieTable()
        {
               
            List<moviesData> all_data = db.moviesDatas.ToList();
           Session["totalMovie"] = db.moviesDatas.Count();
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
        public ActionResult Edit(string name)
        {
          moviesData old_data = db.moviesDatas.Find(name);   
            return View(old_data);  
        }
        public ActionResult updateData(moviesData movies, HttpPostedFileBase SelectedImg)
        {
            moviesData value1 = db.moviesDatas.Find(movies.movieName);
            value1.movieName = movies.movieName;
            value1.moviePrice = movies.moviePrice;
            value1.movieType = movies.movieType;    
            value1.productType = movies.productType;
            string path = Server.MapPath("~/uploads");
            string file_name = SelectedImg.FileName;
            string new_path = path + "/" + file_name;
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            SelectedImg.SaveAs(new_path);
            value1.movieImg = "~/uploads/" + file_name;

            db.Entry(value1).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("movieTable");

        }
        public ActionResult Search(string name1)
        {
            var data1 = db.moviesDatas.Where(x => x.movieName == name1).ToList();
            return View("movieTable", data1);
        }
    }
}