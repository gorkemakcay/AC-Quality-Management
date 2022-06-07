using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using QM.Entities.Concrete.FinalQualities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QM.DataAccess.Mapping.FinalQualities
{
    internal class FQControlMap : IEntityTypeConfiguration<FQControl>
    {
        public void Configure(EntityTypeBuilder<FQControl> builder)
        {
            builder.HasKey(I => I.Id);
            builder.Property(I => I.Id).UseIdentityColumn();
        }
    }
}