using MvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace MvcCv.Controllers
{
    [AllowAnonymous]

    public class LoginController : Controller
    {
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(TblAdmin t)
        {
            DbCvEntities db = new DbCvEntities();
            var admin = db.TblAdmin.FirstOrDefault(x=> x.Nickname == t.Nickname && x.Password == t.Password);
            if(admin != null)
            {
                FormsAuthentication.SetAuthCookie(admin.Nickname, false);
                Session["Nickname"] = admin.Nickname.ToString();
                return RedirectToAction("Index","Experience");
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı adı veya şifre hatalı");
                return View();
            }
        }

    }
}