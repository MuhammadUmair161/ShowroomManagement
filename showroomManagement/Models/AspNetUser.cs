//using System;
//using System.Collections.Generic;

//#nullable disable

//namespace showroomManagement.Models
//{
//    public partial class AspNetUser
//    {
//        public AspNetUser()
//        {
//            AspNetUserClaims = new HashSet<AspNetUserClaim>();
//            AspNetUserLogins = new HashSet<AspNetUserLogin>();
//            AspNetUserRoles = new HashSet<AspNetUserRole>();
//            AspNetUserTokens = new HashSet<AspNetUserToken>();
//            Intersts = new HashSet<Interst>();
//            Invoices = new HashSet<Invoice>();
//            Orders = new HashSet<Order>();
//        }

//        public string Id { get; set; }
//        public string FristName { get; set; }
//        public string LastName { get; set; }
//        public string ImagePath { get; set; }
//        public string UserName { get; set; }
//        public string NormalizedUserName { get; set; }
//        public string Email { get; set; }
//        public string NormalizedEmail { get; set; }
//        public bool EmailConfirmed { get; set; }
//        public string PasswordHash { get; set; }
//        public string SecurityStamp { get; set; }
//        public string ConcurrencyStamp { get; set; }
//        public string PhoneNumber { get; set; }
//        public bool PhoneNumberConfirmed { get; set; }
//        public bool TwoFactorEnabled { get; set; }
//        public DateTimeOffset? LockoutEnd { get; set; }
//        public bool LockoutEnabled { get; set; }
//        public int AccessFailedCount { get; set; }

//        public virtual ICollection<AspNetUserClaim> AspNetUserClaims { get; set; }
//        public virtual ICollection<AspNetUserLogin> AspNetUserLogins { get; set; }
//        public virtual ICollection<AspNetUserRole> AspNetUserRoles { get; set; }
//        public virtual ICollection<AspNetUserToken> AspNetUserTokens { get; set; }
//        public virtual ICollection<Interst> Intersts { get; set; }
//        public virtual ICollection<Invoice> Invoices { get; set; }
//        public virtual ICollection<Order> Orders { get; set; }
//    }
//}
