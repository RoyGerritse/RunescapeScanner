﻿// <auto-generated />
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using Scanner.Infrastructure.Database;

#nullable disable

namespace Scanner.Infrastructure.Database.Migrations
{
    [DbContext(typeof(RunescapeContext))]
    [Migration("20241103124141_CorrectRelations")]
    partial class CorrectRelations
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            NpgsqlModelBuilderExtensions.HasPostgresExtension(modelBuilder, "hstore");
            NpgsqlModelBuilderExtensions.UseIdentityByDefaultColumns(modelBuilder);

            modelBuilder.Entity("Scanner.Domain.Entities.Activity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Activity");
                });

            modelBuilder.Entity("Scanner.Domain.Entities.ActivityStat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ActivityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GameVersionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid");

                    b.Property<long>("Rank")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("GameVersionId");

                    b.HasIndex("PlayerId");

                    b.ToTable("ActivityStat");
                });

            modelBuilder.Entity("Scanner.Domain.Entities.ActivityStatHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<Guid>("ActivityId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("GameVersionId")
                        .HasColumnType("uuid");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid");

                    b.Property<long>("Rank")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RecordedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<long>("Score")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ActivityId");

                    b.HasIndex("GameVersionId");

                    b.HasIndex("PlayerId");

                    b.ToTable("ActivityStatHistory");
                });

            modelBuilder.Entity("Scanner.Domain.Entities.CurrentSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<bool>("Active")
                        .HasColumnType("boolean");

                    b.Property<string>("SessionName")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Dictionary<string, string>>("Setting")
                        .IsRequired()
                        .HasColumnType("hstore");

                    b.HasKey("Id");

                    b.ToTable("CurrentSession");
                });

            modelBuilder.Entity("Scanner.Domain.Entities.GameVersion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("GameVersion");

                    b.HasData(
                        new
                        {
                            Id = new Guid("8d292ae5-87c6-44f6-a7a7-71898af17f52"),
                            Name = "OSRS"
                        },
                        new
                        {
                            Id = new Guid("83cce0f7-3d54-437c-b4c1-3f270792fc8c"),
                            Name = "RS3"
                        });
                });

            modelBuilder.Entity("Scanner.Domain.Entities.Player", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<int>("AccountType")
                        .HasColumnType("integer");

                    b.Property<Guid?>("GameVersionId")
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("GameVersionId");

                    b.ToTable("Player");
                });

            modelBuilder.Entity("Scanner.Domain.Entities.Skill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Skill");
                });

            modelBuilder.Entity("Scanner.Domain.Entities.SkillStat", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("Experience")
                        .HasColumnType("bigint");

                    b.Property<Guid>("GameVersionId")
                        .HasColumnType("uuid");

                    b.Property<DateTime>("LastUpdated")
                        .HasColumnType("timestamp with time zone");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid");

                    b.Property<long>("Rank")
                        .HasColumnType("bigint");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GameVersionId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SkillId");

                    b.ToTable("SkillStat");
                });

            modelBuilder.Entity("Scanner.Domain.Entities.SkillStatHistory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<long>("Experience")
                        .HasColumnType("bigint");

                    b.Property<Guid>("GameVersionId")
                        .HasColumnType("uuid");

                    b.Property<int>("Level")
                        .HasColumnType("integer");

                    b.Property<Guid>("PlayerId")
                        .HasColumnType("uuid");

                    b.Property<long>("Rank")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("RecordedAt")
                        .HasColumnType("timestamp with time zone");

                    b.Property<Guid>("SkillId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("GameVersionId");

                    b.HasIndex("PlayerId");

                    b.HasIndex("SkillId");

                    b.ToTable("SkillStatHistory");
                });

            modelBuilder.Entity("Scanner.Domain.Entities.ActivityStat", b =>
                {
                    b.HasOne("Scanner.Domain.Entities.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scanner.Domain.Entities.GameVersion", "GameVersion")
                        .WithMany()
                        .HasForeignKey("GameVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scanner.Domain.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("GameVersion");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Scanner.Domain.Entities.ActivityStatHistory", b =>
                {
                    b.HasOne("Scanner.Domain.Entities.Activity", "Activity")
                        .WithMany()
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scanner.Domain.Entities.GameVersion", "GameVersion")
                        .WithMany()
                        .HasForeignKey("GameVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scanner.Domain.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("GameVersion");

                    b.Navigation("Player");
                });

            modelBuilder.Entity("Scanner.Domain.Entities.Player", b =>
                {
                    b.HasOne("Scanner.Domain.Entities.GameVersion", "GameVersion")
                        .WithMany("Players")
                        .HasForeignKey("GameVersionId");

                    b.Navigation("GameVersion");
                });

            modelBuilder.Entity("Scanner.Domain.Entities.SkillStat", b =>
                {
                    b.HasOne("Scanner.Domain.Entities.GameVersion", "GameVersion")
                        .WithMany()
                        .HasForeignKey("GameVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scanner.Domain.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scanner.Domain.Entities.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameVersion");

                    b.Navigation("Player");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Scanner.Domain.Entities.SkillStatHistory", b =>
                {
                    b.HasOne("Scanner.Domain.Entities.GameVersion", "GameVersion")
                        .WithMany()
                        .HasForeignKey("GameVersionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scanner.Domain.Entities.Player", "Player")
                        .WithMany()
                        .HasForeignKey("PlayerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Scanner.Domain.Entities.Skill", "Skill")
                        .WithMany()
                        .HasForeignKey("SkillId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("GameVersion");

                    b.Navigation("Player");

                    b.Navigation("Skill");
                });

            modelBuilder.Entity("Scanner.Domain.Entities.GameVersion", b =>
                {
                    b.Navigation("Players");
                });
#pragma warning restore 612, 618
        }
    }
}
