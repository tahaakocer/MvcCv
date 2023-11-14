using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcCv.Models.Entity;
using MvcCv.Repositories;

namespace MvcCv.Controllers
{
    public class SkillController : Controller
    {
        // GET: Skill
       SkillRepository repo = new SkillRepository();
        public ActionResult Index()
        {
            var skills = repo.List();
            return View(skills);
        }

        [HttpGet]
        public ActionResult AddSkill() {

            return View();
        }
        [HttpPost]
        public ActionResult AddSkill(TblSkills t) {
            repo.TAdd(t);

            return RedirectToAction("Index");
        }

        public ActionResult DeleteSkill(int id)
        {
           TblSkills t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult GetSkill(int id)
        {
            TblSkills t = repo.Find(x => x.ID == id);
            return View(t);
        }
        [HttpPost]
        public ActionResult GetSkill(TblSkills p)
        {
            TblSkills t = repo.Find(x => x.ID == p.ID);
            t.Skill = p.Skill;
            t.Rate = p.Rate;
            repo.TUpdate(t);
            return RedirectToAction("Index");
        }
    }
}