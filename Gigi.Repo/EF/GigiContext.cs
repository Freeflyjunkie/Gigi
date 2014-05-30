using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Gigi.Domain;

namespace Gigi.Repo.EF
{
    public class GigiContext : DbContext
    {
        public GigiContext() : base("DefaultConnection")           
        {
            Database.Log = sql => Debug.Write(sql);            
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerAddress> CustomerAddresses { get; set; }
        public DbSet<CustomerCreditCard> CustomerCreditCards { get; set; }
        public DbSet<Garment> Garments { get; set; }
        public DbSet<GarmentSize> GarmentSizes { get; set; }
        public DbSet<GarmentToGarmentSize> GarmentToGarmentSizes { get; set; }
        public DbSet<GarmentType> GarmentTypes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderToGarment> OrderToGarments { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }
        public DbSet<WishlistToGarment> WishlistToGarments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
