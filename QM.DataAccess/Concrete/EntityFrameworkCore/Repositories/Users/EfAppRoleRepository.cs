using QM.DataAccess.Concrete.EntityFrameworkCore.Context;
using QM.DataAccess.Interface.Users;
using QM.Entities.Concrete.Users;
using System;

namespace QM.DataAccess.Concrete.EntityFrameworkCore.Repositories.Users
{
    public class EfAppRoleRepository : EfGenericRepository<AppRole>, IAppRoleDal
    {
        private readonly ArlentusBIContext _Ctx;

        public EfAppRoleRepository(ArlentusBIContext ctx) : base(ctx)
        {
            _Ctx = ctx;
        }
    }
}
