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
        private static DAO Dao = new DAO();

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
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, Dao.GetEmployees());
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"{ex}{ex.StackTrace}{ex?.InnerException}");
            }
        }
        
        // POST: Employees
        [ValidateModel]
        public HttpResponseMessage Post(Employee employee)
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, Dao.SaveEmployee(employee));
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
            Employee deletedEmployee;
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
        public HttpResponseMessage Put(int ID, Employee employee)
        {
            Employee updatedEmployee;
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