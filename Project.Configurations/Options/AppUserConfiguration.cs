using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Project.Entities.Models.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Project.Configurations.Options
{
    public class AppUserConfiguration : BaseConfiguration<AppUser>
    {
        public override void Configure(EntityTypeBuilder<AppUser> builder)
        {
            base.Configure(builder);
         
            builder.HasOne(x => x.AppRole).WithOne(x => x.AppUser).HasForeignKey<AppRole>(x => x.AppUserID);
        }
    }
}
