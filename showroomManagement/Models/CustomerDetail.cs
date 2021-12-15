﻿using System;
using System.Collections.Generic;

#nullable disable

namespace showroomManagement.Models
{
    public partial class CustomerDetail
    {
        public CustomerDetail()
        {
            Invoices = new HashSet<Invoice>();
        }

        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Cnic { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
