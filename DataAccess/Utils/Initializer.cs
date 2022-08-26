using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BCRABusiness.Models;

namespace DataAccess.Utils
{
    public class Initializer
    {
        public static List<Employee> SeedEmployees()
        {
            return new List<Employee>()
            {
                new Employee{  ID = 0, BirthDate = new DateTime(1960, 7, 24), Document=40113322, FirstName="Joseph ", LastName="Cooper", Mail="josephcooper@gmail.com", ConfirmMail = "josephcooper@gmail.com"},
                new Employee{  ID = 1, BirthDate = new DateTime(2002, 5, 20), Document=40224433, FirstName="Murph", LastName="Cooper", Mail="murphcooper@gmail.com", ConfirmMail = "murphcooper@gmail.com"},
                new Employee{  ID = 2, BirthDate = new DateTime(2020, 1, 1), Document=40335544, FirstName="TARS", LastName="TARS", Mail="tars@gmail.com", ConfirmMail = "tars@gmail.com"},
                new Employee{  ID = 3, BirthDate = new DateTime(1962, 2, 3), Document=40446655, FirstName="Dr. Amelia", LastName="Brand", Mail="ameliabrand@gmail.com", ConfirmMail = "ameliabrand@gmail.com"},
            };
        }
    }
}