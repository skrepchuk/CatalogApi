using APICatalogo.Domain;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context
{
    public class APICatalogContext : DbContext
    {
        public APICatalogContext(DbContextOptions<APICatalogContext> options) : base(options)
        {}

        public DbSet<Category>? Categories { get; set; }
        public DbSet<Product>? Products { get; set; }
    }
}
