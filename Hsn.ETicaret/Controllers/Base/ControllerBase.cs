using Hsn.ETicaret.Core.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Hsn.ETicaret
{
    public class HsnControllerBase : Controller
    {
        //Kullanıcı Login Kontrolu sağlanır.
        public bool IsLogin { get; private set; }
        //Giriş Yapmış Kişinin Idsi.
        public int LoginUserId { get; set; }
        public User LoginUserEntity { get; private set; }
        protected override void Initialize(RequestContext requestContext)
        {
            if (requestContext.HttpContext.Session["LoginUserId"]!=null)
            {
                //Kullanıcı giriş yapmışsa 
                IsLogin = true;
                LoginUserId = (int)requestContext.HttpContext.Session["LoginUserId"];
                LoginUserEntity = (Core.Model.Entity.User)requestContext.HttpContext.Session["LoginUser"];
            }
            base.Initialize(requestContext);
        }
    }
}