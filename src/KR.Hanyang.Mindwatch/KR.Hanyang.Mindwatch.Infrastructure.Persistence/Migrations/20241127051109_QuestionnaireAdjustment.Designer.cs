﻿// <auto-generated />
using System;
using KR.Hanyang.Mindwatch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace KR.Hanyang.Mindwatch.Infrastructure.Persistence.Migrations
{
    [DbContext(typeof(MindwatchDbContext))]
    [Migration("20241127051109_QuestionnaireAdjustment")]
    partial class QuestionnaireAdjustment
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Answer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AnswerText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionnaireRunId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("QuestionnaireRunId");

                    b.ToTable("Answers");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Attendance", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DurationEnd")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DurationStart")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Attendances");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Commit", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CommitDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("CommitSize")
                        .HasColumnType("int");

                    b.Property<string>("CommitType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Commits");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TeamId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TeamId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Question", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("QuestionText")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuestionnaireId")
                        .HasColumnType("int");

                    b.Property<int>("SortOrder")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("QuestionnaireId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Questionnaire", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Questionnaires");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.QuestionnaireRun", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CloseDateTime")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("EmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OpenDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuestionnaireId")
                        .HasColumnType("int");

                    b.Property<string>("QuestionnaireRunStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("QuestionnaireId");

                    b.ToTable("QuestionnaireRuns");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Team", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SupervisorEmployeeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("SupervisorEmployeeId");

                    b.ToTable("Teams");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Answer", b =>
                {
                    b.HasOne("KR.Hanyang.Mindwatch.Domain.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("KR.Hanyang.Mindwatch.Domain.Entities.QuestionnaireRun", "QuestionnaireRun")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionnaireRunId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Question");

                    b.Navigation("QuestionnaireRun");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Attendance", b =>
                {
                    b.HasOne("KR.Hanyang.Mindwatch.Domain.Entities.Employee", "Employee")
                        .WithMany("Attendances")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Commit", b =>
                {
                    b.HasOne("KR.Hanyang.Mindwatch.Domain.Entities.Employee", "Employee")
                        .WithMany("Commits")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Employee", b =>
                {
                    b.HasOne("KR.Hanyang.Mindwatch.Domain.Entities.Team", "Team")
                        .WithMany("Employees")
                        .HasForeignKey("TeamId")
                        .OnDelete(DeleteBehavior.NoAction);

                    b.Navigation("Team");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Question", b =>
                {
                    b.HasOne("KR.Hanyang.Mindwatch.Domain.Entities.Questionnaire", "Questionnaire")
                        .WithMany("Questions")
                        .HasForeignKey("QuestionnaireId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Questionnaire");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.QuestionnaireRun", b =>
                {
                    b.HasOne("KR.Hanyang.Mindwatch.Domain.Entities.Employee", "Employee")
                        .WithMany("QuestionnaireRuns")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("KR.Hanyang.Mindwatch.Domain.Entities.Questionnaire", "Questionnaire")
                        .WithMany("QuestionnaireRuns")
                        .HasForeignKey("QuestionnaireId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Questionnaire");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Team", b =>
                {
                    b.HasOne("KR.Hanyang.Mindwatch.Domain.Entities.Employee", "SupervisorEmployee")
                        .WithMany("SupervisedTeams")
                        .HasForeignKey("SupervisorEmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("SupervisorEmployee");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Employee", b =>
                {
                    b.Navigation("Attendances");

                    b.Navigation("Commits");

                    b.Navigation("QuestionnaireRuns");

                    b.Navigation("SupervisedTeams");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Questionnaire", b =>
                {
                    b.Navigation("QuestionnaireRuns");

                    b.Navigation("Questions");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.QuestionnaireRun", b =>
                {
                    b.Navigation("Answers");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Team", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
