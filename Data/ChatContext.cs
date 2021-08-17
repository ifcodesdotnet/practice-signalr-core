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

        public virtual DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=localhost, 3100;initial catalog=ChatDatabase;user id=sa; password=isamel234@22222;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.id)
                .UseIdentityColumn(); 
                
                entity.Property(e => e.firstName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
