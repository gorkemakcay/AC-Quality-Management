using Microsoft.EntityFrameworkCore;
using QM.DataAccess.Concrete.EntityFrameworkCore.Context;
using QM.DataAccess.Interface;
using QM.Entities.Interface;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace QM.DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<Table> : IGenericDal<Table> where Table : class, ITable, new()
    {
        private readonly ArlentusBIContext _Ctx;
        internal DbSet<Table> dbSet;

        public EfGenericRepository(ArlentusBIContext ctx)
        {
            _Ctx = ctx;
            dbSet = _Ctx.Set<Table>();
        }

        public void Add(Table entity)
        {
            dbSet.Add(entity);
        }

        public void Delete(Table entity)
        {
            dbSet.Remove(entity);
        }

        public IQueryable<Table> GetAll(Expression<Func<Table, bool>> filter = null, Func<IQueryable<Table>, IOrderedQueryable<Table>> orderBy = null, string includeProperties = null)
        {
            IQueryable<Table> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            if (orderBy != null)
            {
                return orderBy(query);
            }

            return query;
        }

        public Table GetById(int id)
        {
            return dbSet.Find(id);
        }

        public Table GetFirstOrDefault(Expression<Func<Table, bool>> filter = null, string includeProperties = null)
        {
            IQueryable<Table> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter);
            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            return query.FirstOrDefault();
        }

        public void Update(Table entity)
        {
            dbSet.Update(entity);
        }
    }
}
