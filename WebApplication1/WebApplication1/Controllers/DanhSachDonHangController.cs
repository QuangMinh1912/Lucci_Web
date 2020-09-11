using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class DanhSachDonHangController : Controller
    {
        CS4PET1Entities db = new CS4PET1Entities();
        // GET: DanhSachDonHang
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult DSDonHang()
        {

            var model = db.DonHangs.ToList();
            return View(model);

        }
       public ActionResult XacnhanDonHang(int id)
        {
            var model = db.DonHangs.Find(id);
            return View(model);
        }
        public ActionResult XacnhanDonHang(GioHang model)
        {
            if (ModelState.IsValid)
            {
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DSDonHang");
            }
            else
                return View(model);
        }
        public ActionResult Create()
        {
            return View();
        }
        public ActionResult Create(DonHang model) {
            if (ModelState.IsValid)
            {
                model.NgayGio = DateTime.Now;
                model.TrangThai = "chưa xác nhận";
                db.DonHangs.Add(model);
                db.SaveChanges();

                var GioHang = Session["GioHang"] as List<GioHang>;
                foreach (var monHang in GioHang)
                {
                    var gioHang = new GioHang();
                    gioHang.id = model.id;
                    gioHang.DonGia = monHang.SanPham.DonGia;
                    gioHang.SoLuong = 1;
                    gioHang.idSanPham = monHang.SanPham.id;
                    db.GioHangs.Add(gioHang);
                }
                db.SaveChanges();
                return RedirectToAction("Index", "SanPham");
            }
            else
                return View(model);
        }
    }
}