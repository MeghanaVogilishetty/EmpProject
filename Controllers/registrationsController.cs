using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using EmpProject;

namespace EmpProject.Controllers
{
    public class registrationsController : Controller
    {
        private EmployeeProjectEntities db = new EmployeeProjectEntities();

        // GET: registrations
        public ActionResult Index()
        {
            var registrations = db.registrations.Include(r => r.Dtable);
            return View(registrations.ToList());
        }

        // GET: registrations/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration registration = db.registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // GET: registrations/Create
        public ActionResult Create()
        {
            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation");
            return View();
        }

        // POST: registrations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(EmployeeDetail employeeDetail, LoginPage loginPage )
        {
            if (ModelState.IsValid)
            {

                db.EmployeeDetails.Add(employeeDetail);
                db.LoginPages.Add(loginPage);


                //loginPage.Designation = employeeDetail.Designation.ToString();
                //loginPage.ID = employeeDetail.ID;
                //loginPage.Username = employeeDetail.Email;
                //loginPage.Password = "Pro00" + employeeDetail.ID;
                db.SaveChanges();
                return RedirectToAction("Index");



                //db.registrations.Add(registration);
                //db.SaveChanges();
                //return RedirectToAction("Index");
            }

            //ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation", reg.Designation);
            return View();
        }

        // GET: registrations/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration registration = db.registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation", registration.Designation);
            return View(registration);
        }

        // POST: registrations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Firstname,Lastname,Username,Password,Email,Phonenumber,DateOfBirth,Address,Designation")] registration registration)
        {
            if (ModelState.IsValid)
            {
                db.Entry(registration).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation", registration.Designation);
            return View(registration);
        }

        // GET: registrations/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            registration registration = db.registrations.Find(id);
            if (registration == null)
            {
                return HttpNotFound();
            }
            return View(registration);
        }

        // POST: registrations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            registration registration = db.registrations.Find(id);
            db.registrations.Remove(registration);
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
