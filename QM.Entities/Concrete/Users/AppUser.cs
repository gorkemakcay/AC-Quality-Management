using Microsoft.AspNetCore.Identity;
using QM.Entities.Concrete.FinalQualities;
using QM.Entities.Concrete.Notifications;
using QM.Entities.Concrete.WorkOrders;
using QM.Entities.Interface;
using System;
using System.Collections.Generic;

namespace QM.Entities.Concrete.Users
{
    public class AppUser : IdentityUser<int>, ITable
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Gender { get; set; }
        public string Picture { get; set; }
        public string DepartmentName { get; set; }

        public List<WorkOrder> ProjectOwner { get; set; }//Kullanıcının sahibi olduğu projeler - İlişkili tablo.
        public List<WorkOrder> ProjectStaffs { get; set; }//Kullanıcının bulunduğu projeler - İlişkili tablo.
        public List<WorkOrder> QualityTechnicianW { get; set; }//Kullanıcının bulunduğu projeler - İlişkili tablo.
        public List<WorkOrder> QualityOfficerW { get; set; }//Kullanıcının bulunduğu projeler - İlişkili tablo.
        public List<WorkOrder> WorkOrderCreatorW { get; set; }//Kullanıcının bulunduğu projeler - İlişkili tablo.
        public List<UserNotification> UserNotifications { get; set; }//Kullanıcıya ait bildirimler - İlişkili tablo.
        public List<FinalQuality> QualityTechnicianQ { get; set; }//Kullanıcının bulunduğu projeler - İlişkili tablo.
        public List<FinalQuality> QualityOfficerQ { get; set; }//Kullanıcının bulunduğu projeler - İlişkili tablo.
    }
}