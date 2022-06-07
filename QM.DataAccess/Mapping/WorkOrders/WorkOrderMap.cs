using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QM.Entities.Concrete.WorkOrders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.DataAccess.Mapping.WorkOrders
{
    public class WorkOrderMap : IEntityTypeConfiguration<WorkOrder>
    {
        public void Configure(EntityTypeBuilder<WorkOrder> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.CreatedDate).IsRequired();
            builder.Property(I => I.WorkOrderNo).IsRequired();
            builder.Property(I => I.Company).HasMaxLength(150).IsRequired();
            builder.Property(I => I.PlannedStartingDate).IsRequired();
            builder.Property(I => I.ProjectCode).HasMaxLength(150).IsRequired();
            builder.Property(I => I.SalesOrderCode).HasMaxLength(150).IsRequired();
            builder.Property(I => I.PlannedFinishedDate).IsRequired();
            builder.Property(I => I.Status).HasMaxLength(150).IsRequired();
            builder.Property(I => I.LotStatus).HasMaxLength(150).IsRequired();
            builder.Property(I => I.TestNo).HasMaxLength(15).IsRequired();
            builder.Property(I => I.StationNo).HasMaxLength(15).IsRequired();
            builder.Property(I => I.StationName).HasMaxLength(150).IsRequired();
            builder.Property(I => I.DeliveryDate).IsRequired();

            builder.HasOne(I => I.Owner).WithMany(I => I.ProjectOwner).HasForeignKey(I => I.OwnerId).IsRequired().OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(I => I.MontageTechnicianName).WithMany(I => I.ProjectStaffs).HasForeignKey(I => I.MontageTechnicianId).IsRequired().OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(I => I.QualityTechnicianName).WithMany(I => I.QualityTechnicianW).HasForeignKey(I => I.QualityTechnicianId).IsRequired().OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(I => I.QualityOfficerName).WithMany(I => I.QualityOfficerW).HasForeignKey(I => I.QualityOfficerId).IsRequired().OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(I => I.ProjectCreator).WithMany(I => I.WorkOrderCreatorW).HasForeignKey(I => I.ProjectCreatorId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
