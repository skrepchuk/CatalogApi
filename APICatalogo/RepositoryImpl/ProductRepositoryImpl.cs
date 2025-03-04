using APICatalogo.Context;
using APICatalogo.Domain;
using APICatalogo.Pagination;
using APICatalogo.Repositories;

namespace APICatalogo.RepositoryImpl
{
    public class ProductRepositoryImpl : GenericRepositoryImpl<Product>, IProductRepository
    {
        public ProductRepositoryImpl(APICatalogContext context) : base(context) { }

        public async Task<PaginatedList<Product>> GetProductsAsync(ProductsPagination pagination)
        {
            var products = await GetAllAsync();
            var orderedProducts = products.OrderBy(p => p.Id).AsQueryable();
            var paginatedProducts = PaginatedList<Product>.ToPagedList(
                orderedProducts, pagination.PageNumber,
                pagination.PageSize);

            return paginatedProducts;
        }

        public async Task<PaginatedList<Product>> GetProductsAsync(ProductPriceFilter filter)
        {
            var products = await GetAllAsync();
            if (filter.Price.HasValue && !string.IsNullOrEmpty(filter.Criteria))
            {
                if (filter.Criteria.Equals("maior", StringComparison.OrdinalIgnoreCase))
                {
                     products = products.Where(p => p.Price > filter.Price.Value).OrderBy(p => p.Price);
                }
                if (filter.Criteria.Equals("menor", StringComparison.OrdinalIgnoreCase))
                {
                     products = products.Where(p => p.Price < filter.Price.Value).OrderBy(p => p.Price);
                }
                if (filter.Criteria.Equals("igual", StringComparison.OrdinalIgnoreCase))
                {
                     products = products.Where(p => p.Price == filter.Price.Value).OrderBy(p => p.Price);
                }
            }
            var paginatedList = PaginatedList<Product>.ToPagedList(products.AsQueryable(), filter.PageNumber, filter.PageSize);
            return  paginatedList;
        }

        public IEnumerable<Product> GetProductsByCategory(int id)
        {
            return _context.Products.Where(c => c.CategoryId == id).ToList();
        }
    }
}