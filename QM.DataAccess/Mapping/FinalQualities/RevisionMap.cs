using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QM.Entities.Concrete.FinalQualities;
using System;

namespace QM.DataAccess.Mapping.FinalQualities
{
    public class RevisionMap : IEntityTypeConfiguration<Revision>
    {
        public void Configure(EntityTypeBuilder<Revision> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.RevisionDate).IsRequired();
            builder.Property(I => I.RevisionExplain).HasMaxLength(150).IsRequired();
            builder.Property(I => I.ReasonForRevision).HasMaxLength(150).IsRequired();
            builder.Property(I => I.IntendedPurpose).HasMaxLength(150).IsRequired();
            builder.Property(I => I.RevisionResult).HasMaxLength(150).IsRequired();
            builder.Property(I => I.RevisionType).HasMaxLength(150).IsRequired();
            builder.Property(I => I.RevisionRequestedBy).HasMaxLength(150).IsRequired();
            builder.HasOne(I => I.FinalQuality).WithMany(I => I.Revisions).HasForeignKey(I => I.FinalQualityId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}