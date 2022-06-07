using QM.DataAccess.Concrete.EntityFrameworkCore.Context;
using QM.DataAccess.Interface.FinalQualities;
using QM.Entities.Concrete.FinalQualities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.DataAccess.Concrete.EntityFrameworkCore.Repositories.FinalQualities
{
    public class EfFQControlRepository : EfGenericRepository<FQControl>, IFQControlDal
    {
        private readonly ArlentusBIContext _Ctx;
        public EfFQControlRepository(ArlentusBIContext ctx) : base(ctx)
        {
            _Ctx = ctx;
        }
    }
}
