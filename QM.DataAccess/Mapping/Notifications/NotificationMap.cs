using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QM.Entities.Concrete.Notifications;
using System;

namespace QM.DataAccess.Mapping.Notifications
{
    public class NotificationMap : IEntityTypeConfiguration<Notification>
    {
        /// <summary>
        /// Notification sınıfındaki veri tiplerini ayarlar.
        /// </summary>
        /// <param name="builder">EntityTypeBuilder<Notification></param>
        public void Configure(EntityTypeBuilder<Notification> builder)
        {
            builder.HasKey(I => I.Id);

            builder.Property(I => I.Id).UseIdentityColumn();

            builder.Property(I => I.Explain).HasMaxLength(250).IsRequired();

            builder.Property(I => I.Status).IsRequired();

            #region Foreign Keys

            builder.HasOne(I => I.WorkOrder).WithMany(I => I.Notifications).HasForeignKey(I => I.WorkOrderId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(I => I.FinalQuality).WithMany(I => I.Notifications).HasForeignKey(I => I.FinalQualityId).IsRequired(false).OnDelete(DeleteBehavior.Restrict);

            #endregion

        }
    }
}