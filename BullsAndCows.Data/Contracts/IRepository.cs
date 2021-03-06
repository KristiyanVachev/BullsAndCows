﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace BullsAndCows.Data.Contracts
{
    public interface IRepository<T>
        where T : class
    {
        T GetById(object id);
        
        IEnumerable<T> QueryObjectGraph(Expression<Func<T, bool>> filter, string children);

        IEnumerable<T> QueryObjectGraph(Expression<Func<T, bool>> filter, string children, string otherChildren);

        IQueryable<T> Entities { get; }

        void Add(T entity);

        void Update(T entity);

        void Delete(T entity);
    }
}
