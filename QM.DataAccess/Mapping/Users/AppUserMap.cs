using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QM.Entities.Concrete.Users;
using System;

namespace QM.DataAccess.Mapping.Users
{
    public class AppUserMap : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> builder)
        {
            builder.Property(I => I.FirstName).HasMaxLength(100).IsRequired();
            builder.Property(I => I.LastName).HasMaxLength(100).IsRequired();
            builder.Property(I => I.FullName).HasMaxLength(1500).IsRequired();
            builder.Property(I => I.Gender).HasMaxLength(25).IsRequired();
            builder.Property(I => I.DepartmentName).HasMaxLength(50).IsRequired();
        }
    }
}
