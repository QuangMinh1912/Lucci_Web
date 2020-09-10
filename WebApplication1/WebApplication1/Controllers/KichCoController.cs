using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class KichCoController : Controller
    {
        CS4PET1Entities db = new CS4PET1Entities();
        // GET: KichCo
        public ActionResult List()
        {
            var model = db.KichCoes.ToList();
            return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(KichCo model)
        {
            if (ModelState.IsValid)
            {
                db.KichCoes.Add(model);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else
                return View(model);
        }
        public ActionResult Edit(int id)
        {
            var model = db.KichCoes.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(KichCo model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else
                return View(model);
        }
    }
}