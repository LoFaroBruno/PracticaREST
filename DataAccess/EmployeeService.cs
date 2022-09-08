using System;
using System.Collections.Generic;
using BCRABusiness.Models;
using System.Threading.Tasks;
using System.Linq;
using GeocodingService;

namespace DataAccess
{
    public class EmployeeService
    {
        private ApplicationDbContext _context;
        public EmployeeService()
        {
            _context = new ApplicationDbContext();
        }
        public List<EmployeeWithGeocodingData> GetEmployees()
        {
            List<EmployeeWithGeocodingData> employees;
            try
            {
                employees = _context.EmployeeWithGeocodingData.ToList();
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to get employees", ex);
            }
            return employees;
        }
        public EmployeeWithGeocodingData GetEmployee(int Id)
        {
            EmployeeWithGeocodingData employee;
            try
            {
                employee = _context.EmployeeWithGeocodingData.Single(e => e.ID == Id);
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to get employee with id = {Id}", ex); ;
            }
            return employee;
        }
        public async Task<EmployeeWithGeocodingData> SaveEmployee(EmployeeWithGeocodingData employee)
        {
            try
            {
                (double latitude, double longitude) = await Geocoding.FowardGeocoding(employee.Address, employee.City).ConfigureAwait(false);
                employee.Latitude = latitude;
                employee.Longitude = longitude;
                _context.EmployeeWithGeocodingData.Add(employee);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception($"Unable to save employee {employee}", ex);
            }
            return employee;
        }
        public void DeleteEmployees()
        {
            try
            {
                _context.Database.ExecuteSqlCommand($"TRUNCATE TABLE [EmployeeWithGeocodingData]");
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception("Unable to delete employees", ex);
            }
        }
        public EmployeeWithGeocodingData DeleteEmployee(int Id)
        {
            EmployeeWithGeocodingData employeeToDelete;
            try
            {
                employeeToDelete = _context.EmployeeWithGeocodingData.SingleOrDefault(e => e.ID == Id);
                if (employeeToDelete == null)
                    throw new Exception("No employee matches the given Id");
                _context.EmployeeWithGeocodingData.Remove(employeeToDelete);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Unable to delete employee with Id {Id}", ex);
            }
            return employeeToDelete;
        }

        public async Task<EmployeeWithGeocodingData> UpdateEmployee(int Id, EmployeeWithGeocodingData employee)
        {
            try
            {
                EmployeeWithGeocodingData employeeToUpdate = _context.EmployeeWithGeocodingData.Single(e => e.ID == Id);
                if (employeeToUpdate == null)
                    throw new Exception("No employee matches the given Id");
                employeeToUpdate.FirstName = employee.FirstName;
                employeeToUpdate.LastName = employee.LastName;
                employeeToUpdate.BirthDate = employee.BirthDate;
                employeeToUpdate.Mail = employee.Mail;
                employeeToUpdate.ConfirmMail = employee.ConfirmMail;
                employeeToUpdate.Document = employee.Document;
                if(!employeeToUpdate.Address.Equals(employee.Address))
                {
                    employeeToUpdate.City = employee.City;
                    employeeToUpdate.Address = employee.Address;
                    (double latitude, double longitude) = await Geocoding.FowardGeocoding(employee.Address, employee.City).ConfigureAwait(false);
                    employee.Latitude = latitude;
                    employee.Longitude = longitude;
                }
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw new Exception($"Unable to update employee with Id = {Id}", ex);
            }
            return employee;
        }
    }
}