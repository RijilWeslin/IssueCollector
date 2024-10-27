using Microsoft.EntityFrameworkCore;
using SolutionSphere.Core.Entities;
using SolutionSphere.Core.Entities.BaseEntities;
using SolutionSphere.Infrastructure.Configuration;
using SolutionSphere.Infrastructure.Configuration.BaseConfigurations;
using SolutionSphere.Infrastructure.Dependencies;

namespace SolutionSphere.Infrastructure.Data
{
    public class SolutionSphereDbContext:DbContext
    {
        public SolutionSphereDbContext(DbContextOptions<SolutionSphereDbContext> options):base(options)
        {
            
        }

        #region
        /*public DbSet<Temp> Temp { get; set; }*/
        /*public DbSet<Project> Project { get; set; }*/
        public DbSet<IssueData> IssueData { get; set; }
        public DbSet<SolutionData> SolutionData { get;set; }
        #endregion
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            ApplyGlobalConfigurations(ref modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        #region GlobalConfiguration
        public void ApplyGlobalConfigurations(ref ModelBuilder modelBuilder)
        {
            /*modelBuilder.AddConfiguration(new TempConfiguration());            */
            modelBuilder.AddConfiguration(new IssueDataConfiguration());
            modelBuilder.AddConfiguration(new SolutionDataConfiguration());
        }
        #endregion
    }
}
