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
            List<Employee_GeocodingInfo> employees;
            try
            {
                employees = _context.Employee_GeocodingInfo.ToList();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employees;
        }
        public Employee_GeocodingInfo GetEmployee(int Id)
        {
            Employee_GeocodingInfo employee;
            try
            {
                employee = _context.Employee_GeocodingInfo.Single(e => e.ID == Id);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return employee;
        }
        public async Task<Employee_GeocodingInfo> SaveEmployee(Employee_GeocodingInfo employee)
        {
            try
            {
                (double latitude, double longitude) = await Geocoding.FowardGeocoding(employee.Address, employee.City).ConfigureAwait(false);
                employee.Latitude = latitude;
                employee.Longitude = longitude;
                _context.Employee_GeocodingInfo.Add(employee);
                _context.SaveChanges();
            }
            catch(Exception ex)
            {
                throw ex;
            }
            return employee;
        }
        public void DeleteEmployees()
        {
            try
            {
                _context.Database.ExecuteSqlCommand($"TRUNCATE TABLE [Employee_GeocodingInfo]");
                _context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Employee_GeocodingInfo DeleteEmployee(int Id)
        {
            Employee_GeocodingInfo employeeToDelete;
            try
            {
                employeeToDelete = _context.Employee_GeocodingInfo.Single(e => e.ID == Id);
                if(employeeToDelete == null)
                    throw new Exception("No employee matches the given Id");
                _context.Employee_GeocodingInfo.Remove(employeeToDelete);
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
            try
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