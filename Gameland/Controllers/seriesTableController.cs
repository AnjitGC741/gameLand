using Gameland.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers
{
    public class seriesTableController : Controller
    {
        forGameLandEntities1 db = new forGameLandEntities1();
        // GET: adminPanelTable
        public ActionResult seriesTable()
        {

            List<seriesData> all_data = db.seriesDatas.ToList();
            Session["totalSeries"] = db.seriesDatas.Count();
            return View(all_data);

        }
        public ActionResult saveData(seriesData series, HttpPostedFileBase SelectedImg)
        {
            string path = Server.MapPath("~/uploads");
            string file_name = SelectedImg.FileName;
            string new_path = path + "/" + file_name;
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            SelectedImg.SaveAs(new_path);

            series.seriesImg = "~/uploads/" + file_name;
            db.seriesDatas.Add(series);
            db.SaveChanges();
            return RedirectToAction("seriesTable");
        }
        public ActionResult Delete(string name)
        {
            seriesData data = db.seriesDatas.Find(name);
            db.seriesDatas.Remove(data);
            db.SaveChanges();
            return RedirectToAction("seriesTable");
        }
        public ActionResult Edit(string name)
        {
            seriesData old_data = db.seriesDatas.Find(name);
            return View(old_data);
        }
        public ActionResult updateData(seriesData series, HttpPostedFileBase SelectedImg)
        {
            seriesData value = db.seriesDatas.Find(series.seriesName);
            value.seriesName = series.seriesName;
            value.seriesPrice = series.seriesPrice;
            value.seriesType = series.seriesType;
            value.productType = series.productType;
            string path = Server.MapPath("~/uploads");
            string file_name = SelectedImg.FileName;
            string new_path = path + "/" + file_name;
            if (Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            SelectedImg.SaveAs(new_path);
            value.seriesImg = "~/uploads/" + file_name;

            db.Entry(value).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("seriesTable");

        }
        public ActionResult Search(string name1)
        {
            var data1 = db.seriesDatas.Where(x => x.seriesName == name1).ToList();
            return View("seriesTable", data1);
        }
    }
}