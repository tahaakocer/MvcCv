using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class SocialMediaController : Controller
    {
        // GET: SocialMedia
        SocialMediaRepository repo = new SocialMediaRepository();
        public ActionResult Index()
        {
            var socialmedias = repo.List();
            return View(socialmedias);
        }
        [HttpGet]
        public ActionResult AddSocialMedia()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddSocialMedia(TblSocialMedia t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteSocialMedia(int id) { 

            TblSocialMedia t = repo.Find(x=> x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public ActionResult GetSocialMedia(int id) { 
            TblSocialMedia t = repo.Find(x=> x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult GetSocialMedia(TblSocialMedia p)
        {
            TblSocialMedia t = repo.Find(x=> x.ID==p.ID);
            t.Name = p.Name;
            t.ID = p.ID;
            t.icon = p.icon;
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }
    }
}