using System;
using System.Collections.Generic;

#nullable disable

namespace showroomManagement.Models
{
    public partial class Vendor
    {
        public Vendor()
        {
            Purchases = new HashSet<Purchase>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        public virtual ICollection<Purchase> Purchases { get; set; }
    }
}
