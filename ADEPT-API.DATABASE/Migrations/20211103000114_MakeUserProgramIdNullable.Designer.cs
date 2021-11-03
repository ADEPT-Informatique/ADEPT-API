﻿// <auto-generated />
using System;
using ADEPT_API.DATABASE.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace ADEPT_API.DATABASE.Migrations
{
    [DbContext(typeof(AdeptContext))]
    [Migration("20211103000114_MakeUserProgramIdNullable")]
    partial class MakeUserProgramIdNullable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.9")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ADEPT_API.DATABASE.Models.Discord.DiscordStatusLog", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BannedId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatedByUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedTimestampUtc")
                        .HasColumnType("bigint");

                    b.Property<long?>("Duration")
                        .HasColumnType("bigint");

                    b.Property<string>("Reason")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ReservionLogId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BannedId");

                    b.HasIndex("CreatedByUserId");

                    b.HasIndex("ReservionLogId");

                    b.ToTable("DiscordStatuLogs");
                });

            modelBuilder.Entity("ADEPT_API.DATABASE.Models.MembreConfiance.Application", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<long>("CreatedTimestampUtc")
                        .HasColumnType("bigint");

                    b.Property<long?>("ReviewedTimestampUtc")
                        .HasColumnType("bigint");

                    b.Property<Guid?>("ReviewerUserId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("State")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ReviewerUserId");

                    b.HasIndex("UserId");

                    b.ToTable("Applications");
                });

            modelBuilder.Entity("ADEPT_API.DATABASE.Models.MembreConfiance.ApplicationQuestion", b =>
                {
                    b.Property<Guid>("ApplicationId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Answer")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ApplicationId", "QuestionId");

                    b.HasIndex("QuestionId");

                    b.ToTable("ApplicationQuestion");
                });

            modelBuilder.Entity("ADEPT_API.DATABASE.Models.MembreConfiance.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("Activated")
                        .HasColumnType("bit");

                    b.Property<string>("Content")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("ADEPT_API.DATABASE.Models.Users.StudyProgram", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("StudyPrograms");
                });

            modelBuilder.Entity("ADEPT_API.DATABASE.Models.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DiscordId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FireBaseID")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("ProgramId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("StudentNumber")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("FireBaseID");

                    b.HasIndex("ProgramId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ADEPT_API.DATABASE.Models.Users.UserRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Role")
                        .HasColumnType("int");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("ADEPT_API.DATABASE.Models.Discord.DiscordStatusLog", b =>
                {
                    b.HasOne("ADEPT_API.DATABASE.Models.Users.User", "BannedUser")
                        .WithMany()
                        .HasForeignKey("BannedId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ADEPT_API.DATABASE.Models.Users.User", "CreatedByUser")
                        .WithMany()
                        .HasForeignKey("CreatedByUserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ADEPT_API.DATABASE.Models.Discord.DiscordStatusLog", "ReversionLog")
                        .WithMany()
                        .HasForeignKey("ReservionLogId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BannedUser");

                    b.Navigation("CreatedByUser");

                    b.Navigation("ReversionLog");
                });

            modelBuilder.Entity("ADEPT_API.DATABASE.Models.MembreConfiance.Application", b =>
                {
                    b.HasOne("ADEPT_API.DATABASE.Models.Users.User", "Reviewer")
                        .WithMany()
                        .HasForeignKey("ReviewerUserId");

                    b.HasOne("ADEPT_API.DATABASE.Models.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Reviewer");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ADEPT_API.DATABASE.Models.MembreConfiance.ApplicationQuestion", b =>
                {
                    b.HasOne("ADEPT_API.DATABASE.Models.MembreConfiance.Application", "Application")
                        .WithMany("ApplicationQuestions")
                        .HasForeignKey("ApplicationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ADEPT_API.DATABASE.Models.MembreConfiance.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Application");

                    b.Navigation("Question");
                });

            modelBuilder.Entity("ADEPT_API.DATABASE.Models.Users.User", b =>
                {
                    b.HasOne("ADEPT_API.DATABASE.Models.Users.StudyProgram", "Program")
                        .WithMany()
                        .HasForeignKey("ProgramId");

                    b.Navigation("Program");
                });

            modelBuilder.Entity("ADEPT_API.DATABASE.Models.Users.UserRole", b =>
                {
                    b.HasOne("ADEPT_API.DATABASE.Models.Users.User", "User")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("ADEPT_API.DATABASE.Models.MembreConfiance.Application", b =>
                {
                    b.Navigation("ApplicationQuestions");
                });

            modelBuilder.Entity("ADEPT_API.DATABASE.Models.Users.User", b =>
                {
                    b.Navigation("Roles");
                });
#pragma warning restore 612, 618
        }
    }
}
