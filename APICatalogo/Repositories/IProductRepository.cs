using APICatalogo.Domain;
using APICatalogo.Pagination;

namespace APICatalogo.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetProductsByCategory(int id);
        Task<PaginatedList<Product>> GetProductsAsync(ProductsPagination pagination);
        Task<PaginatedList<Product>> GetProductsAsync(ProductPriceFilter filter);       

    }
}