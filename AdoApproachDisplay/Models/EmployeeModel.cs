using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdoApproachDisplay.Models
{
    public class EmployeeModel
    {

        public int EmpID { get; set; }

        public string EmpName { get; set; }

        public string Password { get; set; }

        public string CPassword { get; set; }

        public int Salary { get; set; }

        public string Address { get; set; }
    }
}