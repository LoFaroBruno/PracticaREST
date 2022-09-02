using System;
using System.Collections.Generic;
using DataAccess.Utils;
using BCRABusiness.Models;
using System.Threading.Tasks;

namespace DataAccess
{
    public class DAO
    {
        private static List<Employee_GeocodingInfo> _employees;
        private ApplicationDbContext _context;
        public DAO()
        {
            _employees = Initializer.SeedEmployees();
            _context = new ApplicationDbContext();
        }
        public List<Employee_GeocodingInfo> GetEmployees()
        {
            return _employees;
        }
        public Employee_GeocodingInfo GetEmployee(int Id)
        {
            return _employees[Id];
        }
        public async Task<int> SaveEmployee(Employee_GeocodingInfo employee)
        {
            (double latitude, double longitude) = await Geocoding.FowardGeocoding(employee.Address, employee.City).ConfigureAwait(false);
            employee.Latitude = latitude;
            employee.Longitude = longitude;
            employee.ID = _employees[_employees.Count - 1].ID + 1;
            _employees.Add(employee);
            _context.Employee_GeocodingInfo.Add(employee);
            _context.SaveChanges();
            return employee.ID;
        }
        public void DeleteEmployees()
        {
            _employees.Clear();
        }
        public Employee_GeocodingInfo DeleteEmployee(int Id)
        {
            Employee_GeocodingInfo deletedEmployee;
            try
            {
                int index = _employees.FindIndex(e => e.ID == Id);
                deletedEmployee = _employees[index];
                _employees.RemoveAt(index);
            }
            //change the type of exception
            catch
            {
                throw new Exception("No employee matches the given Id");
            }
            return deletedEmployee;
        }

        public Employee_GeocodingInfo UpdateEmployee(int Id, Employee_GeocodingInfo employee)
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
                throw new Exception("No employee matches the given Id");
            }
            return _employees[Id];
        }
    }
}
