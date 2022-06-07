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
    public class ProductMap : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
            builder.Property(I => I.ProductModel).HasMaxLength(150).IsRequired();
            builder.Property(I => I.ProductCode).HasMaxLength(150).IsRequired();
            builder.Property(I => I.ProductSerialCode).HasMaxLength(150).IsRequired();
            builder.HasOne(I => I.WorkOrder).WithMany(I => I.Products).HasForeignKey(I => I.WorkOrderId).IsRequired().OnDelete(DeleteBehavior.Restrict);
        }
    }
}
