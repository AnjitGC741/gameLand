using Gameland.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Gameland.Controllers.Front_end
{
   
    public class myCartController : Controller
    {
        forGameLandEntities1 db = new  forGameLandEntities1();
        // GET: myCart
        public ActionResult forCart()
        {
            List<cartData> all_data = db.cartDatas.ToList();
            return View(all_data);
        }

        public ActionResult AddToCartMovie(string productName)
        {
            if (Session["userName"] == null)
            {
                return RedirectToAction("loginPage", "forLoginPage");
             }
            moviesData moviesData = db.moviesDatas.Find(productName);
            cartData mycart = new cartData();
            mycart.userName = (string)Session["userName"];
            mycart.productName = moviesData.movieName;
            mycart.productImg = moviesData.movieImg;
            mycart.productType = moviesData.productType;
            mycart.price = moviesData.moviePrice;
            db.cartDatas.Add(mycart);
            db.SaveChanges();
            return RedirectToAction("forCart");
        }
        public ActionResult AddToCartGame(string productName)
        {
            if (Session["userName"] == null)
            {
                return RedirectToAction("loginPage", "forLoginPage");
            }
            gamesData gamesData = db.gamesDatas.Find(productName);
            cartData mycart = new cartData();
            mycart.userName = (string)Session["userName"];
            mycart.productName = gamesData.gameName;
            mycart.productImg = gamesData.gamesImg;
            mycart.productType = gamesData.productType;
            mycart.price = gamesData.gamePrice;

            db.cartDatas.Add(mycart);
            db.SaveChanges();
            return RedirectToAction("forCart");
        }
        public ActionResult AddToCartSeries(string productName)
        {
            if (Session["userName"] == null)
            {
                return RedirectToAction("loginPage", "forLoginPage");
            }
            seriesData seriesData = db.seriesDatas.Find(productName);
            cartData mycart = new cartData();
            mycart.userName = (string)Session["userName"];
            mycart.productName = seriesData.seriesName;
            mycart.productImg = seriesData.seriesImg;
            mycart.productType = seriesData.productType;
            mycart.price = seriesData.seriesPrice;
            db.cartDatas.Add(mycart);
            db.SaveChanges();
            return RedirectToAction("forCart");
        }
        public ActionResult MakePayment()
        {
            string username = (string)Session["userName"];
            var dataList = db.cartDatas.Where(x => x.userName == username).ToList();
            foreach (var data in dataList)
            {
                recentlyPurchaseProduct purchaseTable = new recentlyPurchaseProduct();
                purchaseTable.userName = data.userName;
                purchaseTable.purchaseName = data.productName;
                purchaseTable.purchaseImg = data.productImg;
                purchaseTable.purchaseType = data.productType;
                purchaseTable.purchasePrice = data.price;
                db.recentlyPurchaseProducts.Add(purchaseTable);
            }

            db.cartDatas.RemoveRange(dataList);
            db.SaveChanges();
            return RedirectToAction("forCart");
        }
        public ActionResult Delete1(string name)
        {
            cartData data1 = db.cartDatas.Find(name);
            db.cartDatas.Remove(data1);
            db.SaveChanges();
            return RedirectToAction("forCart");
        }
    }

}

