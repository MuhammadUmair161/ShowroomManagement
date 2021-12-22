using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace showroomManagement.Models
{
    [Table("AccessoriesStock")]
    public partial class AccessoriesStock
    {
        public int Id { get; set; }
        public int? AccessoryId { get; set; }
        public int? Quantity { get; set; }

        public virtual Accessory Accessory { get; set; }
    }
}
