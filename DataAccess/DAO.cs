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
            return _employees[Id];
        }
        public int SaveEmployee(Employee employee)
        {
            employee.ID = _employees.Count;
            _employees.Add(employee);
            return employee.ID;
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
                deletedEmployee = _employees[Id];
                _employees.RemoveAt(Id);
            }
            //change the type of exception
            catch
            {
                throw new Exception("No Employee matches the given Id");
            }
            return deletedEmployee;
        }

        public Employee UpdateEmployee(int ID, Employee employee)
        {
            employee.ID = ID;
            try
            {
                _employees[ID] = employee;
            }
            catch
            {
                throw new Exception("No Employee matches the given Id");
            }
            return _employees[ID];
        }
    }
}
