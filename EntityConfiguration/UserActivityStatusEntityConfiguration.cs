using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using signalr_core_demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signalr_core_demo.EntityConfiguration
{
    public class UserActivityStatusEntityConfiguration : IEntityTypeConfiguration<UserActivityStatusEntity>
    {
        public void Configure(EntityTypeBuilder<UserActivityStatusEntity> builder)
        {
            builder.Property(x => x.id)
                  .UseIdentityColumn();

            builder.Property(x => x.lastOnlineTimestamp);

            builder.Property(x => x.userDeviceIpAddress);
        }
    }
}
