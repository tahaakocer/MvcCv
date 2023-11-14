using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ExperienceController : Controller
    {
        // GET: Experience
        ExperienceRepository repo = new ExperienceRepository();

        public ActionResult Index()
        {
            var experiences = repo.List();

            return View(experiences);
        }
        [HttpGet]
        public ActionResult AddExperience() { 

            return View(); 
        }
    
        [HttpPost]
        public ActionResult AddExperience(TblExperiences t) {
            repo.TAdd(t);
                
            return RedirectToAction("Index");
        }

        public ActionResult DeleteExperience(int id)
        {
            TblExperiences t = repo.Find(x=>x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetExperience(int id)
        {
            TblExperiences t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult GetExperience(TblExperiences p)
        {
            TblExperiences t = repo.Find(x => x.ID == p.ID);
            t.Head = p.Head;
            t.Subtitle = p.Subtitle;
            t.Date = p.Date;
            t.Description = p.Description;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}