using QM.Entities.Concrete.Notifications;
using QM.Entities.Concrete.Users;
using System;

namespace QM.Common.ViewModels.Notifications.UserNotificationViewModels
{
    public class UserNotificationAddViewModel
    {
        public bool Status { get; set; }

        #region AppUser
        public int AppUserId { get; set; }//Bildirimin ait olduğu kullanıcı - Foreingn Key.
        public AppUser AppUser { get; set; }//Bildirimin ait olduğu kullanıcı bilgileri - İlişkili tablo. 
        #endregion

        #region Notificaiton
        public int NotificationId { get; set; }//Kullanıcıya ait bildirim - Foreingn Key.
        public Notification Notification { get; set; }//Kullanıcıya ait bildirim bilgileri - İlişkili tablo.
        #endregion
    }
}
