using QM.Entities.Concrete.FinalQualities;
using QM.Entities.Concrete.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.Common.ViewModels.FinalQualities.FinalQualityViewModels
{
    public class FinalQualityListViewModel
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
        public DateTime ApprovalDate { get; set; }
        public string ApprovalBy { get; set; }
        public string Signature { get; set; }
        public string ProductSerialNo { get; set; }
        public string Status { get; set; }
        public int RevisionCount { get; set; }

        public List<FQControl> FQControls { get; set; }
        public List<Revision> Revisions { get; set; }
    }
}
