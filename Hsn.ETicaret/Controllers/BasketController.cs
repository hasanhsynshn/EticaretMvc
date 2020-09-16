using Hsn.ETicaret.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hsn.ETicaret.Controllers
{
    public class BasketController : HsnControllerBase
    {
        // GET: Basket
        #region Methods
        public JsonResult AddProduct(int productId, int quantity)
        {
            var db = new HsnDb();
            db.Baskets.Add(new Core.Model.Entity.Basket
            {
                CreateDate = DateTime.Now,
                CreateUserId = LoginUserId,
                ProductId = productId,
                Quantity = quantity,
                UserId = LoginUserId

            });
            var data = db.SaveChanges();
            return Json(data, JsonRequestBehavior.AllowGet);
        }
        [Route("Sepetim")]
        public ActionResult Index()
        {
            var db = new HsnDb();
            var data = db.Baskets.Include("Product").Where(x => x.UserId == LoginUserId).ToList();
            return View(data);
        }
        public ActionResult Delete(int id)
        {
            var db = new HsnDb();
            var delete = db.Baskets.Where(x => x.Id == id).FirstOrDefault();
            db.Baskets.Remove(delete);
            db.SaveChanges();
            return RedirectToAction("Index");
        } 
        #endregion
    }
}