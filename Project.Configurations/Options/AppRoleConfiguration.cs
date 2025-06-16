using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Configurations.Options
{
    public class AppRoleConfiguration : BaseConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);
            builder.HasMany(x => x.UserRoles).WithOne(x => x.Role).HasForeignKey(x => x.RoleId).IsRequired();

        }
    }
}
