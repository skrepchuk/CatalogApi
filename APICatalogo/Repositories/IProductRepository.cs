using APICatalogo.Domain;
using APICatalogo.Pagination;

namespace APICatalogo.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetProductsByCategory(int id);
        PaginatedList<Product> GetProducts(ProductsPagination pagination);
        PaginatedList<Product> GetProducts(ProductPriceFilter filter);       

    }
}