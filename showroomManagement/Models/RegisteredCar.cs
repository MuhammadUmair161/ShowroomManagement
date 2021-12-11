using System;
using System.Collections.Generic;

#nullable disable

namespace showroomManagement.Models
{
    public partial class RegisteredCar
    {
        public int Id { get; set; }
        public DateTime? RegistrationDate { get; set; }
        public int? CarId { get; set; }
        public string RegistrationNo { get; set; }

        public virtual Car Car { get; set; }
    }
}
