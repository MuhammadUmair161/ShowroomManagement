using System;
using System.Collections.Generic;

#nullable disable

namespace showroomManagement.Models
{
    public partial class UsedCar
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        public decimal? Demand { get; set; }
        public int? ModelYear { get; set; }

        public virtual Car Car { get; set; }
    }
}
