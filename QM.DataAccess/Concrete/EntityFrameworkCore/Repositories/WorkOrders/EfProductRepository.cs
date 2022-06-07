using QM.DataAccess.Concrete.EntityFrameworkCore.Context;
using QM.DataAccess.Interface.WorkOrders;
using QM.Entities.Concrete.WorkOrders;
using System;

namespace QM.DataAccess.Concrete.EntityFrameworkCore.Repositories.WorkOrders
{
    public class EfProductRepository : EfGenericRepository<Product>, IProductDal
    {
        private readonly ArlentusBIContext _Ctx;
        public EfProductRepository(ArlentusBIContext ctx) : base(ctx)
        {
            _Ctx = ctx;
        }
    }
}