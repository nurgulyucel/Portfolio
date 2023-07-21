using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Casgem_Portfolio.Models.Entities;

namespace Casgem_Portfolio.Controllers
{
    public class ServiceController : Controller
    {
        CasgemPortfolioEntities db = new CasgemPortfolioEntities();
        public ActionResult Index()
        {
            var values = db.TblService.ToList();
            return View(values);
        }

        [HttpGet]
        public ActionResult AddService()
        {
            //sadece sayfa yuklensin istedigim icin metot bos
            return View();
        }
        [HttpPost]
        public ActionResult AddService(TblService p)
        {
            //ekleme silme guncelleme
            db.TblService.Add(p);
            db.SaveChanges(); //degisiklikleri kaydet
            return RedirectToAction("Index"); //index sayfasına yonlendir
        }
        public ActionResult DeleteService(int id)
        {
            //ilk silincecek degeri bul
            var value = db.TblService.Find(id);
            db.TblService.Remove(value);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult UpdateService(int id)
        {
            var value = db.TblService.Find(id);
            return View(value);
        }
        [HttpPost]
        public ActionResult UpdateService(TblService p)
        {
            var value = db.TblService.Find(p.ServiceId);
            value.ServiceTitle = p.ServiceTitle;
            value.ServiceIcon = p.ServiceIcon;
            value.ServiceNumber = p.ServiceNumber;
            value.ServiceContent = p.ServiceContent;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}