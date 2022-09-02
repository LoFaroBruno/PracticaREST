using System.Net.Http;
using System.Web.Http;
using WebAPI.Filters;
using DataAccess;
using BCRABusiness.Models;
using System.Threading.Tasks;
using System;

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
                return Request.CreateResponse(System.Net.HttpStatusCode.OK, Dao.GetEmployee(ID));
            }
            catch
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"No employee matches the given parameters.");
            }
        }
        
        // POST: Employees
        [ValidateModel]
        public async Task<HttpResponseMessage> Post(Employee_GeocodingInfo employee)
        {
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, await Dao.SaveEmployee(employee).ConfigureAwait(false));
        }
        
        // DELETE: Employees
        public HttpResponseMessage Delete()
        {
            try
            {
                Dao.DeleteEmployees();
            }
            catch(Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"{Ex}");
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK);
        }
        
        // DELETE: Employees/ID
        public HttpResponseMessage Delete(int ID)
        {
            Employee_GeocodingInfo deletedEmployee;
            try
            {
                deletedEmployee = Dao.DeleteEmployee(ID);
            }
            catch
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"No employee matches the given id.");
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
            catch(Exception Ex)
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"{Ex}");
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, updatedEmployee);
        }
    }
}