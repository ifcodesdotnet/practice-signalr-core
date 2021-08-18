﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using signalr_core_demo.Data;

namespace signalr_core_demo.Migrations
{
    [DbContext(typeof(ChatContext))]
    [Migration("20210818225306_AddingEmailAddress")]
    partial class AddingEmailAddress
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("signalr_core_demo.Entities.UserActivityStatusEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("UserEntityid")
                        .HasColumnType("int");

                    b.Property<DateTime>("lastOnlineTimestamp")
                        .HasColumnType("datetime2");

                    b.Property<string>("userDeviceIpAddress")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.HasIndex("UserEntityid");

                    b.ToTable("UserActivityStatus");
                });

            modelBuilder.Entity("signalr_core_demo.Entities.UserEntity", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:IdentityIncrement", 1)
                        .HasAnnotation("SqlServer:IdentitySeed", 1)
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("emailAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("firstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("lastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("id");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            id = 1,
                            firstName = "Ismael",
                            lastName = "Fernandez"
                        },
                        new
                        {
                            id = 2,
                            firstName = "Bob",
                            lastName = "Smith"
                        });
                });

            modelBuilder.Entity("signalr_core_demo.Entities.UserActivityStatusEntity", b =>
                {
                    b.HasOne("signalr_core_demo.Entities.UserEntity", null)
                        .WithMany("activityStatus")
                        .HasForeignKey("UserEntityid");
                });

            modelBuilder.Entity("signalr_core_demo.Entities.UserEntity", b =>
                {
                    b.Navigation("activityStatus");
                });
#pragma warning restore 612, 618
        }
    }
}
