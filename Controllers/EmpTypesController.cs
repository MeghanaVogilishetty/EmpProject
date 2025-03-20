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
    public class EmpTypesController : Controller
    {
        private EmployeeProjectEntities db = new EmployeeProjectEntities();

        // GET: EmpTypes
        public ActionResult Index()
        {
            return View(db.EmpTypes.ToList());
        }

        // GET: EmpTypes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpType empType = db.EmpTypes.Find(id);
            if (empType == null)
            {
                return HttpNotFound();
            }
            return View(empType);
        }

        // GET: EmpTypes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: EmpTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,EmployeeType")] EmpType empType)
        {
            if (ModelState.IsValid)
            {
                db.EmpTypes.Add(empType);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empType);
        }

        // GET: EmpTypes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpType empType = db.EmpTypes.Find(id);
            if (empType == null)
            {
                return HttpNotFound();
            }
            return View(empType);
        }

        // POST: EmpTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,EmployeeType")] EmpType empType)
        {
            if (ModelState.IsValid)
            {
                db.Entry(empType).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(empType);
        }

        // GET: EmpTypes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmpType empType = db.EmpTypes.Find(id);
            if (empType == null)
            {
                return HttpNotFound();
            }
            return View(empType);
        }

        // POST: EmpTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmpType empType = db.EmpTypes.Find(id);
            db.EmpTypes.Remove(empType);
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
