using QM.DataAccess.Concrete.EntityFrameworkCore.Context;
using QM.DataAccess.Interface.WorkOrders;
using QM.Entities.Concrete.WorkOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.DataAccess.Concrete.EntityFrameworkCore.Repositories.WorkOrders
{
    public class EfManuelScenarioRepository : EfGenericRepository<ManuelScenario>, IManuelScenarioDal
    {
        private readonly ArlentusBIContext _Ctx;
        public EfManuelScenarioRepository(ArlentusBIContext ctx) : base(ctx)
        {
            _Ctx = ctx;
        }
    }
}
