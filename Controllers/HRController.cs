using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EmpProject.Controllers
{
    public class HRController : Controller
    {
        private EmployeeProjectEntities db = new EmployeeProjectEntities();

        //GET: HR
        //public ActionResult Index()
        //{
        //    // var employeeDetails = db.EmployeeDetails
        //    //                         .Include(e => e.Dtable)
        //    //                         .Include(e => e.EmpType)
        //    //                         .Include(e => e.Dept)
        //    //                         .Include(e => e.SubDept);
        //    return View();
        //}
        public ActionResult Index()
        {
            var employeeDetails = db.EmployeeDetails.Include("Dtable").Include("EmpType").Include("Dept").Include("SubDept");
            return View(employeeDetails.ToList());
        }






    }
}
