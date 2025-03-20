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
    public class TransferEmployeesController : Controller
    {
        private EmployeeProjectEntities db = new EmployeeProjectEntities();

        // GET: TransferEmployees
        public ActionResult Index()
        {
            var transferEmployees = db.TransferEmployees.Include(t => t.Client1).Include(t => t.EmployeeDetail);
            return View(transferEmployees.ToList());
        }

        // GET: TransferEmployees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransferEmployee transferEmployee = db.TransferEmployees.Find(id);
            if (transferEmployee == null)
            {
                return HttpNotFound();
            }
            return View(transferEmployee);
        }

        // GET: TransferEmployees/Create
        public ActionResult Create()
        {
            ViewBag.Client = new SelectList(db.Clients, "ID", "Client1");
            ViewBag.SelectEmployee = new SelectList(db.EmployeeDetails, "ID", "Firstname");
            return View();
        }

        // POST: TransferEmployees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TransferEmployee transferEmployee)
        {
            if (ModelState.IsValid)
            {

                // Get the employee's current salary
                var employee = db.EmployeeDetails.Find(transferEmployee.SelectEmployee);
                if (employee != null)
                {
                    // Calculate the new salary
                    decimal hikeAmount = (decimal)((employee.Salary * transferEmployee.Salary) / 100);
                    employee.Salary = (int?)(employee.Salary + hikeAmount); // Update main employee salary

                }

                db.TransferEmployees.Add(transferEmployee);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Client = new SelectList(db.Clients, "ID", "Client1", transferEmployee.Client);
            ViewBag.SelectEmployee = new SelectList(db.EmployeeDetails, "ID", "Firstname", transferEmployee.SelectEmployee);
            return View(transferEmployee);
        }

        // GET: TransferEmployees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransferEmployee transferEmployee = db.TransferEmployees.Find(id);
            if (transferEmployee == null)
            {
                return HttpNotFound();
            }
            ViewBag.Client = new SelectList(db.Clients, "ID", "Client1", transferEmployee.Client);
            ViewBag.SelectEmployee = new SelectList(db.EmployeeDetails, "ID", "Firstname", transferEmployee.SelectEmployee);
            return View(transferEmployee);
        }

        // POST: TransferEmployees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TransferEmployee transferEmployee)
        {
            if (ModelState.IsValid)
            {
                var employee = db.EmployeeDetails.Find(transferEmployee.SelectEmployee);
                if (employee != null)
                {
                    // Recalculate salary hike
                    decimal hikeAmount = (decimal)((employee.Salary * transferEmployee.Salary) / 100);
                    employee.Salary += (int?)hikeAmount; // Update the employee's salary
                }



                db.Entry(transferEmployee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Client = new SelectList(db.Clients, "ID", "Client1", transferEmployee.Client);
            ViewBag.SelectEmployee = new SelectList(db.EmployeeDetails, "ID", "Firstname", transferEmployee.SelectEmployee);
            return View(transferEmployee);
        }

        // GET: TransferEmployees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TransferEmployee transferEmployee = db.TransferEmployees.Find(id);
            if (transferEmployee == null)
            {
                return HttpNotFound();
            }
            return View(transferEmployee);
        }

        // POST: TransferEmployees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TransferEmployee transferEmployee = db.TransferEmployees.Find(id);
            db.TransferEmployees.Remove(transferEmployee);
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
