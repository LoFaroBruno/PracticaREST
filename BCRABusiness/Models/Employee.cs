using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace BCRABusiness.Models
{
    public class Employee
    {
        [Key]
        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        [Required, Range(11111111, 99999999)]
        [DisplayName("DNI")]
        public int Document { get; set; }
        [Required, MinLength(3), MaxLength(15)]
        [DisplayName("Nombre")]
        public String FirstName { get; set; }
        [Required, MinLength(3), MaxLength(15)]
        public String LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }
        [Required(ErrorMessage = "Mail is Required")]
        [RegularExpression("^[a-zA-Z0-9_\\.-]+@([a-zA-Z0-9-]+\\.)+[a-zA-Z]{2,6}$", ErrorMessage = "Mail is not valid")]
        public String Mail { get; set; }
        [Required(ErrorMessage = "Confirm Mail is Required")]
        [Compare("Mail", ErrorMessage = "Mails don't match")]
        public String ConfirmMail { get; set; }
    }
}