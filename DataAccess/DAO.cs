using System;
using System.Collections.Generic;
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
            employee.ID = _employees[_employees.Count - 1].ID + 1;
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
                int index = _employees.FindIndex(e => e.ID == Id);
                deletedEmployee = _employees[index];
                _employees.RemoveAt(index);
            }
            //change the type of exception
            catch
            {
                throw new Exception("No Employee matches the given Id");
            }
            return deletedEmployee;
        }

        public Employee UpdateEmployee(int Id, Employee employee)
        {
            try
            {
                int index = _employees.FindIndex(e => e.ID == Id);
                employee.ID = Id;
                _employees[index] = employee;
            }
            //change the type of exception
            catch
            {
                throw new Exception("No Employee matches the given Id");
            }
            return _employees[Id];
        }
    }
}
