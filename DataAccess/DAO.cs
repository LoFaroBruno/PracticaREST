using System;
using System.Collections.Generic;
using DataAccess.Utils;
using BCRABusiness.Models;
using System.Threading.Tasks;
using System.Linq;

namespace DataAccess
{
    public class DAO
    {
        private ApplicationDbContext _context;
        public DAO()
        {
            _context = new ApplicationDbContext();
        }
        public List<Employee_GeocodingInfo> GetEmployees()
        {
            return _context.Employee_GeocodingInfo.ToList();
        }
        public Employee_GeocodingInfo GetEmployee(int Id)
        {
            return _context.Employee_GeocodingInfo.Single(e => e.ID == Id);
        }
        public async Task<int> SaveEmployee(Employee_GeocodingInfo employee)
        {
            (double latitude, double longitude) = await Geocoding.FowardGeocoding(employee.Address, employee.City).ConfigureAwait(false);
            employee.Latitude = latitude;
            employee.Longitude = longitude;
            _context.Employee_GeocodingInfo.Add(employee);
            _context.SaveChanges();
            return employee.ID;
        }
        public void DeleteEmployees()
        {
            _context.Database.ExecuteSqlCommand($"TRUNCATE TABLE [Employee_GeocodingInfo]");
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Employee_GeocodingInfo DeleteEmployee(int Id)
        {
            Employee_GeocodingInfo employeeToDelete = _context.Employee_GeocodingInfo.Single(e => e.ID == Id);

            if(employeeToDelete == null)
            throw new Exception("No employee matches the given Id");

            _context.Employee_GeocodingInfo.Remove(employeeToDelete);
            try
            {
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employeeToDelete;
        }

        public async Task<Employee_GeocodingInfo> UpdateEmployee(int Id, Employee_GeocodingInfo employee)
        {
            Employee_GeocodingInfo employeeToUpdate = _context.Employee_GeocodingInfo.Single(e => e.ID == Id);

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
            try
            {
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return employee;
        }
    }
}