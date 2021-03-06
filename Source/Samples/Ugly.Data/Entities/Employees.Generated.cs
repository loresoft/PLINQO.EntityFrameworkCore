﻿//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a CodeSmith Template.
//
//     DO NOT MODIFY contents of this file. Changes to this
//     file will be lost if the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;

namespace Ugly.Data.Entities
{
    public partial class Employees
    {
        public Employees()
        {
            CreatedByDepartments = new HashSet<Department>();
            UpdatedByDepartments = new HashSet<Department>();
            EmployeeDepartments = new HashSet<EmployeeDepartment>();
            CreatedByEmployeeDepartments = new HashSet<EmployeeDepartment>();
            UpdatedByEmployeeDepartments = new HashSet<EmployeeDepartment>();
            ManagerEmployees1 = new HashSet<Employees>();
            CreatedByEmployees1 = new HashSet<Employees>();
            UpdatedByEmployees1 = new HashSet<Employees>();
        }

        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int? ManagerId { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public virtual ICollection<Department> CreatedByDepartments { get; set; }
        public virtual ICollection<Department> UpdatedByDepartments { get; set; }
        public virtual ICollection<EmployeeDepartment> EmployeeDepartments { get; set; }
        public virtual ICollection<EmployeeDepartment> CreatedByEmployeeDepartments { get; set; }
        public virtual ICollection<EmployeeDepartment> UpdatedByEmployeeDepartments { get; set; }
        public virtual Employees ManagerEmployees { get; set; }
        public virtual ICollection<Employees> ManagerEmployees1 { get; set; }
        public virtual Employees CreatedByEmployees { get; set; }
        public virtual ICollection<Employees> CreatedByEmployees1 { get; set; }
        public virtual Employees UpdatedByEmployees { get; set; }
        public virtual ICollection<Employees> UpdatedByEmployees1 { get; set; }
    }
}