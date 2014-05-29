using System;
using System.Data.Entity;

namespace Gigi.Web.Models
{
    public class TenantDbContext : DbContext
    {
        public TenantDbContext()            
        {
        }

        public DbSet<IssuingAuthorityKey> IssuingAuthorityKeys { get; set; }

        public DbSet<Tenant> Tenants { get; set; }
    }
}