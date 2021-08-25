using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using signalr_core_demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signalr_core_demo.EntityConfiguration
{
    public class ConnectionEntityEntityConfiguration : IEntityTypeConfiguration<ConnectionEntity>
    {
        public void Configure(EntityTypeBuilder<ConnectionEntity> builder)
        {
            builder.Property(x => x.ConnectionID);

            builder.Property(x => x.Connected);

            builder.Property(x => x.UserAgent);

            builder.Property(x => x.InitiatedTimestamp); 

            builder.Property(x => x.DisconnectedTimestamp);

            builder.HasKey(x => x.ConnectionID);
            
            builder.HasOne(e => e.User)
                .WithMany(c => c.Connections);
        }
    }
}
