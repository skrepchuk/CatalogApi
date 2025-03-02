using APICatalogo.Context;
using APICatalogo.Domain;
using APICatalogo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.RepositoryImpl
{
    public class CategoryRepositoryImpl : GenericRepositoryImpl<Category>, ICategoryRepository
    {
        public CategoryRepositoryImpl(APICatalogContext context) : base(context) { }
        
    }
}
