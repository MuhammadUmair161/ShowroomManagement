using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace showroomManagement.Models
{
    [Table("Purchase")]
    public partial class Purchase
    {
        public int Id { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int? CarId { get; set; }
        public int? VendorId { get; set; }
        public int? Quantity { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? AmountDue { get; set; }

        public virtual Car Car { get; set; }
        public virtual Vendor Vendor { get; set; }
    }
}
