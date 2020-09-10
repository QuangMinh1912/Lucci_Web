using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class SanPhamController : Controller
    {
        CS4PET1Entities db = new CS4PET1Entities();
        // GET: SanPham
        public ActionResult Index()
        {
            var model = db.SanPhams.ToList();
            return View(model);
        }
        public ActionResult List()
        {
            var model = db.SanPhams.ToList();
            return View(model);
        }

        public ActionResult Create()
        {
            var list = new SelectList(db.KichCoes, "id".ToString(), "TenGoi".ToString());
            ViewBag.idKichCo = list;
            return View();
        }

        [HttpPost]
        public ActionResult Create(SanPham model)
        {
            if (ModelState.IsValid)
            {
                db.SanPhams.Add(model);
                db.SaveChanges();
                return RedirectToAction("List");
            }
            else
                return View(model);
        }
        public ActionResult Edit(int id)
        {
            var list = new SelectList(db.KichCoes, "id".ToString(), "TenGoi".ToString());
            ViewBag.idKichCo = list;
            var model = db.SanPhams.Find(id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(SanPham model)
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

        public ActionResult Delete(int id)
        {
            var model = db.SanPhams.Find(id);
            return View(model);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            SanPham model = db.SanPhams.Find(id);
            db.SanPhams.Remove(model);
            db.SaveChanges();
            return RedirectToAction("List");
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}