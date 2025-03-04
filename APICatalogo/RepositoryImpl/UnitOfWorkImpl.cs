using APICatalogo.Context;
using APICatalogo.Repositories;

namespace APICatalogo.RepositoryImpl
{
    public class UnitOfWorkImpl : IUnitOfWork
    {
        private IProductRepository? _productRepository;

        private ICategoryRepository? _categorieRepository;

        public APICatalogContext _context;

        public UnitOfWorkImpl(APICatalogContext context)
        {
            _context = context;
        }

        public IProductRepository ProductRepository 
        { 
            get 
            {
                return _productRepository = _productRepository ?? new ProductRepositoryImpl(_context);
            }  
        }

        public ICategoryRepository CategorieRepository
        {
            get
            {
                return _categorieRepository = _categorieRepository ?? new CategoryRepositoryImpl(_context);
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
