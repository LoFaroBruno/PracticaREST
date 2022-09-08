using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Utils;
using BCRABusiness.Models;

namespace DataAccess
{
    public class DAO
    {
        private static List<Employee> _employees;
        public DAO()
        {
            _employees = Initializer.SeedEmployees();
        }
        public List<Employee> GetEmployees()
        {
            return _employees;
        }
        public Employee GetEmployee(int Id)
        {
            Employee employee;
            try
            {
                employee = _employees.Single(e => e.ID == Id);
            }
            catch (Exception ex)
            {
                throw new Exception("No Employee matches the given Id", ex);
            }
            return employee;
        }
        public Employee SaveEmployee(Employee employee)
        {
            Employee existingEmployee = _employees.SingleOrDefault(e => e.ID == employee.ID);
            if(existingEmployee != null)
                throw new Exception("An employee with the given id already exists.");
            _employees.Add(employee);
            return employee;
        }
        public void DeleteEmployees()
        {
            _employees.Clear();
        }
        public Employee DeleteEmployee(int Id)
        {
            Employee deletedEmployee;
            try
            {
                deletedEmployee = _employees.Single(e => e.ID == Id);
                _employees.Remove(deletedEmployee);
            }
            catch (Exception ex)
            {
                throw new Exception("No Employee matches the given Id", ex);
            }
            return deletedEmployee;
        }

        public Employee UpdateEmployee(int Id, Employee employee)
        {
            Employee employeeToUpdate;
            try
            {
                employeeToUpdate = _employees.Single(e => e.ID == Id);
                employeeToUpdate = employee;
            }
            catch (Exception ex)
            {
                throw new Exception("No Employee matches the given Id", ex);
            }
            return employee;
        }
    }
}
