using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SolutionSphere.Infrastructure.Configuration.BaseConfigurations
{
    public abstract class DbEntityConfiguration<TEntity> where TEntity : class
    {
        public abstract void Configure(EntityTypeBuilder<TEntity> entityBuilder);
    }
}
