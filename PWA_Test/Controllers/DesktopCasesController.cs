using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using PWA_Test.Models;


namespace PWA_Test.Controllers
{
    public class DesktopCasesController : Controller
    {
        private PWA_TestContext db = new PWA_TestContext();

        // GET: DesktopCases
        public ActionResult Index()
        {
            return View(db.DesktopCases.ToList());
        }

        // GET: DesktopCases/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesktopCases desktopCases = db.DesktopCases.Find(id);
            if (desktopCases == null)
            {
                return HttpNotFound();
            }
            return View(desktopCases);
        }

        // GET: DesktopCases/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DesktopCases/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,CaseRef,PlatformRef,Address,Postcode,EstimatedVal,LoanAmount,OriginalLTV,PropertyType,PropertyStyle,Beds,Tenure,AppointmentDate,StatusId,SurveyorId")] DesktopCases desktopCases)
        {
            if (ModelState.IsValid)
            {
                db.DesktopCases.Add(desktopCases);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(desktopCases);
        }

        // GET: DesktopCases/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesktopCases desktopCases = db.DesktopCases.Find(id);
            if (desktopCases == null)
            {
                return HttpNotFound();
            }
            return View(desktopCases);
        }

        // POST: DesktopCases/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,CaseRef,PlatformRef,Address,Postcode,EstimatedVal,LoanAmount,OriginalLTV,PropertyType,PropertyStyle,Beds,Tenure,AppointmentDate,StatusId,SurveyorId")] DesktopCases desktopCases)
        {
            if (ModelState.IsValid)
            {
                db.Entry(desktopCases).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(desktopCases);
        }

        // GET: DesktopCases/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DesktopCases desktopCases = db.DesktopCases.Find(id);
            if (desktopCases == null)
            {
                return HttpNotFound();
            }
            return View(desktopCases);
        }

        // POST: DesktopCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DesktopCases desktopCases = db.DesktopCases.Find(id);
            db.DesktopCases.Remove(desktopCases);
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
