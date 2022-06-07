using QM.DataAccess.Interface;
using QM.DataAccess.Interface.FinalQualities;
using QM.DataAccess.Interface.Users;
using QM.DataAccess.Interface.WorkOrders;
using QM.Entities.Interface;
using System;

namespace QM.DataAccess.UnitOfWorks.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IAppRoleDal appRoleDal { get; }

        IAppUserDal appUserDal { get; }

        IFinalQualityDal finalQualityDal { get; }

        IFQControlDal fqcontrolDal { get; }

        IRevisionDal revisionDal { get; }

        IWorkOrderDal workOrderDal { get; }  
        
        IProductDal productDal { get; }

        IManuelScenarioDal manuelScenarioDal { get; }

        IGenericDal<Table> GetRepository<Table>() where Table : class, ITable, new();

        void SaveChange();
    }
}
