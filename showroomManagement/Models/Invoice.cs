using System;
using System.Collections.Generic;

#nullable disable

namespace showroomManagement.Models
{
    public partial class Invoice
    {
        public int Id { get; set; }
        public string InvoiceNumber { get; set; }
        public DateTime? InvoiceDate { get; set; }
        public int? CarId { get; set; }
        public decimal? TotalAmount { get; set; }
        public decimal? AmountPaid { get; set; }
        public decimal? AmountDue { get; set; }
        public int? TotalInstallments { get; set; }
        public decimal? InstallmentAmount { get; set; }
        public string EngineNo { get; set; }
        public string InvoiceGeneratedBy { get; set; }
        public int? CustomerId { get; set; }

        public virtual Car Car { get; set; }
        public virtual CustomerDetail Customer { get; set; }
        public virtual AspNetUser InvoiceGeneratedByNavigation { get; set; }
    }
}
