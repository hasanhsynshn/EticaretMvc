using Hsn.ETicaret.Core.Model;
using Hsn.ETicaret.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hsn.ETicaret.Controllers
{
    public class HomeController : HsnControllerBase
    {
        #region Methods
        // GET: Home
        HsnDb db = new HsnDb();
        public ActionResult Index()
        {
            ViewBag.IsLogin = this.IsLogin;
            var data = db.Products.OrderByDescending(x => x.CreateDate).Take(5).ToList();
            return View(data);
        }
        public PartialViewResult GetMenu()
        {
            var db = new HsnDb();
            var menus = db.Categories.Where(x => x.ParentId == 0).ToList();
            return PartialView(menus);
        }
        [Route("Uye-Giris")]
        public ActionResult Login()
        {
            //OrderByDescending son eklenen ürünleri tersten sırala..
            
            return View();
        }
        [HttpPost]
        [Route("Uye-Giris")]

        public ActionResult Login(string Email,string Password)
        {
            var db = new HsnDb();
            var users = db.Users.Where(x => x.Email == Email &&
              x.Password == Password
             && x.IsActive == true &&
             x.IsAdmin == false).ToList();
            if (users.Count==1)
            {
                Session["LoginUserId"] = users.FirstOrDefault().Id;
                Session["LoginUser"] = users.FirstOrDefault();
                return Redirect("/");
            }
            else
            {
                ViewBag.Error = "Hatalı kullanıcı veya Şifre";
                return View();
            }
           
        }

        [Route("Uye-Kayit")]
        public ActionResult CreateUser()
        {
            return View();

        }
        [HttpPost]
        [Route("Uye-Kayit")]
        public ActionResult CreateUser(User entity)
        {
            try
            {
                entity.CreateDate = DateTime.Now;
                entity.CreateUserId = 1;
                entity.IsActive = true;
                entity.IsAdmin = false;
                db.Users.Add(entity);
                db.SaveChanges();
                return Redirect("/");
            }
            catch (Exception ex)
            {

                return View();
            }
       
        }
        #endregion 
    }
}