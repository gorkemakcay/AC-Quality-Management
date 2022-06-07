using QM.Common.ViewModels.Notifications.UserNotificationViewModels;
using QM.Entities.Concrete.Notifications;
using System;
using System.Collections.Generic;

namespace QM.BussinessLogic.Interface.Notifications
{
    public interface IUserNotificationService : IGenericService<UserNotification>
    {
        void AddUserNotification(UserNotificationAddViewModel model);

        void DeleteUserNotification(UserNotificationListViewModel model);

        void UpdateUserNotification(UserNotificationUpdateViewModel model);

        #region GetUserNotificationsBll
        /// <summary>
        /// Kullanıcıya ait bildirimleri çeker.
        /// </summary>
        /// <param name="appUserId">Sisteme giriş yapan kullanıcı Id'si.</param>
        /// <returns>Bildirim listesi.</returns>
        List<UserNotificationListViewModel> GetUserNotificationsBll(int appUserId);
        #endregion
    }
}
