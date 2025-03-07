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
    public class EmployeeDetailsController : Controller
    {
        private EmployeeProjectEntities db = new EmployeeProjectEntities();

        // GET: EmployeeDetails
        public ActionResult Index()
        {
         
            var employeeDetails = db.EmployeeDetails.Include(e => e.Dtable).Include(e => e.EmpType).Include(e => e.Dept).Include(e => e.SubDept);
            return View(employeeDetails.ToList());
        }

        // GET: EmployeeDetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }
        

        // GET: EmployeeDetails/Create
        public ActionResult Create()
        {
            ViewBag.SubDepartment = new SelectList(db.SubDepts, "ID", "SubDepartment");
            ViewBag.Department = new SelectList(db.Depts, "ID", "Department");
            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation");
            ViewBag.EmployeeType = new SelectList(db.EmpTypes, "ID", "EmployeeType");

            return View();
        }

        // POST: EmployeeDetails/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( EmployeeDetail employeeDetail, registration reg, LoginPage loginPage)
        {
            if (ModelState.IsValid)
            {
                db.LoginPages.Add(loginPage);
                db.registrations.Add(reg);
                db.EmployeeDetails.Add(employeeDetail);

                reg.ID = employeeDetail.ID;
                reg.Password = "Pro00" + employeeDetail.ID;
                reg.Username = employeeDetail.Email;
                reg.DateOfBirth = employeeDetail.DateOfBirth;
                reg.Email = employeeDetail.Email;
                reg.Phonenumber = employeeDetail.PhoneNumber;
                reg.Address = employeeDetail.City;
                reg.Designation = employeeDetail.Designation;

                // loginPage.Designation = employeeDetail.Designation.ToString();
                //loginPage.ID = employeeDetail.ID;
                //loginPage.Username = employeeDetail.Email;
                //loginPage.Password = "Pro00" + employeeDetail.ID;


                LoginPage login = new LoginPage
                {
                    Username = employeeDetail.Email,   // Store Email as Username
                    Password = "Pro00" + employeeDetail.ID, // Store same password format
                    /*employeeDetail.ActiveStatus = true */ // Assuming new logins are active by default
                };
                db.LoginPages.Add(login);







                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubDepartment = new SelectList(db.SubDepts, "ID", "SubDepartment", employeeDetail.SubDepartment);
            ViewBag.Department = new SelectList(db.Depts, "ID", "Department", employeeDetail.Department);
            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation", employeeDetail.Designation);
            ViewBag.EmployeeType = new SelectList(db.EmpTypes, "ID", "EmployeeType", employeeDetail.EmployeeType);
            return View(employeeDetail);
        }

        // GET: EmployeeDetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            ViewBag.SubDepartment = new SelectList(db.SubDepts, "ID", "SubDepartment", employeeDetail.SubDepartment);
            ViewBag.Department = new SelectList(db.Depts, "ID", "Department", employeeDetail.Department);
            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation", employeeDetail.Designation);
            ViewBag.EmployeeType = new SelectList(db.EmpTypes, "ID", "EmployeeType", employeeDetail.EmployeeType);
            return View(employeeDetail);
        }

        // POST: EmployeeDetails/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(EmployeeDetail employeeDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(employeeDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.SubDepartment = new SelectList(db.SubDepts, "ID", "SubDepartment", employeeDetail.SubDepartment);
            ViewBag.Department = new SelectList(db.Depts, "ID", "Department", employeeDetail.Department);
            ViewBag.Designation = new SelectList(db.Dtables, "ID", "Designation", employeeDetail.Designation);
            ViewBag.EmployeeType = new SelectList(db.EmpTypes, "ID", "EmployeeType", employeeDetail.EmployeeType);
            return View(employeeDetail);
        }

        // GET: EmployeeDetails/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            if (employeeDetail == null)
            {
                return HttpNotFound();
            }
            return View(employeeDetail);
        }

        // POST: EmployeeDetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            EmployeeDetail employeeDetail = db.EmployeeDetails.Find(id);
            db.EmployeeDetails.Remove(employeeDetail);
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
