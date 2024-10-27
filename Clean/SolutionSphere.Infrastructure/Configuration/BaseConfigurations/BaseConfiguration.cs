using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolutionSphere.Core.Entities.BaseEntities;

namespace SolutionSphere.Infrastructure.Configuration.BaseConfigurations
{
    public class BaseConfiguration<TEntity>:DbEntityConfiguration<TEntity> where TEntity : class
    {
        public override void Configure(EntityTypeBuilder<TEntity> entityBuilder)
        {
            entityBuilder.Property<bool>("DeleteFlag");
            entityBuilder.Property<DateTime>("Created");
            entityBuilder.Property<string>("CreatedBy").IsRequired(false);
            entityBuilder.Property<DateTime>("Modified");
            entityBuilder.Property<string>("ModifiedBy").IsRequired(false);
            entityBuilder.Property<string>("Data").HasMaxLength(2000).IsRequired(false);
        }
    }
}