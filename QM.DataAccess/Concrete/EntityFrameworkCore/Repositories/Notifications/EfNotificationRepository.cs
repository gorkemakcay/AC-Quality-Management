using QM.DataAccess.Concrete.EntityFrameworkCore.Context;
using QM.DataAccess.Interface.Notifications;
using QM.Entities.Concrete.Notifications;
using System;
namespace QM.DataAccess.Concrete.EntityFrameworkCore.Repositories.Notifications
{
    public class EfNotificationRepository : EfGenericRepository<Notification>, INotificationDal
    {
        private readonly ArlentusBIContext _Ctx;
        public EfNotificationRepository(ArlentusBIContext ctx) : base(ctx)
        {
            _Ctx = ctx;
        }
    }
}
