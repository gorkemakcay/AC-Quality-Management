using AutoMapper;
using QM.BussinessLogic.Interface.Notifications;
using QM.Common.ViewModels.Notifications.NotificationViewModels;
using QM.DataAccess.UnitOfWorks.Interface;
using QM.Entities.Concrete.Notifications;
using System;

namespace QM.BussinessLogic.Concrete.Notifications
{
    public class NotificationManager : GenericManager<Notification>, INotificationService
    {
        private readonly IUnitOfWork _Uow;
        private readonly IMapper _Mapper;
        public NotificationManager(IUnitOfWork uow, IMapper mapper) : base(uow)
        {
            _Uow = uow;
            _Mapper = mapper;
        }

        public void AddNotification(NotificationAddViewModel model)
        {
            Add(_Mapper.Map<Notification>(model));
            _Uow.SaveChange();
        }

        public void DeleteNotification(NotificationListViewModel model)
        {
            Delete(_Mapper.Map<Notification>(model));
            _Uow.SaveChange();
        }

        public void UpdateNotification(NotificationUpdateViewModel model)
        {
            Update(_Mapper.Map<Notification>(model));
            _Uow.SaveChange();
        }
    }
}
