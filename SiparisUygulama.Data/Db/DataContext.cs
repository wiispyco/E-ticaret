using Microsoft.EntityFrameworkCore;
using SiparisUygulama.Data.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace SiparisUygulama.Data.Db
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            this.ChangeTracker.AutoDetectChangesEnabled = true;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }
        public DbSet<RestaurantFood> RestaurantFoods { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartDetail> CartsDetail { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
