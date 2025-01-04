using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebdotNet.Models;

namespace WebdotNet.DataAccess.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public DbSet<OrderHeader> OrderHeaders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder); //this is needed when we use IdentityDbContext
            modelBuilder.Entity<Category>().HasData(
                new Category { ID = 1, Name = "Sneaker", DisplayOrder = 1 },
                new Category { ID = 2, Name = "Formal Shoes", DisplayOrder = 2 },
                new Category { ID = 3, Name = "Basketball Shoes", DisplayOrder = 3 },
                new Category { ID = 4, Name = "Football Shoes", DisplayOrder = 4 },
                new Category { ID = 5, Name = "Running Shoes", DisplayOrder = 5 },
                new Category { ID = 6, Name = "Trekking Shoes", DisplayOrder = 6 }
            );

            
        }
    }
}