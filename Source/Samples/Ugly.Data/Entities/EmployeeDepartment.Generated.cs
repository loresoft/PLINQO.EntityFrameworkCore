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
    public partial class EmployeeDepartment
    {
        public EmployeeDepartment()
        {
        }

        public int DepartmentId { get; set; }
        public int EmployeeId { get; set; }
        public int CreatedBy { get; set; }
        public int UpdatedBy { get; set; }

        public virtual Department Department { get; set; }
        public virtual Employees Employees { get; set; }
        public virtual Employees CreatedByEmployees { get; set; }
        public virtual Employees UpdatedByEmployees { get; set; }
    }
}