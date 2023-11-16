using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class HobbyController : Controller
    {
        // GET: Hobby
        HobbyRepository repo = new HobbyRepository();

        [HttpGet]
        public ActionResult Index()
        {
            var hobbies = repo.List();
            return View(hobbies);
        }

        [HttpPost]
        public ActionResult Index(TblHobbies p) {

            var t = repo.Find(x => x.ID == 1);
            t.Description1 = p.Description1;
            t.Description2 = p.Description2;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}