using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Web1.Areas.Masters.Models;
using Web1.Models;

namespace Web1.Areas.Masters.Controllers
{
    [Authorize]
    public class VEHICLEsController : Controller
    {
        private mvc5Context db = new mvc5Context();

        // GET: Masters/VEHICLEs
        public ActionResult Index()
        {
            return View(db.VEHICLEs.ToList());
        }

        // GET: Masters/VEHICLEs/Details/5
        public ActionResult Details(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VEHICLE vEHICLE = db.VEHICLEs.Find(id);
            if (vEHICLE == null)
            {
                return HttpNotFound();
            }
            return View(vEHICLE);
        }


        private static List<SelectListItem> GetVendors()
        {
            KBDBEntities entities = new KBDBEntities();
            List<SelectListItem> VendorList = (from p in entities.vw_vendor.AsEnumerable()
                                                 select new SelectListItem
                                                 {
                                                     Text = p.Company_name,
                                                     Value = p.TRANSPORTERID.ToString()
                                                 }).ToList();


            //Add Default Item at First Position.
            VendorList.Insert(0, new SelectListItem { Text = "--Select Vendor--", Value = "" });
            return VendorList;
        }
        
        // GET: Masters/VEHICLEs/Create
        public ActionResult Create()
        {
            List<SelectListItem> Vendors = GetVendors();
            ViewBag.Vendors = Vendors;
            return View();
        }

        // POST: Masters/VEHICLEs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "vehicleid,transporterid,regno,vehicleno,vehicletypecode,bpid,dtmanufacture,active,kmlimit,createdon,modon,modby,effdt,loccode,isgpsinstalled,gps_install_date,remarks")] VEHICLE vEHICLE)
        {
            if (ModelState.IsValid)
            {
                string strDDLValue = Request.Form["ddlVendors"].ToString();
                vEHICLE.transporterid = Convert.ToInt16(strDDLValue);
                db.VEHICLEs.Add(vEHICLE);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vEHICLE);
        }

        // GET: Masters/VEHICLEs/Edit/5
        public ActionResult Edit(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VEHICLE vEHICLE = db.VEHICLEs.Find(id);
            if (vEHICLE == null)
            {
                return HttpNotFound();
            }
            return View(vEHICLE);
        }

        // POST: Masters/VEHICLEs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "vehicleid,transporterid,regno,vehicleno,vehicletypecode,bpid,dtmanufacture,active,kmlimit,createdon,modon,modby,effdt,loccode,isgpsinstalled,gps_install_date,remarks")] VEHICLE vEHICLE)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vEHICLE).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vEHICLE);
        }

        // GET: Masters/VEHICLEs/Delete/5
        public ActionResult Delete(double? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VEHICLE vEHICLE = db.VEHICLEs.Find(id);
            if (vEHICLE == null)
            {
                return HttpNotFound();
            }
            return View(vEHICLE);
        }

        // POST: Masters/VEHICLEs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(double id)
        {
            VEHICLE vEHICLE = db.VEHICLEs.Find(id);
            db.VEHICLEs.Remove(vEHICLE);
            db.SaveChanges();
            return RedirectToAction("Index");
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
