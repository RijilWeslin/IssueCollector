using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolutionSphere.Core.Entities;
using SolutionSphere.Infrastructure.Configuration.BaseConfigurations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionSphere.Infrastructure.Configuration
{
    public class SolutionDataConfiguration : BaseConfiguration<SolutionData>
    {
        public override void Configure(EntityTypeBuilder<SolutionData> entityBuilder)
        {
            entityBuilder.HasKey(x => x.Id);
            entityBuilder.Property(x => x.Solution).HasMaxLength(5000).IsRequired();
            base.Configure(entityBuilder);
        }
    }
}
