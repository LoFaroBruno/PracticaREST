using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using WebAPI.Filters;
using System.ComponentModel;
using DataAccess;
using BCRABusiness.Models;

namespace WebAPI.Controllers
{
    public class EmployeesController : ApiController
    {
        private static EmployeeService Dao = new EmployeeService();

        // GET: Employees
        public HttpResponseMessage Get()
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, Dao.GetEmployees());
        }

        // GET: Employees/ID
        public HttpResponseMessage Get(int ID)
        {
            try
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, Dao.GetEmployee(ID));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"{ex}{ex.StackTrace}{ex?.InnerException}");
            }
        }

        // POST: Employees
        [ValidateModel]
        public async System.Threading.Tasks.Task<HttpResponseMessage> Post(EmployeeWithGeocodingData employee)
        {
            try
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, await Dao.SaveEmployee(employee).ConfigureAwait(false));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"{ex}{ex.StackTrace}{ex?.InnerException}");
            }
        }

        // DELETE: Employees
        public HttpResponseMessage Delete()
        {
            Dao.DeleteEmployees();
            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }

        // DELETE: Employees/ID
        public HttpResponseMessage Delete(int ID)
        {
            EmployeeWithGeocodingData deletedEmployee;
            try
            {
                deletedEmployee = Dao.DeleteEmployee(ID);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"{ex}{ex.StackTrace}{ex?.InnerException}");
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, deletedEmployee);
        }

        // PUT: Employees/ID
        [ValidateModel]
        public HttpResponseMessage Put(int ID, EmployeeWithGeocodingData employee)
        {
            EmployeeWithGeocodingData updatedEmployee;
            try
            {
                updatedEmployee = Dao.UpdateEmployee(ID, employee);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"{ex}{ex.StackTrace}{ex?.InnerException}");
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, updatedEmployee);
        }
    }
}