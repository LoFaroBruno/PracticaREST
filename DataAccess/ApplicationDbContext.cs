using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using BCRABusiness.Models;

namespace DataAccess
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("BCRA")
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Employee_GeocodingInfo> Employee_GeocodingInfo { get; set; }
    }
}
    