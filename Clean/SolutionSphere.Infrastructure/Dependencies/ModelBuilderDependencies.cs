using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolutionSphere.Infrastructure.Configuration.BaseConfigurations;

namespace SolutionSphere.Infrastructure.Dependencies
{
    public static class ModelBuilderDependencies
    {
        public static void AddConfiguration<TEntity>(this ModelBuilder modelBuilder, DbEntityConfiguration<TEntity> entityConfiguration) where TEntity : class
        {
            modelBuilder.Entity(new Action<EntityTypeBuilder<TEntity>>(entityConfiguration.Configure));
        }
    }
}
