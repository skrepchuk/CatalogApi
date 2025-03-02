using APICatalogo.Domain;

namespace APICatalogo.Repositories
{
    public interface ICategorieRepository
    {
        IEnumerable<Category> GetAll();
        Category GetByIdy(int id);
        Category Create(Category category);
        Category Update(Category category);
        Category Delete(int id);
    }
}
