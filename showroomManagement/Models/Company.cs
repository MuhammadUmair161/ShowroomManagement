﻿using System;
using System.Collections.Generic;

#nullable disable

namespace showroomManagement.Models
{
    public partial class Company
    {
        public Company()
        {
            Cars = new HashSet<Car>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<Car> Cars { get; set; }
    }
}
