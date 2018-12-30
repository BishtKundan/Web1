namespace Web1.Controllers
{
    using System.Data.Entity;
    using System.Net;
    using System.Threading.Tasks;
    using System.Web.Mvc;
    using Web1.Models;

    public class VENDORsController : Controller
    {
        private mvc5Context db = new mvc5Context();

        // GET: VENDORs
        public async Task<ActionResult> Index()
        {
            return View(await db.VENDORs.ToListAsync());
        }

        // GET: VENDORs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENDOR vENDOR = await db.VENDORs.FindAsync(id);
            if (vENDOR == null)
            {
                return HttpNotFound();
            }
            return View(vENDOR);
        }

        // GET: VENDORs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VENDORs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "TRANSPORTERID,LOCCODE,COMPANY_NAME,SHORT_NAME,PREFIXTAG,ACTIVE,VALIDFROM,VALIDTILL,ADDRESS1,ADDRESS2,CITY,PHONE1,PHONE2,ZIPCODE,EMAILID,FNAME,MNAME,LNAME,MODBY,MODON,CREATEDON,EFFDT")] VENDOR vENDOR)
        {
            if (ModelState.IsValid)
            {
                db.VENDORs.Add(vENDOR);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(vENDOR);
        }

        // GET: VENDORs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENDOR vENDOR = await db.VENDORs.FindAsync(id);
            if (vENDOR == null)
            {
                return HttpNotFound();
            }
            return View(vENDOR);
        }

        // POST: VENDORs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "TRANSPORTERID,LOCCODE,COMPANY_NAME,SHORT_NAME,PREFIXTAG,ACTIVE,VALIDFROM,VALIDTILL,ADDRESS1,ADDRESS2,CITY,PHONE1,PHONE2,ZIPCODE,EMAILID,FNAME,MNAME,LNAME,MODBY,MODON,CREATEDON,EFFDT")] VENDOR vENDOR)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vENDOR).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(vENDOR);
        }

        // GET: VENDORs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VENDOR vENDOR = await db.VENDORs.FindAsync(id);
            if (vENDOR == null)
            {
                return HttpNotFound();
            }
            return View(vENDOR);
        }

        // POST: VENDORs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            VENDOR vENDOR = await db.VENDORs.FindAsync(id);
            db.VENDORs.Remove(vENDOR);
            await db.SaveChangesAsync();
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
