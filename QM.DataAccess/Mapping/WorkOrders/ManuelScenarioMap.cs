using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QM.Entities.Concrete.WorkOrders;
using System;

namespace QM.DataAccess.Mapping.WorkOrders
{
    public class ManuelScenarioMap : IEntityTypeConfiguration<ManuelScenario>
    {
        public void Configure(EntityTypeBuilder<ManuelScenario> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Entry).HasMaxLength(100);
            builder.Property(I => I.Explain).HasMaxLength(1000);
            builder.Property(I => I.manualControlStatus);
            builder.HasOne(I => I.WorkOrder).WithMany(I => I.ManuelScenarios).HasForeignKey(I => I.WorkOrderId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
