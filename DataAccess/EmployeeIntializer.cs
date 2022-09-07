using System;
using System.Collections.Generic;
using BCRABusiness.Models;

namespace DataAccess
{
    public class EmployeeInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            List<EmployeeWithGeocodingData> employees = new List<EmployeeWithGeocodingData>
            {
                new EmployeeWithGeocodingData
                {
                    BirthDate = new DateTime(1960, 7, 24),
                    Document = 40113322,
                    FirstName = "Joseph ",
                    LastName = "Cooper",
                    Mail = "josephcooper@gmail.com",
                    ConfirmMail = "josephcooper@gmail.com",
                    City = "Buenos Aires",
                    Address = "Lima 3951",
                    Latitude = -34.6220169,
                    Longitude = -58.381438
                },
                new EmployeeWithGeocodingData
                {
                    BirthDate = new DateTime(2002, 5, 20),
                    Document = 40224433,
                    FirstName = "Murph",
                    LastName = "Cooper",
                    Mail = "murphcooper@gmail.com",
                    ConfirmMail = "murphcooper@gmail.com",
                    City = "Buenos Aires",
                    Address = "Rivadavia 1864",
                    Latitude = -38.731692920408165,
                    Longitude = -62.242195636734692
                },
                new EmployeeWithGeocodingData
                {
                    BirthDate = new DateTime(2020, 1, 1),
                    Document = 40335544,
                    FirstName = "TARS",
                    LastName = "TARS",
                    Mail = "tars@gmail.com",
                    ConfirmMail = "tars@gmail.com",
                    City = "Buenos Aires",
                    Address = "Paraguay 2155",
                    Latitude = -34.5978066,
                    Longitude = -58.398269400190848
                },
                new EmployeeWithGeocodingData
                {
                    BirthDate = new DateTime(1962, 2, 3),
                    Document = 40446655,
                    FirstName = "Dr. Amelia",
                    LastName = "Brand",
                    Mail = "ameliabrand@gmail.com",
                    ConfirmMail = "ameliabrand@gmail.com",
                    City = "Buenos Aires",
                    Address = "Rivadavia 5510",
                    Latitude = -34.781958283333331,
                    Longitude = -58.331883266666665
                }
            };
            employees.ForEach(s => context.EmployeeWithGeocodingData.Add(s));
            context.SaveChanges();
        }
    }
}
