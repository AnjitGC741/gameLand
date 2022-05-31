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

        public ActionResult AddToCart(string productName)
        {
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
            return RedirectToAction("homePage","forHomePage");
        }
    }

}

