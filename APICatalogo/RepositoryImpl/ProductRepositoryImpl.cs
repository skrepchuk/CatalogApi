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

        public IEnumerable<Product> GetProductsByCategory(int id)
        {
            return _context.Products.Where(c => c.CategoryId == id).ToList();
        }
    }
}