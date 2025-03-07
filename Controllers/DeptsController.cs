using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace EmpProject.Controllers
{
    public class DeptsController : Controller
    {

        private EmployeeProjectEntities db = new EmployeeProjectEntities();


        // GET: Depts
        public ActionResult Index()
        {
            var model = db.Depts.ToList();
            return View(model);
        }


        // GET: Depts/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST : Depts/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Dept department)
        {
            if (ModelState.IsValid)
            {
                db.Depts.Add(department);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(department);
        }



        // GET: Dept/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id== null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                //return RedirectToAction("Index");

            }
            Dept department = db.Depts.Find(id);
            if (department == null)
            {
                return HttpNotFound();
                //return RedirectToAction("Index");
            }
            return View(department);
        }

        // POST: Dtables/Edit/5
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Dept department)
        {
            if (ModelState.IsValid)
            {
                db.Entry(department).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(department);
        }

        // GET: Dept/Details
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dept department = db.Depts.Find(id);


            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

       // GET: Dept/Delete
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Dept department = db.Depts.Find(id);
            if (department == null)
            {
                return HttpNotFound();
            }
            return View(department);
        }

        // POST: Dept/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Dept department = db.Depts.Find(id);
            db.Depts.Remove(department);
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




    





