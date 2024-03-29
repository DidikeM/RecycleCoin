﻿using Microsoft.EntityFrameworkCore;
using RecycleCoin.DataAccess.Abstract;
using RecycleCoin.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RecycleCoin.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<T, TContext> : IEntityRepository<T> where T : class, IEntity, new() where TContext : DbContext, new()
    {
        public T Get(Expression<Func<T, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<T>().FirstOrDefault(filter)!;
            }
        }

        public int GetCount(Expression<Func<T, bool>> filter = null!)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<T>().Count() : context.Set<T>().Count(filter);
            }
        }

        public List<T> GetAll(Expression<Func<T, bool>> filter = null!)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<T>().ToList() : context.Set<T>().Where(filter).ToList();
            }
        }

        public List<Tuple<E>> GetALLSelect<E>(Expression<Func<T, Tuple<E>>> selectfilter, Expression<Func<T, bool>> filter = null!)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<T>().Select(selectfilter).ToList() : context.Set<T>().Where(filter).Select(selectfilter).ToList();
            }
        }

        public int SumInt(Expression<Func<T, int>> column, Expression<Func<T, bool>> filter = null!)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<T>().Sum(column) : context.Set<T>().Where(filter).Sum(column);
            }
        }

        public void Add(T entity)
        {
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(T entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }

        public void Update(T entity)
        {
            using (TContext context = new TContext())
            {
                var updatedEntity = context.Entry(entity);
                updatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
