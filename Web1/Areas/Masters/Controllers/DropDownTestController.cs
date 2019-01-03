using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Web1.Areas.Masters.Models;

namespace Web1.Areas.Masters.Controllers
{
    public class DropDownTestController : Controller
    {
        KBDBEntities db = new KBDBEntities();
        public ActionResult Index()
        {
            var query = db.vw_vendor.Select(c => new { c.TRANSPORTERID, c.Company_name });
            ViewBag.Vendors = new SelectList(query.AsEnumerable(), "TRANSPORTERID", "Company_name");

            return View();
        }

        [HttpPost]
        public JsonResult Index(int? id)
        {
            if (id != null)
            {
                var user = db.vw_vendor.Find(id.Value);
                return Json(user);
            }
            else
            {
                return Json(new { Data = "null" });
            }
        }
        [HttpPost]
        public PartialViewResult VendorDetail(int? id)
        {
            int x = Convert.ToInt32(id);
     
            if (id != null)
            {
                var user = db.vw_vendor.Find(x);
                //var user = db.vw_vendor.Find("101");
                ViewBag.TRANSPORTERID = user.TRANSPORTERID;
                ViewBag.Company_name = user.Company_name;
            }
            return PartialView();
        }
    }
}