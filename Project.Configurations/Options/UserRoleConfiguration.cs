using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Configurations.Options
{
    public class UserRoleConfiguration : BaseConfiguration<UserRole>
    {
        public override void Configure(EntityTypeBuilder<UserRole> builder)
        {
            base.Configure(builder);
            builder.Ignore(x =>x.Id);
            builder.HasKey(x => new
            {
                x.UserId,
                x.RoleId,
            });
        }
    }
}
