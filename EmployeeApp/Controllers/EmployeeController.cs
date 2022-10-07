using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace EmployeeApp.Controllers
{
    public class EmployeeController : Controller
    {
        EmployeeService employeeService = new EmployeeService();
        // GET: Employee
        public ActionResult EmployeeList()
        {
            

           IList<Employee> employees =  employeeService.GetEmployeesList();

            return View(employees);
        }
        [HttpPost]
        public ActionResult SaveEmployee(Employee empObj)
        {
           var employee = employeeService.SaveEmployee(empObj);

            return PartialView("_EmployeeListItem", employee);
        }
        [HttpPost]
        public JsonResult DeleteEmployee(int employeeId)
        {
          bool isDeleted =  employeeService.DeleteEmployee(employeeId);

            return Json(isDeleted, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public JsonResult GetEmployeeDetails(int employeeId)
        {
           var employee  = employeeService.GetEmployeeDetails(employeeId);

            return Json(employee, JsonRequestBehavior.AllowGet);
        }
    }
}