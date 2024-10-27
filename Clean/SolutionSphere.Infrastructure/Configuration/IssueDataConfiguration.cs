using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SolutionSphere.Core.Entities;
using SolutionSphere.Infrastructure.Configuration.BaseConfigurations;

namespace SolutionSphere.Infrastructure.Configuration
{
    public class IssueDataConfiguration:BaseConfiguration<IssueData>
    {
        public override void Configure(EntityTypeBuilder<IssueData> entityBuilder)
        {
            entityBuilder.HasIndex(e => e.Id);
            entityBuilder.Property(e => e.UserId).IsRequired();
            entityBuilder.Property(e => e.Title);
            entityBuilder.HasMany(e=>e.Solution).WithOne().HasForeignKey(e=>e.IssueId).OnDelete(DeleteBehavior.Restrict);
            entityBuilder.HasOne(e=>e.Project).WithMany().HasForeignKey(e=>e.ProjectCode).OnDelete(DeleteBehavior.Restrict);
            /*entityBuilder.HasOne(e => e.Project).WithMany().HasForeignKey(a => a.ProjectCode).OnDelete(DeleteBehavior.Restrict);*/
            entityBuilder.Property(e => e.Description).IsRequired(false);
            entityBuilder.Property(e => e.SolutionAvailable);
            base.Configure(entityBuilder);
        }
    }
}