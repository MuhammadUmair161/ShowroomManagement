using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace showroomManagement.Models
{
    [Table("RegisteredCar")]
    public partial class RegisteredCar
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        public string RegistrationNo { get; set; }
        public DateTime? RegistrationDate { get; set; }

        public virtual Car Car { get; set; }
    }
}
