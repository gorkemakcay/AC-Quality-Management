using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QM.Entities.Concrete.Notifications;
using System;

namespace QM.DataAccess.Mapping.Notifications
{
    public class UserNotificationMap : IEntityTypeConfiguration<UserNotification>
    {
        /// <summary>
        /// UserNotification sınıfındaki veri tiplerini ayarlar.
        /// </summary>
        /// <param name="builder">EntityTypeBuilder<UserNotification></param>
        public void Configure(EntityTypeBuilder<UserNotification> builder)
        {
            builder.HasKey(I => new { I.AppUserId, I.NotificationId });//Composite Key.

            #region Foreign Keys

            builder.HasOne(I => I.AppUser).WithMany(I => I.UserNotifications).HasForeignKey(I => I.AppUserId).IsRequired().OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(I => I.Notification).WithMany(I => I.UserNotifications).HasForeignKey(I => I.NotificationId).IsRequired().OnDelete(DeleteBehavior.Restrict);

            #endregion

        }
    }
}
