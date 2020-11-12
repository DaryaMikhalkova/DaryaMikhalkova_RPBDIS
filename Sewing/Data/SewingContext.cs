using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ConsoleApp.Models;
//задание 2 Контекст данных
namespace Sewing.Data
{
    public class SewingContext : DbContext
    {
        public SewingContext (DbContextOptions<SewingContext> options)
            : base(options)
        {
        }

        public DbSet<ConsoleApp.Models.Atelier_department> Atelier_Departments { get; set; }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Material_supply> Material_supply { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}
