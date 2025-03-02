using APICatalogo.Context;
using APICatalogo.Repositories;
using System.Linq.Expressions;

namespace APICatalogo.RepositoryImpl
{
    public class GenericRepositoryImpl<T> : IGenericRepository<T> where T : class
    {
        protected readonly APICatalogContext _context;

        public GenericRepositoryImpl(APICatalogContext context)
        {
            _context = context;
        }

        public IEnumerable<T> GetAll()
        {
            return _context.Set<T>().ToList();
        }
        T? IGenericRepository<T>.Get(Expression<Func<T, bool>> predicate)
        {
            return _context.Set<T>().FirstOrDefault(predicate);
        }
        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
            return entity;
        }
        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            _context.SaveChanges();
            return entity;
        }

    }
}
