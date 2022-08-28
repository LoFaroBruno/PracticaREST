using System.Net.Http;
using System.Web.Http;
using WebAPI.Filters;
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
            catch
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"No employee matches the given parameters.");
            }
        }
        
        // POST: Employees
        [ValidateModel]
        public HttpResponseMessage Post(Employee_GeocodingInfo employee)
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
        public HttpResponseMessage Put(int ID, Employee_GeocodingInfo employee)
        {
            Employee_GeocodingInfo updatedEmployee;
            try
            {
                updatedEmployee = Dao.UpdateEmployee(ID, employee);
            }
            catch
            {
                return Request.CreateResponse(System.Net.HttpStatusCode.NotFound, $"No employee matches the given id.");
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.OK, updatedEmployee);
        }
    }
}