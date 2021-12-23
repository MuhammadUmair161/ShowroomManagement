using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace showroomManagement.Models
{
    [Table("Car")]
    public partial class Car
    {
        public Car()
        {
            Invoices = new HashSet<Invoice>();
            NewCars = new HashSet<NewCar>();
            Purchases = new HashSet<Purchase>();
            RegisteredCars = new HashSet<RegisteredCar>();
            Stocks = new HashSet<Stock>();
            UsedCars = new HashSet<UsedCar>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int SittingCapacity { get; set; }
        public int? CarTypeId { get; set; }
        public int? CompanyId { get; set; }
        public decimal? EngineCapacity { get; set; }
        public decimal? HoursePower { get; set; }
        public bool HasPowerSteering { get; set; }
        public bool HasAntiLockBreakingSystem { get; set; }
        public bool TransmissionType { get; set; }
        public bool HasPowerWindows { get; set; }
        public bool HasAirbags { get; set; }
        public bool HasAutoClimControl { get; set; }
        public bool HasFogLights { get; set; }
        public bool HasAlloyRims { get; set; }
        public bool HasCruiseControl { get; set; }
        public bool IsHybrid { get; set; }
        public string CarImage1 { get; set; }
        public string CarImage2 { get; set; }
        public string CarImage3 { get; set; }

        [NotMapped]
        public IFormFile Image1 { get; set; }
        [NotMapped]
        public IFormFile Image2 { get; set; }
        [NotMapped]
        public IFormFile Image3 { get; set; }


        public virtual CarType CarType { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Invoice> Invoices { get; set; }
        public virtual ICollection<NewCar> NewCars { get; set; }
        public virtual ICollection<Purchase> Purchases { get; set; }
        public virtual ICollection<RegisteredCar> RegisteredCars { get; set; }
        public virtual ICollection<Stock> Stocks { get; set; }
        public virtual ICollection<UsedCar> UsedCars { get; set; }
    }
}
