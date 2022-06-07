using QM.Entities.Interface;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace QM.BussinessLogic.Interface
{
    public interface IGenericService<Table> where Table : class, ITable, new()
    {
        void Add(Table entity);
        void Delete(Table entity);
        void Update(Table entity);
        IQueryable<Table> GetAll(Expression<Func<Table, bool>> filter = null, Func<IQueryable<Table>, IOrderedQueryable<Table>> orderBy = null, string includeProperties = null);
        Table GetFirstOrDefault(Expression<Func<Table, bool>> filter = null, string includeProperties = null);
        Table GetById(int id);
    }
}
