namespace APICatalogo.Repositories
{
    public interface IUnitOfWork
    {
        IProductRepository ProductRepository { get; }
        ICategoryRepository CategorieRepository { get; }

        void Commit();
    }
}
