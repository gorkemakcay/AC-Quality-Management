using QM.Entities.Concrete.FinalQualities;
using QM.Entities.Concrete.Notifications;
using QM.Entities.Concrete.WorkOrders;
using System;
using System.Collections.Generic;

namespace QM.Common.ViewModels.Notifications.NotificationViewModels
{
    public class NotificationUpdateViewModel
    {
        public int Id { get; set; }
        public string Explain { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public bool Status { get; set; }//Bildirimin okunup okunmadığını belirten durum.+

        #region WorkOrder
        public int? WorkOrderId { get; set; }//Bildirimin yapıldığı proje - Foreign Key.
        public WorkOrder WorkOrder { get; set; }//Bildirimin yapıldığı projenin bilgileri - İlişkili Tablo.
        #endregion

        #region FinalQuality
        public int? FinalQualityId { get; set; }//Bildirimin yapıldığı görev - Foreign Key.
        public FinalQuality FinalQuality { get; set; }//Bildirimin yapıldığı görevin bilgileri - İlişkili Tablo.
        #endregion

        public List<UserNotification> UserNotifications { get; set; }//Bildirim gönderilen kullanıcılar - İlişkili tablo.
    }
}
