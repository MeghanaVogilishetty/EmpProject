using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using EmpProject;

namespace EmpProject.Controllers
{
    public class ReportingManagersController : Controller
    {
        private EmployeeProjectEntities db = new EmployeeProjectEntities();

        // GET: ReportingManagers
        public ActionResult Index()
        {
            var reportingManagers = db.ReportingManagers.Include(r => r.Dtable);
            return View(reportingManagers.ToList());
        }

        // GET: ReportingManagers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportingManager reportingManager = db.ReportingManagers.Find(id);
            if (reportingManager == null)
            {
                return HttpNotFound();
            }
            return View(reportingManager);
        }

        // GET: ReportingManagers/Create
        public ActionResult Create()
        {
            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation");
            return View();
        }

        // POST: ReportingManagers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Designation")] ReportingManager reportingManager)
        {
            if (ModelState.IsValid)
            {
                db.ReportingManagers.Add(reportingManager);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation", reportingManager.Designation);
            return View(reportingManager);
        }

        // GET: ReportingManagers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportingManager reportingManager = db.ReportingManagers.Find(id);
            if (reportingManager == null)
            {
                return HttpNotFound();
            }
            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation", reportingManager.Designation);
            return View(reportingManager);
        }

        // POST: ReportingManagers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Designation")] ReportingManager reportingManager)
        {
            if (ModelState.IsValid)
            {
                db.Entry(reportingManager).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation", reportingManager.Designation);
            return View(reportingManager);
        }

        // GET: ReportingManagers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ReportingManager reportingManager = db.ReportingManagers.Find(id);
            if (reportingManager == null)
            {
                return HttpNotFound();
            }
            return View(reportingManager);
        }

        // POST: ReportingManagers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ReportingManager reportingManager = db.ReportingManagers.Find(id);
            db.ReportingManagers.Remove(reportingManager);
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
