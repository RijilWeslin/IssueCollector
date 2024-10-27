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
    public class ProjectConfiguration:BaseConfiguration<Project>
    {
        public override void Configure(EntityTypeBuilder<Project> entityBuilder)
        {
            entityBuilder.HasKey(e => e.ProjectId);
            entityBuilder.Property(e => e.ProjectName).IsRequired(true);
            entityBuilder.Property(e => e.ProjectManager);
            entityBuilder.Property(e => e.DeleteFlag);
            base.Configure(entityBuilder);
        }
    }
}
