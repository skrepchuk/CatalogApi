using APICatalogo.Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context
{
    public class APICatalogContext : IdentityDbContext
    {
        public APICatalogContext(DbContextOptions<APICatalogContext> options) : base(options)
        {}

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
    }
}
