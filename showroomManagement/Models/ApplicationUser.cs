using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace showroomManagement.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string ImagePath { get; set; }
        public string DOB { get; set; }
        public string CNIC { get; set; }
        public string Qualification { get; set; }
        public string Address { get; set; }

        [NotMapped]
        public IFormFile Image { get; set; }
    }
}
