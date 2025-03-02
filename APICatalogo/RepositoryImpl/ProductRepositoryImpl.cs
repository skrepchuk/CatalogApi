using APICatalogo.Context;
using APICatalogo.Domain;
using APICatalogo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.RepositoryImpl
{
    public class ProductRepositoryImpl : IProductRepository
    {
        private readonly APICatalogContext _context;
        private readonly ILogger<ProductRepositoryImpl> _logger;

        public ProductRepositoryImpl(APICatalogContext context, ILogger<ProductRepositoryImpl> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Product Create(Product product)
        {
            if(product == null) throw new ArgumentNullException(nameof(product));
            _context.Add(product);
            _context.SaveChanges();
            return product;
        }

        public Product Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null) throw new ArgumentNullException(nameof(product));
            _context.Remove(product);
            _context.SaveChanges();
            return product;
        }

        public IEnumerable<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product GetByIdy(int id)
        {
            return _context.Products.FirstOrDefault(c => c.Id == id);
        }

        public Product Update(Product product)
        {
            if (product == null) throw new ArgumentNullException(nameof(product));
            _context.Entry(product).State = EntityState.Modified;
            _context.SaveChanges();
            return product;
        }
    }
}
