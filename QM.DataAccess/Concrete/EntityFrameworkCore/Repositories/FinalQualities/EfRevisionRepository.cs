using QM.DataAccess.Concrete.EntityFrameworkCore.Context;
using QM.DataAccess.Interface.FinalQualities;
using QM.Entities.Concrete.FinalQualities;
using System;

namespace QM.DataAccess.Concrete.EntityFrameworkCore.Repositories.FinalQualities
{
    public class EfRevisionRepository : EfGenericRepository<Revision>, IRevisionDal
    {
        private readonly ArlentusBIContext _Ctx;

        public EfRevisionRepository(ArlentusBIContext ctx) : base(ctx)
        {
            _Ctx = ctx;
        }
    }
}