using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BCRABusiness.Models;

namespace DataAccess
{
    internal class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("name=BCRA_DB_ConnectionString")
        {

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Employee_GeocodingInfo> Employee_GeocodingInfo { get; set; }
    }
}
    