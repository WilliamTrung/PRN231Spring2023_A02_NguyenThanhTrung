﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Generic
{
    public interface IGenericRepository<TEntity>  where TEntity : class
    {
        Task Add(TEntity entity);
        Task Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<IEnumerable<TEntity>> Get(Expression<Func<TEntity, bool>>? expression = null, params string[] includeProperties);
    }
}
