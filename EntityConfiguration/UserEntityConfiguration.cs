using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using signalr_core_demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signalr_core_demo.EntityConfiguration
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<UserEntity>
    {
        public void Configure(EntityTypeBuilder<UserEntity> builder)
        {
            builder.Property(x => x.id)
                   .UseIdentityColumn();

            builder.Property(x => x.firstName)
                   .HasMaxLength(50);

            builder.Property(x => x.lastName)
                   .HasMaxLength(50);

            builder.HasMany(x => x.activityStatus)
                    .WithOne(); 

            builder.HasData(new[] { 
                new UserEntity(){ 
                    id = 1,
                    firstName = "Ismael", 
                    lastName = "Fernandez",
                    emailAddress = "a"
                },
                new UserEntity(){
                    id = 2,
                    firstName = "Bob",
                    lastName = "Smith", 
                    emailAddress = "b"
                }
            }); 
        }
    }
}
