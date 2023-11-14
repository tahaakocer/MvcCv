using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class EducationController : Controller
    {
        // GET: Education
        EducationRepository repo = new EducationRepository();
        public ActionResult Index()
        {
            var educations = repo.List();
            return View(educations);
        }
        [HttpGet]
        public ActionResult AddEducation() { 

            return View();
        }
        [HttpPost]
        public ActionResult AddEducation(TblEducations t) {
         
            repo.TAdd(t);
            return RedirectToAction("Index");
        }

        public ActionResult DeleteEducation(int id)
        { 
            TblEducations t = repo.Find(x=> x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetEducation(int id)
        {
            TblEducations t = repo.Find(x=> x.ID==id);
            return View(t);
        }

        [HttpPost]
        public ActionResult GetEducation(TblEducations p)
        {
            TblEducations t = repo.Find(x=> x.ID == p.ID);
            t.Head = p.Head;
            t.Subtitle1 = p.Subtitle1;
            t.Subtitle2 = p.Subtitle2;
            t.Date = p.Date;
            t.GNO = p.GNO;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
      
    }
}