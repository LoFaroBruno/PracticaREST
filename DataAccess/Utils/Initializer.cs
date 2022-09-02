using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BCRABusiness.Models;

namespace DataAccess.Utils
{
    static class Initializer
    {
        public static List<Employee_GeocodingInfo> SeedEmployees()
        {
            return new List<Employee_GeocodingInfo>()
            {
                new Employee_GeocodingInfo{  ID = 0, BirthDate = new DateTime(1960, 7, 24), Document=40113322,
                    FirstName="Joseph ", LastName="Cooper", Mail="josephcooper@gmail.com",
                    ConfirmMail = "josephcooper@gmail.com", City = "Buenos Aires", Address="Lima 3951" },
                new Employee_GeocodingInfo{  ID = 1, BirthDate = new DateTime(2002, 5, 20), Document=40224433,
                    FirstName="Murph", LastName="Cooper", Mail="murphcooper@gmail.com",
                    ConfirmMail = "murphcooper@gmail.com", City = "Buenos Aires", Address="Rivadavia 1864" },
                new Employee_GeocodingInfo{  ID = 2, BirthDate = new DateTime(2020, 1, 1), Document=40335544,
                    FirstName="TARS", LastName="TARS", Mail="tars@gmail.com",
                    ConfirmMail = "tars@gmail.com", City = "Buenos Aires", Address="Paraguay 2155" },
                new Employee_GeocodingInfo{  ID = 3, BirthDate = new DateTime(1962, 2, 3), Document=40446655,
                    FirstName="Dr. Amelia", LastName="Brand", Mail="ameliabrand@gmail.com",
                    ConfirmMail = "ameliabrand@gmail.com", City = "Buenos Aires", Address="Rivadavia 5510" }
            };
        }
    }
}