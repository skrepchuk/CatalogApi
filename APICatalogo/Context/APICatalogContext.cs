using APICatalogo.Domain;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.Context
{
    public class APICatalogContext : DbContext
    {
        public APICatalogContext(DbContextOptions<APICatalogContext> options) : base(options)
        {}

        public DbSet<Categoria>? Categorias { get; set; }
        public DbSet<Produto>? Produtos { get; set; }
    }
}
