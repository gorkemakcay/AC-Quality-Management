using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QM.DataAccess.Mapping.FinalQualities;
using QM.DataAccess.Mapping.Notifications;
using QM.DataAccess.Mapping.Users;
using QM.DataAccess.Mapping.WorkOrders;
using QM.Entities.Concrete.Documents;
using QM.Entities.Concrete.FinalQualities;
using QM.Entities.Concrete.Notifications;
using QM.Entities.Concrete.Users;
using QM.Entities.Concrete.WorkOrders;

namespace QM.DataAccess.Concrete.EntityFrameworkCore.Context
{
    /// <summary>
    /// Veri tabanı işlemleri
    /// </summary>
    public class ArlentusBIContext : IdentityDbContext<AppUser, AppRole, int>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-P12SOIP\SQLEXPRESS;Database=ArlentusDeneme1;uid=umutd;pwd=Ud4583!");
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelbuilder)
        {
            modelbuilder.ApplyConfiguration(new AppRoleMap());
            modelbuilder.ApplyConfiguration(new AppUserMap());
            modelbuilder.ApplyConfiguration(new FinalQualityMap());
            modelbuilder.ApplyConfiguration(new FQControlMap());
            modelbuilder.ApplyConfiguration(new RevisionMap());
            modelbuilder.ApplyConfiguration(new WorkOrderMap());
            modelbuilder.ApplyConfiguration(new ProductMap());
            modelbuilder.ApplyConfiguration(new ManuelScenarioMap());
            modelbuilder.ApplyConfiguration(new NotificationMap());
            modelbuilder.ApplyConfiguration(new UserNotificationMap());
            base.OnModelCreating(modelbuilder);
        }
        public DbSet<AppUser> AspNetUsers { get; set; }
        public DbSet<AppRole> AspNetRoles { get; set; }
        public DbSet<FinalQuality> FinalQualities { get; set; }
        public DbSet<FQControl> FQControls { get; set; }
        public DbSet<Revision> Revisions { get; set; }
        public DbSet<WorkOrder> WorkOrders { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ManuelScenario> ManuelScenarios { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<UserNotification> UserNotifications { get; set; }
    }
}
