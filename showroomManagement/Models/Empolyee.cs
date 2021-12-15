using System;
using System.Collections.Generic;

#nullable disable

namespace showroomManagement.Models
{
    public partial class Empolyee
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Qualification { get; set; }
        public string Department { get; set; }
        public string ImagePath { get; set; }
        public string DateOfBirth { get; set; }
        public string Contact { get; set; }
        public string Cnic { get; set; }
    }
}
