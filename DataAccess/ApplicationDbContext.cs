using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using BCRABusiness.Models;

namespace DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("BCRA")
        {

        }
        public DbSet<EmployeeWithGeocodingData> EmployeeWithGeocodingData { get; set; }
    }
}
    