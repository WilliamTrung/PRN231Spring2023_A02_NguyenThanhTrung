﻿using BusinessObject.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Generic
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly Context _context;
        protected DbSet<TEntity> _entities { get; }
        public GenericRepository(Context context)
        {
            _context= context;
            _entities = _context.Set<TEntity>();
        }
        public virtual async Task Add(TEntity entity)
        {
            _entities.Add(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task Delete(TEntity entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? expression = null, params string[] includeProperties)
        {
            var filter = _entities.AsNoTracking();
            foreach(var property in includeProperties)
            {
                filter.Include(property);
            }
            if(expression != null)
            {
                filter = filter.Where(expression);
            }
            return await filter.ToListAsync();
        }

        public virtual async Task Update(TEntity entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
