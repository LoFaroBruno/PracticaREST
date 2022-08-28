using System.ComponentModel.DataAnnotations;

namespace BCRABusiness.Models
{
    internal class Employee_GeocodingInfo : Employee
    {
        [Required(ErrorMessage = "City is Required")]
        [StringLength(50)]
        public string City { get; set; }
    }
}
