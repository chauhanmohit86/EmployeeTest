using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace EmployeeBusiness
{
    public class EmployeeProcessor
    {
        TestDemoEntities dbcontext = new TestDemoEntities();

        public List<EmployeeViewModel> GetEmployees()
        {
            List<EmployeeViewModel> employeeList = new List<EmployeeViewModel>();

            var emps = dbcontext.Employee.ToList();

            foreach (var emp in emps)
            {
                employeeList.Add(
                    new EmployeeViewModel { 
                        EmpId = emp.EmpId,
                        EmpName = emp.EmpName,
                        EmpSalary = emp.EmpSalary,
                        Age = emp.Age,
                        City = emp.City,
                        Gender = emp.Gender.Trim().ToUpper() == "M" ? "Male" : "Female"
                    });
            }
            return employeeList;
        }

        public void removeEmployee(EmployeeViewModel employee)
        {
            var emp = new Employee { EmpId = employee.EmpId , EmpName = employee.EmpName, EmpSalary = employee.EmpSalary };
            dbcontext.Employee.Attach(emp);
            dbcontext.Employee.Remove(emp);            
            dbcontext.SaveChanges();
        }
    }
}
