using System;

namespace QM.Common.ViewModels.FinalQualities.FinalQualityViewModels
{
    public class FinalQualityAddViewModel
    {
        public string Customer { get; set; }
        public string WorkOrderNo { get; set; }
        public string MaterialName { get; set; }
        public string TechnicianName { get; set; }
        public string ProjectOwner { get; set; }
        public int QualityTechnicianId { get; set; }
        public int QualityOfficerId { get; set; }
        public string MaterialCode { get; set; }
        public DateTime AcceptanceDate { get; set; }        
        public string LotStatus { get; set; }
        public string StationNo { get; set; }
        public string StationName { get; set; }
        public string TestNo { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string EngineersNote { get; set; }
        public DateTime ApprovalDate { get; set; }
        public string ApprovalBy { get; set; }
        public string Signature { get; set; }
        public string ProductSerialNo { get; set; }
        public string Status { get; set; }
        public int RevisionCount { get; set; }
    }
}
