//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EmpProject
{
    using System;
    using System.Collections.Generic;
    
    public partial class EmployeeDetail
    {
        public int ID { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public Nullable<long> PhoneNumber { get; set; }
        public string Gender { get; set; }
        public Nullable<System.DateTime> DateOfBirth { get; set; }
        public string ReportingManager { get; set; }
        public Nullable<System.DateTime> JoiningDate { get; set; }
        public string WorkLocation { get; set; }
        public Nullable<int> Salary { get; set; }
        public Nullable<bool> ActiveStatus { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public Nullable<int> Pincode { get; set; }
        public string Country { get; set; }
        public Nullable<int> EmployeeType { get; set; }
        public Nullable<int> Designation { get; set; }
        public Nullable<int> Department { get; set; }
        public Nullable<int> SubDepartment { get; set; }
    
        public virtual Dtable Dtable { get; set; }
        public virtual EmpType EmpType { get; set; }
        public virtual Dept Dept { get; set; }
        public virtual SubDept SubDept { get; set; }
    }
}
