using QM.Entities.Concrete.Notifications;
using QM.Entities.Concrete.Users;
using QM.Entities.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.Entities.Concrete.WorkOrders
{
    public class WorkOrder : ITable
    {
        // date template: dd/mm/yyyy | hh:mm
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; }
        public string WorkOrderNo { get; set; }
        public string Company { get; set; }
        public DateTime PlannedStartingDate { get; set; }
        public DateTime? StartingDate { get; set; }

        public int ProjectCreatorId { get; set; }
        public AppUser ProjectCreator { get; set; }

        public int OwnerId { get; set; }
        public AppUser Owner { get; set; }

        public int MontageTechnicianId { get; set; }
        public AppUser MontageTechnicianName { get; set; }

        public int QualityTechnicianId { get; set; }
        public AppUser QualityTechnicianName { get; set; }

        public int QualityOfficerId { get; set; }
        public AppUser QualityOfficerName { get; set; }

        public string ProjectCode { get; set; }
        public string SalesOrderCode { get; set; }
        public DateTime PlannedFinishedDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Status { get; set; }        
        public string LotStatus { get; set; }
        public string StationNo { get; set; }
        public string StationName { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string TestNo { get; set; }
        public List<Product> Products { get; set; }
        public List<Notification> Notifications { get; set; }//Göreve ait bildirimler - İlişkili tablo.
        public List<ManuelScenario> ManuelScenarios { get; set; }
    }
}
