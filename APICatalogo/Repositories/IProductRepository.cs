using APICatalogo.Domain;

namespace APICatalogo.Repositories
{
    public interface IProductRepository : IGenericRepository<Product>
    {
        IEnumerable<Product> GetProductsByCategory(int id);
    }
}
