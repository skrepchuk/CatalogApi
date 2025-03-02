using APICatalogo.Domain;

namespace APICatalogo.Repositories
{
    public interface IProductRepository
    {
        IEnumerable<Product> GetAll();
        Product GetByIdy(int id);
        Product Create(Product category);
        Product Update(Product category);
        Product Delete(int id);
    }
}
