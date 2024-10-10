using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ASPMVCSE310.P12.Models;

namespace ASPMVCSE310.P12.Controllers
{
    public class CatalogController : Controller
    {
        // GET: Catalog
        public ActionResult Index()
        {
            QuanLySanPhamDataContext context = new QuanLySanPhamDataContext("Data Source=.;Initial Catalog=MVC;Integrated Security=True");
            List<Catalog> dsCatalog = context.Catalogs.ToList();
            return View(dsCatalog);
        }
        public ActionResult SanPhams(int cataLogId)
        {
            QuanLySanPhamDataContext context = new QuanLySanPhamDataContext("");
            List<Product> dsProduct = context.Products.Where( x => x.CatalogId == cataLogId).ToList();
            return View(dsProduct);
        }
        public ActionResult Create()
        {
            if(Request.Form.Count > 0)
            {
                string catalogCode = Request.Form["CatalogCode"];
                string catalogName = Request.Form["CatalogName"];
                QuanLySanPhamDataContext context = new QuanLySanPhamDataContext("");
                Catalog catalog = new Catalog();
                catalog.Id = context.Catalogs.ToList().Count + 1;
                catalog.CatalogCode = catalogCode;
                catalog.CatalogName = catalogName;
                context.Catalogs.InsertOnSubmit(catalog);
                context.SubmitChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id)
        {
            QuanLySanPhamDataContext context = new QuanLySanPhamDataContext("");
            Catalog catalog = context.Catalogs.FirstOrDefault(x => x.Id == id);
            if (Request.Form.Count == 0) return View(catalog);
            string catalogCode = Request.Form["CatalogCode"];
            string catalogName = Request.Form["CatalogName"];
            catalog.CatalogCode = catalogCode;
            catalog.CatalogName = catalogName;
            context.SubmitChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            QuanLySanPhamDataContext context = new QuanLySanPhamDataContext("");
            Catalog catalog = context.Catalogs.FirstOrDefault(x => x.Id == id);
            if (catalog != null)
            {
                context.Catalogs.DeleteOnSubmit(catalog); ;
                context.SubmitChanges();
            }
            return RedirectToAction("Index");
        }
    }
}