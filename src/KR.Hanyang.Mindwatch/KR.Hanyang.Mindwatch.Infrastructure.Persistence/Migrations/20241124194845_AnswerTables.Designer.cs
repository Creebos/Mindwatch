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
    [Migration("20241124194845_AnswerTables")]
    partial class AnswerTables
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

                    b.Property<int>("AnsweredByEmployeeId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionId")
                        .HasColumnType("int");

                    b.Property<int>("QuestionnaireRunId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AnsweredByEmployeeId");

                    b.HasIndex("QuestionId");

                    b.HasIndex("QuestionnaireRunId");

                    b.ToTable("Answers");
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

                    b.Property<string>("ShortName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

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

                    b.Property<int>("CreatedByEmployeeId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CreatedByEmployeeId");

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

                    b.Property<int>("InitiatedByEmployeeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("OpenDateTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("QuestionnaireId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("InitiatedByEmployeeId");

                    b.HasIndex("QuestionnaireId");

                    b.ToTable("QuestionnaireRuns");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Answer", b =>
                {
                    b.HasOne("KR.Hanyang.Mindwatch.Domain.Entities.Employee", "AnsweredByEmployee")
                        .WithMany()
                        .HasForeignKey("AnsweredByEmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("KR.Hanyang.Mindwatch.Domain.Entities.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("KR.Hanyang.Mindwatch.Domain.Entities.QuestionnaireRun", "QuestionnaireRun")
                        .WithMany()
                        .HasForeignKey("QuestionnaireRunId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("AnsweredByEmployee");

                    b.Navigation("Question");

                    b.Navigation("QuestionnaireRun");
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

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Questionnaire", b =>
                {
                    b.HasOne("KR.Hanyang.Mindwatch.Domain.Entities.Employee", "CreatedByEmployee")
                        .WithMany("CreatedQuestionnaires")
                        .HasForeignKey("CreatedByEmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("CreatedByEmployee");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.QuestionnaireRun", b =>
                {
                    b.HasOne("KR.Hanyang.Mindwatch.Domain.Entities.Employee", "InitiatedByEmployee")
                        .WithMany("InitiatedQuestionnaireRuns")
                        .HasForeignKey("InitiatedByEmployeeId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.HasOne("KR.Hanyang.Mindwatch.Domain.Entities.Questionnaire", "Questionnaire")
                        .WithMany("QuestionnaireRuns")
                        .HasForeignKey("QuestionnaireId")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("InitiatedByEmployee");

                    b.Navigation("Questionnaire");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Employee", b =>
                {
                    b.Navigation("CreatedQuestionnaires");

                    b.Navigation("InitiatedQuestionnaireRuns");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Questionnaire", b =>
                {
                    b.Navigation("QuestionnaireRuns");

                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}
