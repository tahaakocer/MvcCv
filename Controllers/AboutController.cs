using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AboutController : Controller
    {
        AboutRepository repo = new AboutRepository();
        // GET: About
        [HttpGet]
        public ActionResult Index()
        {
            var about = repo.List();
            return View(about);
        }

        [HttpPost]
        public ActionResult Index(TblAbout p) {
            TblAbout t = repo.Find(x => x.ID == 1);
            t.Name = p.Name;
            t.Surname = p.Surname;
            t.Address = p.Address;
            t.Num = p.Num;
            t.Mail = p.Mail;
            t.Description = p.Description;
            t.Picture = p.Picture;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}