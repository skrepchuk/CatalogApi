﻿using APICatalogo.Context;
using APICatalogo.Repositories;
using Microsoft.EntityFrameworkCore;
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

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task<T>? GetAsync(Expression<Func<T, bool>> predicate)
        {
            return await _context.Set<T>().FirstOrDefaultAsync(predicate);
        }
        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _context.Set<T>().Update(entity);
            return entity;
        }

        public T Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
            return entity;
        }

    }
}