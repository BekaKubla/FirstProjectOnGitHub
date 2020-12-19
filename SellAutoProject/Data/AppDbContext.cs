using Microsoft.EntityFrameworkCore;
using SellAutoProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SellAutoProject.Data
{
    public class AppDbContext :DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext>option) : base(option)
        {

        }
        public DbSet<Car> Cars { get; set; }
    }
}
