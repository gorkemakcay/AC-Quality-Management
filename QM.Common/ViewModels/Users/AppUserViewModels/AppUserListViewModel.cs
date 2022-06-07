using QM.Entities.Concrete.FinalQualities;
using QM.Entities.Concrete.Notifications;
using QM.Entities.Concrete.WorkOrders;
using System;
using System.Collections.Generic;

namespace QM.Common.ViewModels.Users.AppUserViewModels
{
    public class AppUserListViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Picture { get; set; }
        public string Gender { get; set; }
        public string DepartmentName { get; set; }//Kullanıcının departmanı - Foreign Key.
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public List<WorkOrder> ProjectOwner { get; set; }//Kullanıcının sahibi olduğu projeler - İlişkili tablo.
        public List<WorkOrder> ProjectStaffs { get; set; }//Kullanıcının bulunduğu projeler - İlişkili tablo.
        public List<WorkOrder> QualityTechnician { get; set; }//Kullanıcının bulunduğu projeler - İlişkili tablo.
        public List<WorkOrder> QualityOfficerW { get; set; }//Kullanıcının bulunduğu projeler - İlişkili tablo.
        public List<WorkOrder> WorkOrderCreatorW { get; set; }//Kullanıcının bulunduğu projeler - İlişkili tablo.
        public List<UserNotification> UserNotifications { get; set; }//Kullanıcıya ait bildirimler - İlişkili tablo.
        public List<FinalQuality> QualityTechnicianQ { get; set; }//Kullanıcının bulunduğu projeler - İlişkili tablo.
        public List<FinalQuality> QualityOfficerQ { get; set; }//Kullanıcının bulunduğu projeler - İlişkili tablo.
    }
}
