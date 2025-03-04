using APICatalogo.Context;
using APICatalogo.Domain;
using APICatalogo.Pagination;
using APICatalogo.Repositories;

namespace APICatalogo.RepositoryImpl
{
    public class ProductRepositoryImpl : GenericRepositoryImpl<Product>, IProductRepository
    {
        public ProductRepositoryImpl(APICatalogContext context) : base(context) { }

        public PaginatedList<Product> GetProducts(ProductsPagination pagination)
        {
            var products = GetAll().OrderBy(p => p.Id).AsQueryable();
            var paginatedProducts = PaginatedList<Product>.ToPagedList(
                products, pagination.PageNumber,
                pagination.PageSize);

            return paginatedProducts;
        }

        public PaginatedList<Product> GetProducts(ProductPriceFilter filter)
        {
            var products = GetAll().AsQueryable();
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
            var paginatedList = PaginatedList<Product>.ToPagedList(products, filter.PageNumber, filter.PageSize);
            return paginatedList;
        }

        public IEnumerable<Product> GetProductsByCategory(int id)
        {
            return _context.Products.Where(c => c.CategoryId == id).ToList();
        }
    }
}