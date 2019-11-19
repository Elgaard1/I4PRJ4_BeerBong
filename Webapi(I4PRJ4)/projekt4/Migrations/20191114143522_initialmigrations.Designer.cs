﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using projekt4.Model;

namespace projekt4.Migrations
{
    [DbContext(typeof(BBMContext))]
    [Migration("20191114143522_initialmigrations")]
    partial class initialmigrations
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("projekt4.Model.Bruger", b =>
                {
                    b.Property<int>("BrugerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateCreated")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("Date")
                        .HasColumnType("date")
                        .HasDefaultValueSql("GETDATE()");

                    b.Property<int?>("GameId")
                        .HasColumnType("int");

                    b.Property<int?>("LeaderBoardId")
                        .HasColumnType("int");

                    b.Property<string>("PassWord")
                        .HasColumnName("Password")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("QueueId")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .HasColumnName("User_Name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.HasKey("BrugerId");

                    b.HasIndex("GameId");

                    b.HasIndex("LeaderBoardId");

                    b.HasIndex("QueueId");

                    b.ToTable("Brguers");
                });

            modelBuilder.Entity("projekt4.Model.Game", b =>
                {
                    b.Property<int>("GameId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Time")
                        .HasColumnName("Result from drinking bear")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GameId");

                    b.ToTable("Games");
                });

            modelBuilder.Entity("projekt4.Model.LeaderBoard", b =>
                {
                    b.Property<int>("LeaderBoardId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Time")
                        .HasColumnName("Best Time")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("LeaderBoardId");

                    b.ToTable("LeaderBoards");
                });

            modelBuilder.Entity("projekt4.Model.Participant", b =>
                {
                    b.Property<int>("ParticipantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("BrugerId")
                        .HasColumnType("int");

                    b.Property<string>("ParticipantName")
                        .HasColumnName("Participant_name")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<int?>("QueueId")
                        .HasColumnType("int");

                    b.Property<double>("RestultTime")
                        .HasColumnName("Result_from_drinking")
                        .HasColumnType("float");

                    b.HasKey("ParticipantId");

                    b.HasIndex("BrugerId");

                    b.HasIndex("QueueId");

                    b.ToTable("Participants");
                });

            modelBuilder.Entity("projekt4.Model.Queue", b =>
                {
                    b.Property<int>("QueueId")
                        .ValueGeneratedOnAdd()
                        .HasColumnName("id")
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<byte[]>("TimeStamp")
                        .IsRequired()
                        .HasColumnName("date_created")
                        .HasColumnType("Timestamp");

                    b.HasKey("QueueId");

                    b.ToTable("Queues");
                });

            modelBuilder.Entity("projekt4.Model.Bruger", b =>
                {
                    b.HasOne("projekt4.Model.Game", "Game")
                        .WithMany("Brugers")
                        .HasForeignKey("GameId");

                    b.HasOne("projekt4.Model.LeaderBoard", "LeaderBoard")
                        .WithMany("Brugers")
                        .HasForeignKey("LeaderBoardId");

                    b.HasOne("projekt4.Model.Queue", "Queue")
                        .WithMany()
                        .HasForeignKey("QueueId");
                });

            modelBuilder.Entity("projekt4.Model.Participant", b =>
                {
                    b.HasOne("projekt4.Model.Bruger", "Bruger")
                        .WithMany("Participants")
                        .HasForeignKey("BrugerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("projekt4.Model.Queue", null)
                        .WithMany("Participants")
                        .HasForeignKey("QueueId");
                });
#pragma warning restore 612, 618
        }
    }
}
