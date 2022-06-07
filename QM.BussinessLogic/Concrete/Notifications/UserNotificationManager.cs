using AutoMapper;
using QM.BussinessLogic.Interface.Notifications;
using QM.Common.ViewModels.Notifications.UserNotificationViewModels;
using QM.DataAccess.UnitOfWorks.Interface;
using QM.Entities.Concrete.Notifications;
using System;
using System.Collections.Generic;
using System.Linq;

namespace QM.BussinessLogic.Concrete.Notifications
{
    public class UserNotificationManager : GenericManager<UserNotification>, IUserNotificationService
    {
        private readonly IUnitOfWork _Uow;
        private readonly IMapper _Mapper;
        public UserNotificationManager(IUnitOfWork uow, IMapper mapper) : base(uow)
        {
            _Uow = uow;
            _Mapper = mapper;
        }

        public void AddUserNotification(UserNotificationAddViewModel model)
        {
            Add(_Mapper.Map<UserNotification>(model));
            _Uow.SaveChange();
        }

        public void DeleteUserNotification(UserNotificationListViewModel model)
        {
            Delete(_Mapper.Map<UserNotification>(model));
            _Uow.SaveChange();
        }

        #region GetUserNotificationsBll
        /// <summary>
        /// Kullanıcıya ait bildirimleri çeker.
        /// </summary>
        /// <param name="appUserId">Sisteme giriş yapan kullanıcı Id'si.</param>
        /// <returns>Bildirim listesi.</returns>
        public List<UserNotificationListViewModel> GetUserNotificationsBll(int appUserId)
        {
            var model = GetAll(I => I.AppUserId == appUserId && I.Status, null, "AppUser,Notification").OrderByDescending(I => I.Notification.Date).ToList();
            return _Mapper.Map<List<UserNotificationListViewModel>>(model);
        }
        #endregion

        public void UpdateUserNotification(UserNotificationUpdateViewModel model)
        {
            Update(_Mapper.Map<UserNotification>(model));
            _Uow.SaveChange();
        }
    }
}
