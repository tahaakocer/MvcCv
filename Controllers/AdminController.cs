using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        GenericRepository<TblAdmin> repository = new GenericRepository<TblAdmin>();
        public ActionResult Index()
        {
            var list = repository.List();
            return View(list);
        }

        public ActionResult DeleteAdmin(int id) { 
            TblAdmin t = repository.Find(x=> x.ID == id);
            int count = repository.List().Count();
            if(count > 1) {
                    repository.TDelete(t);
            }
            else
            {
                TempData["ErrorMessage"] = "Silme işlemi engellendi. En az bir admin hesabı bulunmalı!";
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public ActionResult AddAdmin(TblAdmin t)
        {
         
            repository.TAdd(t);
            return RedirectToAction("Index");
        }
    }

}