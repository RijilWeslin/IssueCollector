using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolutionSphere.Core.Entities;
using SolutionSphere.Core.Entities.BaseEntities;
using SolutionSphere.Infrastructure.Configuration.BaseConfigurations;

namespace SolutionSphere.Infrastructure.Configuration
{
    public class TempConfiguration :BaseConfiguration<Temp>
    {
        public override void Configure(EntityTypeBuilder<Temp> entity)
        {
            entity.HasIndex(i => i.Id);
            entity.Property(i => i.Name).HasMaxLength(20).IsRequired(true);
            entity.Property(i=>i.Description).HasMaxLength(50).IsRequired(true);          
            base.Configure(entity);
        }
    }
}
