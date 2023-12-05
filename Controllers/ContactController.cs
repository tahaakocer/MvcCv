using MvcCv.Models.Entity;
using MvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcCv.Controllers
{
    public class ContactController : Controller
    {
        // GET: Contact
        ContactRepository repo = new ContactRepository();
        public ActionResult Index()
        {
            var messages = repo.List();
            return View(messages);
        }
        public ActionResult DeleteMessage(int id) { 

            TblComm t = repo.Find(x=> x.ID == id);
            repo.TDelete(t);
            
            return RedirectToAction("Index");
        }


    }
}