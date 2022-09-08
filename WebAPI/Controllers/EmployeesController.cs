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
        private static EmployeeService Dao = new EmployeeService();

        // GET: Employees
        public HttpResponseMessage Get()
        {
            List<EmployeeWithGeocodingData> employees;
            try
            {
                employees = Dao.GetEmployees();
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"{Ex} {Ex.StackTrace} {Ex?.InnerException}");
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
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"{Ex} {Ex.StackTrace} {Ex?.InnerException}");
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, employee);
        }
        
        // POST: Employees
        [ValidateModel]
        public async Task<HttpResponseMessage> Post(EmployeeWithGeocodingData employee)
        {
            EmployeeWithGeocodingData savedEmployee;
            try
            {
                savedEmployee = await Dao.SaveEmployee(employee).ConfigureAwait(false);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"{Ex} {Ex.StackTrace} {Ex?.InnerException}");
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
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"{Ex} {Ex.StackTrace} {Ex?.InnerException}");
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.NoContent);
        }

        // DELETE: Employees/ID
        public HttpResponseMessage Delete(int ID)
        {
            EmployeeWithGeocodingData deletedEmployee;
            try
            {
                deletedEmployee = Dao.DeleteEmployee(ID);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"{Ex} {Ex.StackTrace} {Ex?.InnerException}");
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, deletedEmployee);
        }
        
        // PUT: Employees/ID
        [ValidateModel]
        public async Task<HttpResponseMessage> Put(int ID, EmployeeWithGeocodingData employee)
        {
            EmployeeWithGeocodingData updatedEmployee;
            try
            {
                updatedEmployee = await Dao.UpdateEmployee(ID, employee);
            }
            catch (Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"{Ex} {Ex.StackTrace} {Ex?.InnerException}");
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, updatedEmployee);
        }
    }
}