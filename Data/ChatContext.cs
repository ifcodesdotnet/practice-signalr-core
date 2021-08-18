using Microsoft.EntityFrameworkCore;
using signalr_core_demo.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace signalr_core_demo.Data
{
    public partial class ChatContext : DbContext
    {
        public ChatContext()
        {

        }

        public ChatContext(DbContextOptions<ChatContext> options)
            : base(options)
        {

        }

        public virtual DbSet<UserEntity> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=localhost, 3100;initial catalog=ChatDatabase;user id=SA; password=isamel234@22222;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserEntity>(entity =>
            {
                entity.Property(e => e.id)
                .UseIdentityColumn(); 
                
                entity.Property(e => e.firstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<UserEntity>().HasData(new []{ 
                new UserEntity {
                    id = 1,
                    firstName = "Ismael",
                },
                new UserEntity {
                    id = 2,
                    firstName = "Bob",
                    }
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
