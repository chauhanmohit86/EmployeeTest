using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeBusiness;
using DataAccess;

namespace EmployeeDemo.Controllers
{
    public class EmployeeController : Controller
    {
        //
        // GET: /Employee/
        EmployeeProcessor ep = new EmployeeProcessor();
        TestDemoEntities dbcontext = new TestDemoEntities();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult EmployeeDashboard()
        {
            var list = ep.GetEmployees();
            getSelectedLists();
            return View(list);
        }
                
        public ActionResult removeEmployee(EmployeeViewModel evm)
        {
            ep.removeEmployee(evm);
            return RedirectToAction("EmployeeDashboard", "Employee");
        }

        [OutputCache(Duration=1200)]
        public void getSelectedLists()
        {
            //TODO - ViewBags for Dropdowns
            ViewData["empId"] = dbcontext.Employee.Select(s => s.EmpId).ToList().Distinct().Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.ToString()
                                  }).Distinct();

            ViewData["empNames"] = dbcontext.Employee.Select(s => s.EmpName).ToList().Distinct().Select(x => 
                                  new SelectListItem() 
                                  {
                                      Text = x.ToString()
                                  }).Distinct();

            ViewData["empSalary"] = dbcontext.Employee.Select(s => s.EmpSalary).ToList().Distinct().Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.ToString()
                                  }).Distinct();

            ViewData["empCity"] = dbcontext.Employee.Select(s => s.City).ToList().Distinct().Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.ToString()
                                  }).Distinct();

            ViewData["empSex"] = dbcontext.Employee.Select(s => s.Gender).ToList().Distinct().Select(x =>
                                  new SelectListItem()
                                  {
                                      Text = x.ToString().Trim().ToUpper() == "M" ? "Male" : "Female"
                                  });
        }

        public ActionResult KnockOutDemo()
        {
            return View();
        }

        public ActionResult KnockOutObservableArray()
        {
            return View();
        }
        
    }
}
