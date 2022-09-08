using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BCRABusiness.Models;

namespace DataAccess.Utils
{
    static class Initializer
    {
        public static List<EmployeeWithGeocodingData> SeedEmployees()
        {
            return new List<EmployeeWithGeocodingData>()
            {
                new EmployeeWithGeocodingData{  ID = 0, BirthDate = new DateTime(1960, 7, 24), Document=40113322,
                    FirstName="Joseph ", LastName="Cooper", Mail="josephcooper@gmail.com",
                    ConfirmMail = "josephcooper@gmail.com", City = "Buenos Aires", Address="Santa Fe 3951" },
                new EmployeeWithGeocodingData{  ID = 1, BirthDate = new DateTime(2002, 5, 20), Document=40224433,
                    FirstName="Murph", LastName="Cooper", Mail="murphcooper@gmail.com",
                    ConfirmMail = "murphcooper@gmail.com", City = "Buenos Aires", Address="Rivadavia 1864" },
                new EmployeeWithGeocodingData{  ID = 2, BirthDate = new DateTime(2020, 1, 1), Document=40335544,
                    FirstName="TARS", LastName="TARS", Mail="tars@gmail.com",
                    ConfirmMail = "tars@gmail.com", City = "Buenos Aires", Address="Paraguay 2155" },
                new EmployeeWithGeocodingData{  ID = 3, BirthDate = new DateTime(1962, 2, 3), Document=40446655,
                    FirstName="Dr. Amelia", LastName="Brand", Mail="ameliabrand@gmail.com",
                    ConfirmMail = "ameliabrand@gmail.com", City = "Buenos Aires", Address="Niceto Vega 5510" }
            };
        }
    }
}