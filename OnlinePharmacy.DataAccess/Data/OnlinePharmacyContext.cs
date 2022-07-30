using Microsoft.EntityFrameworkCore;
using OnlinePharmacy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlinePharmacy.DataAccess.Data
{
    public class OnlinePharmacyContext : DbContext
    {
        public OnlinePharmacyContext(DbContextOptions<OnlinePharmacyContext> options) : base(options)
        {

        }
        //ForeignKey Constraint Issue in Cascade Override solution in .Net Core
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys()))
            {
                relationship.DeleteBehavior = DeleteBehavior.Restrict;
            }
        }
        public DbSet<Category> Categories {get; set;}
        public DbSet<Company> Companies {get; set;}
        public DbSet<Product> Products {get; set;}
        public DbSet<Role> Roles {get; set;}
        public DbSet<User> Users {get; set;}
        public DbSet<ShoppingCart> ShoppingCarts {get; set;}
        public DbSet<OrderDetail> OrderDetails {get; set;}
        public DbSet<OrderHeader> OrderHeaders {get; set;}
    }
}
