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
    public class SubDeptsController : Controller
    {
        private EmployeeProjectEntities db = new EmployeeProjectEntities();

        // GET: SubDepts
        public ActionResult Index()
        {
            return View(db.SubDepts.ToList());
        }

        // GET: SubDepts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubDept subDept = db.SubDepts.Find(id);
            if (subDept == null)
            {
                return HttpNotFound();
            }
            return View(subDept);
        }

        // GET: SubDepts/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SubDepts/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SubDept subDept)
        {
            if (ModelState.IsValid)
            {
                db.SubDepts.Add(subDept);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(subDept);
        }

        // GET: SubDepts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubDept subDept = db.SubDepts.Find(id);
            if (subDept == null)
            {
                return HttpNotFound();
            }
            return View(subDept);
        }

        // POST: SubDepts/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SubDept subDept)
        {
            if (ModelState.IsValid)
            {
                db.Entry(subDept).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(subDept);
        }

        // GET: SubDepts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SubDept subDept = db.SubDepts.Find(id);
            if (subDept == null)
            {
                return HttpNotFound();
            }
            return View(subDept);
        }

        // POST: SubDepts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SubDept subDept = db.SubDepts.Find(id);
            db.SubDepts.Remove(subDept);
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
