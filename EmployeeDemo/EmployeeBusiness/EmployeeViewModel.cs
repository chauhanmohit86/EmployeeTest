using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeBusiness
{
    public class EmployeeViewModel
    {
        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public Nullable<int> EmpSalary { get; set; }
        public Nullable<int> Age { get; set; }
        public string City { get; set; }
        public string Gender { get; set; }
    }
}
