using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Utils;
using BCRABusiness.Models;
using GeocodingService;

namespace DataAccess
{
    public class EmployeeService
    {
        private static List<EmployeeWithGeocodingData> _employees;
        public EmployeeService()
        {
            _employees = Initializer.SeedEmployees();
        }
        public List<EmployeeWithGeocodingData> GetEmployees()
        {
            return _employees;
        }
        public EmployeeWithGeocodingData GetEmployee(int Id)
        {
            EmployeeWithGeocodingData employee;
            try
            {
                employee = _employees.Single(e => e.ID == Id);
            }
            catch (Exception ex)
            {
                throw new Exception("No EmployeeWithGeocodingData matches the given Id", ex);
            }
            return employee;
        }
        public async Task<EmployeeWithGeocodingData> SaveEmployee(EmployeeWithGeocodingData employee)
        {
            EmployeeWithGeocodingData existingEmployee = _employees.SingleOrDefault(e => e.ID == employee.ID);
            try
            {
                (double latitude, double longitude) = await Geocoding.FowardGeocoding(employee.Address, employee.City).ConfigureAwait(false);
                employee.Latitude = latitude;
                employee.Longitude = longitude;
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to get geocoding data", ex);
            }
            if (existingEmployee != null)
                throw new Exception("An employee with the given id already exists.");
            _employees.Add(employee);
            EmployeeWithGeocodingData newEmployee = _employees.Single(e => e.ID == employee.ID); ;
            return employee;
        }
        public void DeleteEmployees()
        {
            _employees.Clear();
        }
        public EmployeeWithGeocodingData DeleteEmployee(int Id)
        {
            EmployeeWithGeocodingData deletedEmployee;
            try
            {
                deletedEmployee = _employees.Single(e => e.ID == Id);
                _employees.Remove(deletedEmployee);
            }
            catch (Exception ex)
            {
                throw new Exception("No EmployeeWithGeocodingData matches the given Id", ex);
            }
            return deletedEmployee;
        }

        public EmployeeWithGeocodingData UpdateEmployee(int Id, EmployeeWithGeocodingData employee)
        {
            EmployeeWithGeocodingData employeeToUpdate;
            try
            {
                employeeToUpdate = _employees.Single(e => e.ID == Id);
                employeeToUpdate = employee;
            }
            catch (Exception ex)
            {
                throw new Exception("No EmployeeWithGeocodingData matches the given Id", ex);
            }
            return employee;
        }
    }
}