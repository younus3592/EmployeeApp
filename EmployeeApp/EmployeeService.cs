using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeApp
{
    public class EmployeeService
    {
        EmployeesDBEntities dBEntities = new EmployeesDBEntities();

        public IList<Employee> GetEmployeesList()
        {
            return dBEntities.Employees.ToList();
        }

        public Employee SaveEmployee(Employee employee)
        {

            var savedEmployee = dBEntities.Employees.FirstOrDefault(x => x.EmployeeID == employee.EmployeeID);

            if(savedEmployee != null)
            {
                savedEmployee.EmployeeName = employee.EmployeeName;
                savedEmployee.Age = employee.Age;
                savedEmployee.Gender = employee.Gender;
                savedEmployee.Address = employee.Address;
            }
            else
            {
                dBEntities.Employees.Add(employee);
            }


            dBEntities.SaveChanges();

            return employee;
        }

        public bool DeleteEmployee(int employeeId)
        {
            try
            {
                var savedEmployee = dBEntities.Employees.FirstOrDefault(x => x.EmployeeID == employeeId);

                if (savedEmployee != null)
                {
                    dBEntities.Employees.Remove(savedEmployee);

                    dBEntities.SaveChanges();

                    return true;
                }

                return false;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Employee GetEmployeeDetails(int employeeId)
        {
            var savedEmployee = dBEntities.Employees.FirstOrDefault(x => x.EmployeeID == employeeId);

            if(savedEmployee != null)
            {
                return savedEmployee;
            }
            else
            {
                return null;
            }
        }
        public void DummyMethod()
        {

        }
    }
}