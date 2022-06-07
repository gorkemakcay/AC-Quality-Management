﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.Common.ViewModels.WorkOrders.WorkOrderViewModels
{
    public class WorkOrderAddViewModel
    {
        public DateTime CreatedDate { get; set; }
        public string WorkOrderNo { get; set; }
        public string Company { get; set; }
        public DateTime PlannedStartingDate { get; set; }
        public DateTime? StartingDate { get; set; }

        public int ProjectCreatorId { get; set; }
        public int OwnerId { get; set; }
        public int MontageTechnicianId { get; set; }
        public int QualityTechnicianId { get; set; }
        public int QualityOfficerId { get; set; }

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
    }
}
