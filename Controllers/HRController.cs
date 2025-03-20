using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;

namespace EmpProject.Controllers
{
    public class HRController : Controller
    {
        private EmployeeProjectEntities db = new EmployeeProjectEntities();

        //GET: HR


        //public ActionResult Index(int? page)
        //{
        //    // Assuming the logged-in employee's email is stored in the session
        //    string loggedInEmail = Session["UserEmail"]?.ToString();

        //    // Fetch the employee details from the database based on the logged-in email
        //    var employee = db.EmployeeDetails.FirstOrDefault(e => e.Email == loggedInEmail);

        //    // Store the employee name in ViewBag to display in the navigation bar
        //    if (employee != null)
        //    {
        //        ViewBag.EmployeeName = employee.Firstname + " " + employee.Lastname;
        //    }
        //    else
        //    {
        //        ViewBag.EmployeeName = "Employee"; // Default if not found
        //    }


        //    int pageSize = 6; // Display 6 records per page
        //    int pageNumber = (page ?? 1); // Default to page 1 if not specified


        //    List<EmployeeDetail> employees = db.EmployeeDetails.ToList(); // Fetch employee details

        //    IPagedList<EmployeeDetail> pagedEmployees = employees.ToPagedList(pageNumber, pageSize);

        //    return View(pagedEmployees);  // Pass PagedList to the View


        //}

        public ActionResult Index(int? page)
        {
            //// ✅ Ensure session value exists before proceeding
            //if (Session["UserEmail"] == null)
            //{
            //    return RedirectToAction("Login", "Account"); // Redirect if not logged in
            //}

            //string loggedInEmail = Session["UserEmail"].ToString();

            //// ✅ Fetch the employee details based on the email
            //var employee = db.EmployeeDetails
            //                 .FirstOrDefault(e => e.Email.Trim().ToLower() == loggedInEmail.Trim().ToLower());

            //// ✅ Store the full name in ViewBag for the navbar
            //ViewBag.EmployeeName = employee != null ? $"{employee.Firstname} {employee.Lastname}" : "Unknown User";


            ViewBag.FirstName = Session["UserName"];  // Assuming Session["UserName"] stores the first name



            // ✅ Pagination logic
            int pageSize = 6;
            int pageNumber = (page ?? 1);

            IPagedList<EmployeeDetail> pagedEmployees = db.EmployeeDetails.ToList().ToPagedList(pageNumber, pageSize);

            return View(pagedEmployees);
        }



    }
}
