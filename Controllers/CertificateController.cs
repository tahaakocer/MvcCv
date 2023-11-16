using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class CertificateController : Controller
    {
        // GET: Certificate
        CertificateRepository repo = new CertificateRepository();
        public ActionResult Index()
        {
            var certificates = repo.List();
            return View(certificates);
        }
        [HttpGet]
        public ActionResult AddCertificate() {
            return View();
        }
        [HttpPost]
        public ActionResult AddCertificate(TblCertificates t)
        {
            repo.TAdd(t);
            return RedirectToAction("Index");
        }
        public ActionResult DeleteCertificate(int id)
        {
            TblCertificates t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult GetCertificate(int id) {
            TblCertificates t = repo.Find(x=> x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult GetCertificate(TblCertificates p) { 
            TblCertificates t = repo.Find(x=> x.ID == p.ID);
            t.Description = p.Description;
            t.Date = p.Date;
            repo.TUpdate(t);

            return RedirectToAction("Index");
        }
    }
}