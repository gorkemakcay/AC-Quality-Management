using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QM.Entities.Concrete.FinalQualities;
using System;

namespace QM.DataAccess.Mapping.FinalQualities
{
    public class FinalQualityMap : IEntityTypeConfiguration<FinalQuality>
    {
        public void Configure(EntityTypeBuilder<FinalQuality> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.Customer).HasMaxLength(150).IsRequired();
            builder.Property(I => I.WorkOrderNo).IsRequired();
            builder.Property(I => I.MaterialName).HasMaxLength(150).IsRequired();
            builder.Property(I => I.TechnicianName).HasMaxLength(150).IsRequired();
            builder.Property(I => I.MaterialCode).HasMaxLength(150).IsRequired();
            builder.Property(I => I.AcceptanceDate).IsRequired();
            builder.Property(I => I.LotStatus).HasMaxLength(150).IsRequired();
            builder.Property(I => I.StationNo).HasMaxLength(150).IsRequired();
            builder.Property(I => I.StationName).HasMaxLength(150).IsRequired();
            builder.Property(I => I.TestNo).HasMaxLength(150).IsRequired();
            builder.Property(I => I.DeliveryDate).IsRequired();
            builder.Property(I => I.EngineersNote).HasMaxLength(500).IsRequired(false);
            builder.Property(I => I.ApprovalDate).IsRequired(false);
            builder.Property(I => I.ApprovalBy).HasMaxLength(150).IsRequired(false);
            builder.Property(I => I.Signature).HasMaxLength(150).IsRequired(false);
            builder.Property(I => I.ProductSerialNo).HasMaxLength(150).IsRequired(false);
            builder.Property(I => I.Status).HasMaxLength(150).IsRequired();
            builder.Property(I => I.RevisionCount).IsRequired(false);

            builder.HasOne(I => I.QualityTechnicianName).WithMany(I => I.QualityTechnicianQ).HasForeignKey(I => I.QualityTechnicianId).IsRequired().OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(I => I.QualityOfficerName).WithMany(I => I.QualityOfficerQ).HasForeignKey(I => I.QualityOfficerId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}