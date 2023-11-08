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
    }

    
}