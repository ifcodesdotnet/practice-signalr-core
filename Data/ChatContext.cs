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
        public virtual DbSet<ConnectionEntity> Connections { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("data source=localhost, 3100;initial catalog=ChatDatabase;user id=SA; password=isamel234@22222;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ChatContext).Assembly);
        }
    }
}
