using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace showroomManagement.Models
{
    public class DbContextShowroom : IdentityDbContext<ApplicationUser>
    {
        public DbContextShowroom(DbContextOptions<DbContextShowroom> x) : base(x)
        {

        }
    }
}
