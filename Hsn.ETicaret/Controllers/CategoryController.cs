using Hsn.ETicaret;
using Hsn.ETicaret.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hsn.ETicaret.Controllers
{
    public class CategoryController : HsnControllerBase
    {
        #region Methods
        [Route("Kategori/{isim}/{id}")]
        public ActionResult Index(string isim, int id)
        {
            var db = new HsnDb();
            var data = db.Products.Where(x => x.IsActive == true && x.CategoryId == id).ToList();
            ViewBag.category = db.Categories.Where(x => x.Id == id).FirstOrDefault();

            return View(data); 
            #endregion
        }
    }
}