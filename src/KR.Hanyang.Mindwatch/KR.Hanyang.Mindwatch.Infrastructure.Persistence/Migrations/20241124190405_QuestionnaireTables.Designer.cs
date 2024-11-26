﻿// <auto-generated />
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
    [Migration("20241124190405_QuestionnaireTables")]
    partial class QuestionnaireTables
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.11")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Employee", b =>
                {
                    b.Navigation("CreatedQuestionnaires");
                });

            modelBuilder.Entity("KR.Hanyang.Mindwatch.Domain.Entities.Questionnaire", b =>
                {
                    b.Navigation("Questions");
                });
#pragma warning restore 612, 618
        }
    }
}