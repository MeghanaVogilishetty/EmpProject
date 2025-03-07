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
    public class LoginPagesController : Controller
    {
        private EmployeeProjectEntities db = new EmployeeProjectEntities();

        // GET: LoginPages
        public ActionResult Index()
        {
            return View(db.LoginPages.ToList());
        }

        // GET: LoginPages/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginPage loginPage = db.LoginPages.Find(id);
            if (loginPage == null)
            {
                return HttpNotFound();
            }
            return View(loginPage);
        }

        // GET: LoginPages/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LoginPages/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LoginPage loginPage, EmployeeDetail employeeDetail)
        {
            var user = db.LoginPages.FirstOrDefault(a => a.Username == loginPage.Username && a.Password == loginPage.Password /*&& employeeDetail.ActiveStatus==true*/);

            if (user != null)  // Ensure user exists before accessing properties
            {

                if (user.Designation == "44")
                {
                    return RedirectToAction("Index", "Manager");
                }



                else if (user.Designation == "22")
                {
                    return RedirectToAction("Index", "HR");
                }

                else
                {
                    return RedirectToAction("Index");
                }
            }


            else
            {
                // Handle invalid credentials
                ViewBag.validation = "Invalid Credentials";
                return View(loginPage);
            }

        }

        // GET: LoginPages/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginPage loginPage = db.LoginPages.Find(id);
            if (loginPage == null)
            {
                return HttpNotFound();
            }
            return View(loginPage);
        }

        // POST: LoginPages/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Username,Password,Designation")] LoginPage loginPage)
        {
            if (ModelState.IsValid)
            {
                db.Entry(loginPage).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(loginPage);
        }

        // GET: LoginPages/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LoginPage loginPage = db.LoginPages.Find(id);
            if (loginPage == null)
            {
                return HttpNotFound();
            }
            return View(loginPage);
        }

        // POST: LoginPages/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LoginPage loginPage = db.LoginPages.Find(id);
            db.LoginPages.Remove(loginPage);
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
