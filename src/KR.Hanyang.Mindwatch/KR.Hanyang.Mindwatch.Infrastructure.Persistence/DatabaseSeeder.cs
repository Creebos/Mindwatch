using KR.Hanyang.Mindwatch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KR.Hanyang.Mindwatch.Infrastructure.Persistence
{
    public static class DatabaseSeeder
    {
        public static void Seed(MindwatchDbContext context)
        {
            context.Database.EnsureCreated();

            // Employees
            var employees = new[]
            {
                new Employee { Id = 1, Name = "Johnson", FirstName = "Michael", ShortName = "MJ", PhoneNumber = "5551234567", Email = "mjohnson@mindwatch.com", Role = EmployeeRole.Manager },
                new Employee { Id = 2, Name = "Clark", FirstName = "Sarah", ShortName = "SC", PhoneNumber = "5559876543", Email = "sclark@mindwatch.com", Role = EmployeeRole.Manager },
                new Employee { Id = 3, Name = "Doe", FirstName = "John", ShortName = "JD", PhoneNumber = "5551122334", Email = "jdoe@mindwatch.com", Role = EmployeeRole.Employee },
                new Employee { Id = 4, Name = "Smith", FirstName = "Anna", ShortName = "AS", PhoneNumber = "5557788990", Email = "asmith@mindwatch.com", Role = EmployeeRole.Employee }
            };

            InsertOrUpdateEntities(context, context.Employees, employees, e => e.Id);

            // Teams
            var teams = new[]
            {
                new Team { Id = 1, Name = "AI Development Team", SupervisorEmployeeId = 1 },
                new Team { Id = 2, Name = "Tech Support Team", SupervisorEmployeeId = 2 }
            };

            InsertOrUpdateEntities(context, context.Teams, teams, t => t.Id);

            // Questionnaires
            var questionnaires = new[]
            {
                new Questionnaire { Id = 1, Description = "Weekly Stress Assessment" },
                new Questionnaire { Id = 2, Description = "Monthly Team Feedback" }
            };

            InsertOrUpdateEntities(context, context.Questionnaires, questionnaires, q => q.Id);

            // QuestionnaireRuns
            var questionnaireRuns = new[]
            {
                new QuestionnaireRun { Id = 1, QuestionnaireId = 1, CreatedAt = DateTime.UtcNow.AddDays(-15), OpenDateTime = DateTime.UtcNow.AddDays(-14), CloseDateTime = DateTime.UtcNow.AddDays(-10), EmployeeId = 3, QuestionnaireRunStatus = QuestionnaireRunStatus.Done },
                new QuestionnaireRun { Id = 2, QuestionnaireId = 2, CreatedAt = DateTime.UtcNow.AddDays(-10), OpenDateTime = DateTime.UtcNow.AddDays(-9), CloseDateTime = DateTime.UtcNow.AddDays(-5), EmployeeId = 4, QuestionnaireRunStatus = QuestionnaireRunStatus.Done }
            };

            InsertOrUpdateEntities(context, context.QuestionnaireRuns, questionnaireRuns, qr => qr.Id);

            // Questions
            var questions = new[]
            {
                new Question { Id = 1, QuestionnaireId = 1, QuestionText = "Rate your stress level this week (1-5).", SortOrder = 1 },
                new Question { Id = 2, QuestionnaireId = 1, QuestionText = "Do you feel supported by your team this week?", SortOrder = 2 },
                new Question { Id = 3, QuestionnaireId = 2, QuestionText = "What can your manager do better?", SortOrder = 1 }
            };

            InsertOrUpdateEntities(context, context.Questions, questions, q => q.Id);

            // Answers
            var answers = new[]
            {
                new Answer { Id = 1, QuestionId = 1, QuestionnaireRunId = 1, AnswerText = "4" },
                new Answer { Id = 2, QuestionId = 2, QuestionnaireRunId = 1, AnswerText = "Yes, my team is great." },
                new Answer { Id = 3, QuestionId = 3, QuestionnaireRunId = 2, AnswerText = "Provide clearer goals for the month." }
            };

            InsertOrUpdateEntities(context, context.Answers, answers, a => a.Id);

            // Attendances
            var attendances = Enumerable.Range(1, 20).Select(i => new Attendance
            {
                Id = i,
                EmployeeId = i % 2 == 0 ? 3 : 4,
                DurationStart = DateTime.UtcNow.AddDays(-i - 15),
                DurationEnd = DateTime.UtcNow.AddDays(-i - 15).AddHours(8)
            }).ToArray();

            InsertOrUpdateEntities(context, context.Attendances, attendances, a => a.Id);

            // Commits
            var commits = Enumerable.Range(1, 20).Select(i => new Commit
            {
                Id = i,
                EmployeeId = i % 2 == 0 ? 3 : 4,
                CommitDateTime = DateTime.UtcNow.AddDays(-i),
                CommitSize = i * 10,
                CommitType = i % 3 == 0 ? "Refactor" : i % 2 == 0 ? "Feature" : "Bugfix"
            }).ToArray();

            InsertOrUpdateEntities(context, context.Commits, commits, c => c.Id);
        }

        private static void InsertOrUpdateEntities<T>(
            MindwatchDbContext context,
            DbSet<T> dbSet,
            IEnumerable<T> entities,
            Func<T, object> keySelector) where T : class
        {
            string tableName = dbSet.EntityType.GetTableName();

            // Open manual connection, because Identity Insert is only for current connection
            context.Database.OpenConnection();
            try
            {
                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {tableName} ON");

                foreach (var entity in entities)
                {
                    var key = keySelector(entity);
                    var existingEntity = dbSet.Find(key);

                    if (existingEntity == null)
                    {
                        // Insert if not found
                        dbSet.Add(entity);
                    }
                    else
                    {
                        // Update existing entity
                        context.Entry(existingEntity).CurrentValues.SetValues(entity);
                    }
                }

                context.SaveChanges();

                context.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT {tableName} OFF");
            }
            finally
            {
                context.Database.CloseConnection();
            }
        }
    }
}
