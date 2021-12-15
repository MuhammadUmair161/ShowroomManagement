using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace showroomManagement.Models
{
    public partial class ShrowroomDbContext : DbContext
    {
        public ShrowroomDbContext()
        {
        }

        public ShrowroomDbContext(DbContextOptions<ShrowroomDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AccessoriesStock> AccessoriesStocks { get; set; }
        public virtual DbSet<Accessory> Accessories { get; set; }
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        public virtual DbSet<Car> Cars { get; set; }
        public virtual DbSet<CarType> CarTypes { get; set; }
        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<CustomerDetail> CustomerDetails { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Interst> Intersts { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }
        public virtual DbSet<NewCar> NewCars { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<Purchase> Purchases { get; set; }
        public virtual DbSet<RegisteredCar> RegisteredCars { get; set; }
        public virtual DbSet<Stock> Stocks { get; set; }
        public virtual DbSet<UsedCar> UsedCars { get; set; }
        public virtual DbSet<Vendor> Vendors { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=ShrowroomDb;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<AccessoriesStock>(entity =>
            {
                entity.ToTable("AccessoriesStock");

                entity.HasOne(d => d.Accessory)
                    .WithMany(p => p.AccessoriesStocks)
                    .HasForeignKey(d => d.AccessoryId)
                    .HasConstraintName("FK__Accessori__Acces__71D1E811");
            });

            modelBuilder.Entity<Accessory>(entity =>
            {
                entity.Property(e => e.ImagePath).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price).HasColumnType("money");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.Property(e => e.RoleId).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.Property(e => e.UserId).IsRequired();

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserRole>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.RoleId });

                entity.HasIndex(e => e.RoleId, "IX_AspNetUserRoles_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.RoleId);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserRoles)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<Car>(entity =>
            {
                entity.ToTable("Car");

                entity.Property(e => e.CarImage1).IsUnicode(false);

                entity.Property(e => e.CarImage2).IsUnicode(false);

                entity.Property(e => e.CarImage3).IsUnicode(false);

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EngineCapacity).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.HasCruiseControl).HasColumnName("HasCruiseCOntrol");

                entity.Property(e => e.HoursePower).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.HasOne(d => d.CarType)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.CarTypeId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Car__CarTypeId__4F7CD00D");

                entity.HasOne(d => d.Company)
                    .WithMany(p => p.Cars)
                    .HasForeignKey(d => d.CompanyId)
                    .OnDelete(DeleteBehavior.SetNull)
                    .HasConstraintName("FK__Car__CompanyId__5070F446");
            });

            modelBuilder.Entity<CarType>(entity =>
            {
                entity.ToTable("CarType");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Company>(entity =>
            {
                entity.ToTable("Company");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<CustomerDetail>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Cnic)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("CNIC");

                entity.Property(e => e.Contact)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.ToTable("Employee");

                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Cnic)
                    .HasMaxLength(17)
                    .IsUnicode(false)
                    .HasColumnName("CNIC");

                entity.Property(e => e.Contact)
                    .HasMaxLength(15)
                    .IsUnicode(false);

                entity.Property(e => e.DateOfBirth).HasMaxLength(25);

                entity.Property(e => e.Department)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(25)
                    .IsUnicode(false);

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);


                entity.Property(e => e.ImagePath).IsUnicode(false);

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);


                entity.Property(e => e.Qualification)
                    .HasMaxLength(25)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Interst>(entity =>
            {
                entity.Property(e => e.UserId).HasMaxLength(450);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Intersts)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK__Intersts__UserId__6A30C649");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.ToTable("Invoice");

                entity.Property(e => e.AmountDue).HasColumnType("money");

                entity.Property(e => e.AmountPaid).HasColumnType("money");

                entity.Property(e => e.EngineNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.InstallmentAmount).HasColumnType("money");

                entity.Property(e => e.InvoiceDate).HasColumnType("date");

                entity.Property(e => e.InvoiceGeneratedBy).HasMaxLength(450);

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__Invoice__CarId__656C112C");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Invoice__Custome__6754599E");

                entity.HasOne(d => d.InvoiceGeneratedByNavigation)
                    .WithMany(p => p.Invoices)
                    .HasForeignKey(d => d.InvoiceGeneratedBy)
                    .HasConstraintName("FK__Invoice__Invoice__66603565");
            });

            modelBuilder.Entity<NewCar>(entity =>
            {
                entity.Property(e => e.CurrentPrice).HasColumnType("money");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.NewCars)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__NewCars__CarId__5BE2A6F2");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.DeliveryDate).HasColumnType("date");

                entity.Property(e => e.OrderCode)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OrderDate).HasColumnType("date");

                entity.Property(e => e.OrderedBy).HasMaxLength(450);

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.HasOne(d => d.OrdereAccessory)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrdereAccessoryId)
                    .HasConstraintName("FK__Orders__OrdereAc__75A278F5");

                entity.HasOne(d => d.OrderedByNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.OrderedBy)
                    .HasConstraintName("FK__Orders__OrderedB__74AE54BC");
            });

            modelBuilder.Entity<Purchase>(entity =>
            {
                entity.ToTable("Purchase");

                entity.Property(e => e.AmountDue).HasColumnType("money");

                entity.Property(e => e.AmountPaid).HasColumnType("money");

                entity.Property(e => e.PurchaseDate).HasColumnType("date");

                entity.Property(e => e.TotalAmount).HasColumnType("money");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__Purchase__CarId__5535A963");

                entity.HasOne(d => d.Vendor)
                    .WithMany(p => p.Purchases)
                    .HasForeignKey(d => d.VendorId)
                    .HasConstraintName("FK__Purchase__Vendor__5629CD9C");
            });

            modelBuilder.Entity<RegisteredCar>(entity =>
            {
                entity.Property(e => e.RegistrationDate).HasColumnType("date");

                entity.Property(e => e.RegistrationNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.RegisteredCars)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__Registere__CarId__6D0D32F4");
            });

            modelBuilder.Entity<Stock>(entity =>
            {
                entity.ToTable("Stock");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.Stocks)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__Stock__CarId__59063A47");
            });

            modelBuilder.Entity<UsedCar>(entity =>
            {
                entity.Property(e => e.Demand).HasColumnType("money");

                entity.HasOne(d => d.Car)
                    .WithMany(p => p.UsedCars)
                    .HasForeignKey(d => d.CarId)
                    .HasConstraintName("FK__UsedCars__CarId__5EBF139D");
            });

            modelBuilder.Entity<Vendor>(entity =>
            {
                entity.Property(e => e.Address)
                    .HasMaxLength(250)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
