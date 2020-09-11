using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication1.Models;
namespace WebApplication1.Controllers
{
    public class GioHangController : Controller
    {
        CS4PET1Entities db = new CS4PET1Entities();
        // GET: GioHang
        public ActionResult Index()
        {
            var model = new List<GioHang>();
            if (Session["GioHang"] != null)
            {
                model = Session["GioHang"] as List<GioHang>;
            }
            return View(model);
        }

        public ActionResult Create(int productId)
        {
            var gioHang = new List<GioHang>();
            if (Session["GioHang"] != null)
            {
                gioHang = Session["GioHang"] as List<GioHang>;
            }
            // Create new item
            var model = new GioHang();
            model.SanPham = db.SanPhams.Find(productId);
            // Add to GioHang
            gioHang.Add(model);
            Session["GioHang"] = gioHang;
            return RedirectToAction("Index");
        }
    }
}