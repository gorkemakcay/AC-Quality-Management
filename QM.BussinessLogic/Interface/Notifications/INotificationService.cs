using QM.Common.ViewModels.Notifications.NotificationViewModels;
using QM.Entities.Concrete.Notifications;
using System;

namespace QM.BussinessLogic.Interface.Notifications
{
    public interface INotificationService : IGenericService<Notification>
    {
        void AddNotification(NotificationAddViewModel model);

        void DeleteNotification(NotificationListViewModel model);

        void UpdateNotification(NotificationUpdateViewModel model);
    }
}
