using QM.BussinessLogic.Interface;
using QM.DataAccess.UnitOfWorks.Interface;
using QM.Entities.Interface;
using System;
using System.Linq;
using System.Linq.Expressions;

namespace QM.BussinessLogic.Concrete
{
    public class GenericManager<Table> : IGenericService<Table> where Table : class, ITable, new ()
    {
        private readonly IUnitOfWork _Uow;

    public GenericManager(IUnitOfWork uow)
    {
        _Uow = uow;
    }

    // <summary>
    /// Gelen "Table" tipinde veriyi kaydeder.
    /// </summary>
    /// <param name="entity">Veritabanı sınıfı.</param>
    public void Add(Table entity)
    {
        try
        {
            if (entity != null)
            {
                _Uow.GetRepository<Table>().Add(entity);
            }
        }
        catch (Exception)
        {
            //TO DO: Global log helper .writwe ınfo message
            throw;
        }
        finally
        {

        }
    }

    /// <summary>
    /// Gelen "Table" tipinde veriyi siler.
    /// </summary>
    /// <param name="entity">Veritabanı sınıfı.</param>
    public void Delete(Table entity)
    {
        try
        {
            if (entity != null)
            {
                _Uow.GetRepository<Table>().Delete(entity);
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {

        }
    }

    /// <summary>
    /// Gelen "Table" tipindeki bütün kayıtları çeker.
    /// </summary>
    /// <param name="filter">Linq sorgusu.</param>
    /// <param name="orderBy">OrderBy koşulu.</param>
    /// <param name="includeProperties">Lazy/Eager loading.</param>
    /// <returns>Gelen "Table" tipindeki kayıtlar.</returns>
    public IQueryable<Table> GetAll(Expression<Func<Table, bool>> filter = null, Func<IQueryable<Table>, IOrderedQueryable<Table>> orderBy = null, string includeProperties = null)
    {
        try
        {
            return _Uow.GetRepository<Table>().GetAll(filter, orderBy, includeProperties);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {

        }
    }

    /// <summary>
    /// Gelen "Table" tipinde id'ye ait olan kaydı çeker.
    /// </summary>
    /// <param name="id">İstenilen verinin id'si.</param>
    /// <returns>Gelen "Table" tipindeki kayıt.</returns>
    public Table GetById(int id)
    {
        try
        {
            if (id > 0)
            {
                return _Uow.GetRepository<Table>().GetById(id);
            }
            else
            {
                return null;
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {

        }
    }

    /// <summary>
    /// Gelen "Table" tipinde kayıtlı olan ilk ya da default kaydı çeker.
    /// </summary>
    /// <param name="filter">Linq sorgusu.</param>
    /// <param name="includeProperties"></param>
    /// <returns>Gelen "Table" tipindeki kayıt.</returns>
    public Table GetFirstOrDefault(Expression<Func<Table, bool>> filter = null, string includeProperties = null)
    {
        try
        {
            return _Uow.GetRepository<Table>().GetFirstOrDefault(filter, includeProperties);
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {

        }
    }

    /// <summary>
    /// Gelen "Table" tipinde veriyi günceller.
    /// </summary>
    /// <param name="entity"></param>
    public void Update(Table entity)
    {
        try
        {
            if (entity != null)
            {
                _Uow.GetRepository<Table>().Update(entity);
                //TO DO:SaveChanges()'in doğru kullanım olup olmadığına bakılacak.
                //_Uow.SaveChanges();
            }
        }
        catch (Exception)
        {
            throw;
        }
        finally
        {

        }
    }
}
}
