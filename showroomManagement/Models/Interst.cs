using System;
using System.Collections.Generic;

#nullable disable

namespace showroomManagement.Models
{
    public partial class Interst
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public bool? IsNotified { get; set; }

        //public virtual AspNetUser User { get; set; }
    }
}
