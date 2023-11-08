using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;

namespace MvcCv.Controllers
{
    public class DefaultController : Controller
    {
        DbCvEntities db = new DbCvEntities();
        // GET: Default
        public ActionResult Index()
        {
            var degerler = db.TblAbout.ToList();

            return View(degerler);
        }

        public PartialViewResult Experience()
        {
            var experiences = db.TblExperiences.ToList();

            return PartialView(experiences);
        }
        public PartialViewResult Education() 
        { 
            var educations = db.TblEducations.ToList();

            return PartialView(educations);
        }
        public PartialViewResult Skills()
        {

            var skills = db.TblSkills.ToList();

            return PartialView(skills);
        }

        public PartialViewResult Hobby() {

            var hobbies = db.TblHobbies.ToList();

            return PartialView(hobbies);
        }

        public PartialViewResult Certificate()
        {
            var certificates = db.TblCertificates.ToList();

            return PartialView(certificates);
        }

        public PartialViewResult Contact()
        {
            return PartialView();
        }

    }

    
}