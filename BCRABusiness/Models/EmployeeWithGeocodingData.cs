using System.ComponentModel.DataAnnotations;

namespace BCRABusiness.Models
{
    public class EmployeeWithGeocodingData : Employee
    {
        [Required(ErrorMessage = "City is Required")]
        [StringLength(50)]
        public string City { get; set; }
        [Required(ErrorMessage = "Address is Required"), MinLength(3), MaxLength(40)]
        public string Address { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
