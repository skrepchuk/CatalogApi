using APICatalogo.Context;
using APICatalogo.Domain;
using APICatalogo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.RepositoryImpl
{
    public class ProductRepositoryImpl : GenericRepositoryImpl<Product>, IProductRepository
    {
        public ProductRepositoryImpl(APICatalogContext context) : base(context) { }
        public IEnumerable<Product> GetProductsByCategory(int id)
        {
            return _context.Products.Where(c => c.CategoryId == id).ToList();
        }
    }
}
