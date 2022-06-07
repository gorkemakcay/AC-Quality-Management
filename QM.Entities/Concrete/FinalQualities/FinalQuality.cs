using QM.Entities.Concrete.Notifications;
using QM.Entities.Concrete.Users;
using QM.Entities.Interface;
using System;
using System.Collections.Generic;

namespace QM.Entities.Concrete.FinalQualities
{
    public class FinalQuality : ITable
    {
        public int Id { get; set; }
        public string Customer { get; set; }
        public string WorkOrderNo { get; set; }
        public string MaterialName { get; set; }

        public string TechnicianName { get; set; }
        public string ProjectOwner { get; set; }

        public int QualityTechnicianId { get; set; }
        public AppUser QualityTechnicianName { get; set; }

        public int QualityOfficerId { get; set; }
        public AppUser QualityOfficerName { get; set; }

        public string MaterialCode { get; set; }
        public DateTime AcceptanceDate { get; set; }
        public string LotStatus { get; set; }
        public string StationNo { get; set; }
        public string StationName { get; set; }
        public string TestNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string EngineersNote { get; set; }
        public DateTime? ApprovalDate { get; set; }
        public string ApprovalBy { get; set; }
        public string Signature { get; set; }
        public string Status { get; set; }
        public string ProductSerialNo { get; set; }
        public int? RevisionCount { get; set; }
        public List<Revision> Revisions { get; set; }
        public List<FQControl> FQControls { get; set; }
        public List<Notification> Notifications { get; set; }//Göreve ait bildirimler - İlişkili tablo.
    }
}
