using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using product_app_test.Controllers.Configurations;
using product_app_test.Models;
using product_app_test.Models.Configurations;

namespace product_app_test.Controllers
{
    public class DbcontextApp : DbContext
    {
        public DbcontextApp(DbContextOptions<DbcontextApp> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CtgConfiguration());
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
        }
        public DbSet<Category> Category { get; set; }
        public DbSet<Product> Product { get; set; }
    }
}
