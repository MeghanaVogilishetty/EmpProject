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
    public class DtablesController : Controller
    {
        private EmployeeProjectEntities db = new EmployeeProjectEntities();

        // GET: Dtables
        public ActionResult Index()
        {
            return View(db.Dtables.ToList());
        }

        // GET: Dtables/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dtable dtable = db.Dtables.Find(id);
            if (dtable == null)
            {
                return HttpNotFound();
            }
            return View(dtable);
        }

        // GET: Dtables/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Dtables/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Designation")] Dtable dtable)
        {
            if (ModelState.IsValid)
            {
                db.Dtables.Add(dtable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dtable);
        }

        // GET: Dtables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dtable dtable = db.Dtables.Find(id);
            if (dtable == null)
            {
                return HttpNotFound();
            }
            return View(dtable);
        }

        // POST: Dtables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Designation")] Dtable dtable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dtable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dtable);
        }

        // GET: Dtables/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dtable dtable = db.Dtables.Find(id);
            if (dtable == null)
            {
                return HttpNotFound();
            }
            return View(dtable);
        }

        // POST: Dtables/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dtable dtable = db.Dtables.Find(id);
            db.Dtables.Remove(dtable);
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
