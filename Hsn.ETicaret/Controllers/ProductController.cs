using Hsn.ETicaret;
using Hsn.ETicaret.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hsn.ETicaret.Controllers
{
    public class ProductController : HsnControllerBase
    {
        // GET: Product
        #region Methods
        [Route("Urun/{title}/{id}")]
        public ActionResult Detail(string title, int id)
        {
            var db = new HsnDb();
            var product = db.Products.Where(x => x.Id == id).FirstOrDefault();
            return View(product);
        } 
        #endregion
    }
}