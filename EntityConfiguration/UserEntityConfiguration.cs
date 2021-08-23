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
            builder.Property(x => x.Id)
                   .UseIdentityColumn();
            
            builder.HasIndex(x => x.Id)
                    .IsUnique();

            builder.Property(x => x.FirstName)
                   .HasMaxLength(50);

            builder.Property(x => x.LastName)
                   .HasMaxLength(50);

            builder.Property(x => x.EmailAddress)
                   .HasMaxLength(50);

            builder.HasIndex(x => x.EmailAddress)
                    .IsUnique();

            builder.HasMany(x => x.Connections)
                   .WithOne();

            builder.HasData(new[] { 
                new UserEntity(){
                    Id = 1,
                    FirstName = "Ismael", 
                    LastName = "Fernandez",
                    EmailAddress = "test1"
                },
                new UserEntity(){
                    Id = 2,
                    FirstName = "Bob",
                    LastName = "Smith", 
                    EmailAddress = "test2"
                }
            }); 
        }
    }
}
