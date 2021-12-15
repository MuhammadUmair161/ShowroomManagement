using System;
using System.Collections.Generic;

#nullable disable

namespace showroomManagement.Models
{
    public partial class Stock
    {
        public int Id { get; set; }
        public int? CarId { get; set; }
        public int? Available { get; set; }

        public virtual Car Car { get; set; }
    }
}
