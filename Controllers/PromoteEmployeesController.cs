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
    public class PromoteEmployeesController : Controller
    {
        private EmployeeProjectEntities db = new EmployeeProjectEntities();

        // GET: PromoteEmployees
        public ActionResult Index()
        {
            var promoteEmployees = db.PromoteEmployees.Include(p => p.Dtable).Include(p => p.Dtable1).Include(p => p.EmployeeDetail).Include(p => p.EmployeeDetail1).Include(p => p.EmployeeDetail2).Include(p => p.Dtable2);
            return View(promoteEmployees.ToList());
        }

        // GET: PromoteEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoteEmployee promoteEmployee = db.PromoteEmployees.Find(id);
            if (promoteEmployee == null)
            {
                return HttpNotFound();
            }
            return View(promoteEmployee);
        }

        // GET: PromoteEmployees/Create
        public ActionResult Create()
        {
            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation");
            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation");
            ViewBag.AssignTo = new SelectList(db.EmployeeDetails, "ID", "Firstname");
            ViewBag.NewSupervisor = new SelectList(db.EmployeeDetails, "ID", "Firstname");
            ViewBag.SelectEmployee = new SelectList(db.EmployeeDetails, "ID", "Firstname");
            ViewBag.NewDesignation1 = new SelectList(db.Dtables, "ID", "Designation");
            return View();
        }

        // POST: PromoteEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Designation,NewDesignation,Salary,SelectEmployee,AssignTo,NewSupervisor,NewDesignation1")] PromoteEmployee promoteEmployee)
        {
            if (ModelState.IsValid)
            {
                db.PromoteEmployees.Add(promoteEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation", promoteEmployee.Designation);
            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation", promoteEmployee.Designation);
            ViewBag.AssignTo = new SelectList(db.EmployeeDetails, "ID", "Firstname", promoteEmployee.AssignTo);
            ViewBag.NewSupervisor = new SelectList(db.EmployeeDetails, "ID", "Firstname", promoteEmployee.NewSupervisor);
            ViewBag.SelectEmployee = new SelectList(db.EmployeeDetails, "ID", "Firstname", promoteEmployee.SelectEmployee);
            ViewBag.NewDesignation1 = new SelectList(db.Dtables, "ID", "Designation", promoteEmployee.NewDesignation1);
            return View(promoteEmployee);
        }

        // GET: PromoteEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoteEmployee promoteEmployee = db.PromoteEmployees.Find(id);
            if (promoteEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation", promoteEmployee.Designation);
            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation", promoteEmployee.Designation);
            ViewBag.AssignTo = new SelectList(db.EmployeeDetails, "ID", "Firstname", promoteEmployee.AssignTo);
            ViewBag.NewSupervisor = new SelectList(db.EmployeeDetails, "ID", "Firstname", promoteEmployee.NewSupervisor);
            ViewBag.SelectEmployee = new SelectList(db.EmployeeDetails, "ID", "Firstname", promoteEmployee.SelectEmployee);
            ViewBag.NewDesignation1 = new SelectList(db.Dtables, "ID", "Designation", promoteEmployee.NewDesignation1);
            return View(promoteEmployee);
        }

        // POST: PromoteEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Designation,NewDesignation,Salary,SelectEmployee,AssignTo,NewSupervisor,NewDesignation1")] PromoteEmployee promoteEmployee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promoteEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation", promoteEmployee.Designation);
            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation", promoteEmployee.Designation);
            ViewBag.AssignTo = new SelectList(db.EmployeeDetails, "ID", "Firstname", promoteEmployee.AssignTo);
            ViewBag.NewSupervisor = new SelectList(db.EmployeeDetails, "ID", "Firstname", promoteEmployee.NewSupervisor);
            ViewBag.SelectEmployee = new SelectList(db.EmployeeDetails, "ID", "Firstname", promoteEmployee.SelectEmployee);
            ViewBag.NewDesignation1 = new SelectList(db.Dtables, "ID", "Designation", promoteEmployee.NewDesignation1);
            return View(promoteEmployee);
        }

        // GET: PromoteEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PromoteEmployee promoteEmployee = db.PromoteEmployees.Find(id);
            if (promoteEmployee == null)
            {
                return HttpNotFound();
            }
            return View(promoteEmployee);
        }

        // POST: PromoteEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PromoteEmployee promoteEmployee = db.PromoteEmployees.Find(id);
            db.PromoteEmployees.Remove(promoteEmployee);
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
