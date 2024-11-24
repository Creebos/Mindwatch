using KR.Hanyang.Mindwatch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.IdentityModel.Abstractions;

namespace KR.Hanyang.Mindwatch.Infrastructure.Persistence
{
    public class MindwatchDbContext : DbContext
    {
        public MindwatchDbContext(DbContextOptions<MindwatchDbContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Questionnaire> Questionnaires { get; set; }
        public DbSet<QuestionnaireRun> QuestionnaireRuns { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Question
            modelBuilder.Entity<Question>()
                .HasOne(q => q.Questionnaire)
                .WithMany(qn => qn.Questions)
                .HasForeignKey(q => q.QuestionnaireId)
                .OnDelete(DeleteBehavior.NoAction);

            // Questionnaire
            modelBuilder.Entity<Questionnaire>()
                .HasOne(q => q.CreatedByEmployee)
                .WithMany(qn => qn.CreatedQuestionnaires)
                .HasForeignKey(q => q.CreatedByEmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            // Answer
            modelBuilder.Entity<Answer>()
                .HasOne(q => q.Question)
                .WithMany()
                .HasForeignKey(q => q.QuestionId)
                .OnDelete(DeleteBehavior.NoAction);
            
            modelBuilder.Entity<Answer>()
                .HasOne(q => q.QuestionnaireRun)
                .WithMany()
                .HasForeignKey(q => q.QuestionnaireRunId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<Answer>()
                .HasOne(q => q.AnsweredByEmployee)
                .WithMany()
                .HasForeignKey(q => q.AnsweredByEmployeeId)
                .OnDelete(DeleteBehavior.NoAction);

            // QuestionnaireRuns
            modelBuilder.Entity<QuestionnaireRun>()
                .HasOne(q => q.Questionnaire)
                .WithMany(qn => qn.QuestionnaireRuns)
                .HasForeignKey(q => q.QuestionnaireId)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<QuestionnaireRun>()
                .HasOne(q => q.InitiatedByEmployee)
                .WithMany(qn => qn.InitiatedQuestionnaireRuns)
                .HasForeignKey(q => q.InitiatedByEmployeeId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
