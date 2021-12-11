using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace showroomManagement.Models
{
    public class SignUp
    {
        public int id { get; set; }
        [Required]
        [DisplayName("FullName")]
        public string FullName { get; set; }
        [DisplayName("Frist Name")]
        public string FristName { get; set; }
        [Required]
        [DisplayName("Last Name")]
        public string LastName { get; set; }
        [Required]
        [DisplayName("DOB")]
        public string DOB { get; set; }
        [Required]
        [DisplayName("Email")]
        public string Email { get; set; }
        [Required]
        [DisplayName("password")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [Required]
        [DisplayName("Repert Password")]
        [DataType(DataType.Password)]
        public string RepertPassword { get; set; }
    }
}
