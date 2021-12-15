using System;
using System.Collections.Generic;

#nullable disable

namespace showroomManagement.Models
{
    public partial class Accessory
    {
        public Accessory()
        {
            AccessoriesStocks = new HashSet<AccessoriesStock>();
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal? Price { get; set; }
        public string ImagePath { get; set; }

        public virtual ICollection<AccessoriesStock> AccessoriesStocks { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
