using System;
using System.Collections.Generic;

#nullable disable

namespace showroomManagement.Models
{
    public partial class NewCar
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        public int? ModelYear { get; set; }
        public decimal? CurrentPrice { get; set; }

        public virtual Car Car { get; set; }
    }
}
