using System;
using System.Collections.Generic;

#nullable disable

namespace showroomManagement.Models
{
    public partial class Order
    {
        public int Id { get; set; }
        public string OrderCode { get; set; }
        public string OrderedBy { get; set; }
        public int? OrdereAccessoryId { get; set; }
        public decimal? TotalAmount { get; set; }
        public DateTime? OrderDate { get; set; }
        public bool? Status { get; set; }
        public DateTime? DeliveryDate { get; set; }

        public virtual Accessory OrdereAccessory { get; set; }
        public virtual AspNetUser OrderedByNavigation { get; set; }
    }
}
