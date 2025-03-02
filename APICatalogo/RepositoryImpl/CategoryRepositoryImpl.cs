using APICatalogo.Context;
using APICatalogo.Domain;
using APICatalogo.Repositories;
using Microsoft.EntityFrameworkCore;

namespace APICatalogo.RepositoryImpl
{
    public class CategoryRepositoryImpl : ICategorieRepository
    {
        private readonly APICatalogContext _context;
        private readonly ILogger<CategoryRepositoryImpl> _logger;

        public CategoryRepositoryImpl(APICatalogContext context, ILogger<CategoryRepositoryImpl> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Category Create(Category category)
        {
            if(category == null) throw new ArgumentNullException(nameof(category));
            _context.Add(category);
            _context.SaveChanges();
            return category;
        }

        public Category Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null) throw new ArgumentNullException(nameof(category));
            _context.Remove(category);
            _context.SaveChanges();
            return category;
        }

        public IEnumerable<Category> GetAll()
        {
            return _context.Categories.ToList();
        }

        public Category GetByIdy(int id)
        {
            return _context.Categories.FirstOrDefault(c => c.Id == id);
        }

        public Category Update(Category category)
        {
            if (category == null) throw new ArgumentNullException(nameof(category));
            _context.Entry(category).State = EntityState.Modified;
            _context.SaveChanges();
            return category;
        }
    }
}
