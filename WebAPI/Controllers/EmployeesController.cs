using System.Net.Http;
using System.Web.Http;
using WebAPI.Filters;
using DataAccess;
using BCRABusiness.Models;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;

namespace WebAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        private static DAO Dao = new DAO();

        // GET: Employees
        public HttpResponseMessage Get()
        {
            List<Employee_GeocodingInfo> employees;
            try
            {
                employees = Dao.GetEmployees();
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"{Ex} {Ex.InnerException}");
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, employees);
        }

        // GET: Employees/ID
        public HttpResponseMessage Get(int ID)
        {
            Employee employee;
            try
            {
                employee = Dao.GetEmployee(ID);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"{Ex} {Ex.InnerException}");
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, employee);
        }
        
        // POST: Employees
        [ValidateModel]
        public async Task<HttpResponseMessage> Post(Employee_GeocodingInfo employee)
        {
            Employee_GeocodingInfo savedEmployee;
            try
            {
                savedEmployee = await Dao.SaveEmployee(employee).ConfigureAwait(false);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"Error saving employee. {ex}");
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, savedEmployee);
        }

        // DELETE: Employees
        public HttpResponseMessage Delete()
        {
            try
            {
                Dao.DeleteEmployees();
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"{Ex} {Ex.InnerException}");
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.NoContent);
        }

        // DELETE: Employees/ID
        public HttpResponseMessage Delete(int ID)
        {
            Employee_GeocodingInfo deletedEmployee;
            try
            {
                deletedEmployee = Dao.DeleteEmployee(ID);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"{Ex} {Ex.InnerException}");
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, deletedEmployee);
        }
        
        // PUT: Employees/ID
        [ValidateModel]
        public async Task<HttpResponseMessage> Put(int ID, Employee_GeocodingInfo employee)
        {
            Employee_GeocodingInfo updatedEmployee;
            try
            {
                updatedEmployee = await Dao.UpdateEmployee(ID, employee);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"{Ex} {Ex.InnerException}");
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, updatedEmployee);
        }
    }
}