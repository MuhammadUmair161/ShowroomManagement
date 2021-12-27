using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace showroomManagement.Models
{
    [Table("Accessories")]
    //[Table("Accessory")]
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

        [NotMapped]
        public IFormFile Image { get; set; }


        public virtual ICollection<AccessoriesStock> AccessoriesStocks { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
