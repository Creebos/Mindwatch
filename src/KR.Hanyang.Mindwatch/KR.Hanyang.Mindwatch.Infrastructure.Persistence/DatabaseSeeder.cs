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
                new Employee { Id = 1, Name = "Perreira", FirstName = "Leandro", ShortName = "LPer", PhoneNumber = "079 hett sie gseit", Email = "LPer@mindwatch.com" },
                new Employee { Id = 2, Name = "Meyer", FirstName = "Yves", ShortName = "YMey", PhoneNumber = "079 hett sie gseit", Email = "YMey@mindwatch.com" },
                new Employee { Id = 3, Name = "Brody", FirstName = "Brody", ShortName = "Brod", PhoneNumber = "079 hett sie gseit", Email = "Brod@mindwatch.com" }
            };

            InsertOrUpdateEntities(context, context.Employees, employees, e => e.Id);

            // Questionnaires
            var questionnaires = new[]
            {
                new Questionnaire { Id = 1, Description = "Employee Satisfaction Survey", CreatedByEmployeeId = 1 },
                new Questionnaire { Id = 2, Description = "Annual Tech Trends Survey", CreatedByEmployeeId = 2 }
            };

            InsertOrUpdateEntities(context, context.Questionnaires, questionnaires, q => q.Id);

            // QuestionnaireRuns 
            var questionnaireRuns = new[]
            {
                new QuestionnaireRun
                {
                    Id = 1,
                    QuestionnaireId = 1,
                    CreatedAt = DateTime.UtcNow.AddDays(-10),
                    OpenDateTime = DateTime.UtcNow.AddDays(-9),
                    CloseDateTime = DateTime.UtcNow.AddDays(-2),
                    InitiatedByEmployeeId = 1
                },
                new QuestionnaireRun
                {
                    Id = 2,
                    QuestionnaireId = 2,
                    CreatedAt = DateTime.UtcNow.AddDays(-7),
                    OpenDateTime = DateTime.UtcNow.AddDays(-6),
                    CloseDateTime = DateTime.UtcNow.AddDays(-1),
                    InitiatedByEmployeeId = 2
                }
            };

            InsertOrUpdateEntities(context, context.QuestionnaireRuns, questionnaireRuns, qr => qr.Id);

            // Questions
            var questions = new[]
            {
                new Question { Id = 1, QuestionnaireId = 1, QuestionText = "How satisfied are you with your job?", SortOrder = 1 },
                new Question { Id = 2, QuestionnaireId = 1, QuestionText = "What motivates you the most?", SortOrder = 2 },
                new Question { Id = 3, QuestionnaireId = 1, QuestionText = "How would you rate the company culture?", SortOrder = 3 },
                new Question { Id = 4, QuestionnaireId = 2, QuestionText = "Which technology trends excite you?", SortOrder = 1 },
                new Question { Id = 5, QuestionnaireId = 2, QuestionText = "Do you prefer remote or on-site work?", SortOrder = 2 },
                new Question { Id = 6, QuestionnaireId = 2, QuestionText = "How do you stay updated with industry trends?", SortOrder = 3 }
            };

            InsertOrUpdateEntities(context, context.Questions, questions, q => q.Id);

            // Answers

            var answers = new[]
            {
                // Answers for QuestionnaireRun 1
                new Answer
                {
                    Id = 1,
                    QuestionId = 1,
                    QuestionnaireRunId = 1,
                    AnsweredByEmployeeId = 3,
                    AnswerText = "I’m very satisfied with my job because I feel supported and valued by my team."
                },
                new Answer
                {
                    Id = 2,
                    QuestionId = 2,
                    QuestionnaireRunId = 1,
                    AnsweredByEmployeeId = 3,
                    AnswerText = "I’m motivated by learning new things and tackling challenging projects with my colleagues."
                },
                new Answer
                {
                    Id = 3,
                    QuestionId = 3,
                    QuestionnaireRunId = 1,
                    AnsweredByEmployeeId = 3,
                    AnswerText = "The company culture is great, with a strong focus on collaboration and innovation."
                },

                // Answers for QuestionnaireRun 2
                new Answer
                {
                    Id = 4,
                    QuestionId = 4,
                    QuestionnaireRunId = 2,
                    AnsweredByEmployeeId = 3,
                    AnswerText = "AI and Machine Learning are the most exciting trends I follow closely."
                },
                new Answer
                {
                    Id = 5,
                    QuestionId = 5,
                    QuestionnaireRunId = 2,
                    AnsweredByEmployeeId = 3,
                    AnswerText = "I prefer remote work because it gives me more flexibility in managing my day."
                },
                new Answer
                {
                    Id = 6,
                    QuestionId = 6,
                    QuestionnaireRunId = 2,
                    AnsweredByEmployeeId = 3,
                    AnswerText = "I stay updated by reading articles and participating in webinars about new technologies."
                }
            };

            InsertOrUpdateEntities(context, context.Answers, answers, a => a.Id);

            var attendances = new[]
            {
                // Leandro Perreira (EmployeeId: 1)
                new Attendance { Id = 1, EmployeeId = 1, DurationStart = new DateTime(2024, 11, 20, 9, 0, 23), DurationEnd = new DateTime(2024, 11, 20, 11, 59, 47) },
                new Attendance { Id = 2, EmployeeId = 1, DurationStart = new DateTime(2024, 11, 20, 13, 0, 12), DurationEnd = new DateTime(2024, 11, 20, 16, 58, 41) },
                new Attendance { Id = 3, EmployeeId = 1, DurationStart = new DateTime(2024, 11, 21, 9, 2, 34), DurationEnd = new DateTime(2024, 11, 21, 11, 56, 18) },
                new Attendance { Id = 4, EmployeeId = 1, DurationStart = new DateTime(2024, 11, 21, 13, 4, 5), DurationEnd = new DateTime(2024, 11, 21, 17, 0, 9) },
                new Attendance { Id = 5, EmployeeId = 1, DurationStart = new DateTime(2024, 11, 22, 9, 1, 43), DurationEnd = new DateTime(2024, 11, 22, 12, 3, 20) },
                new Attendance { Id = 6, EmployeeId = 1, DurationStart = new DateTime(2024, 11, 22, 13, 5, 10), DurationEnd = new DateTime(2024, 11, 22, 16, 59, 50) },

                // Yves Meyer (EmployeeId: 2)
                new Attendance { Id = 7, EmployeeId = 2, DurationStart = new DateTime(2024, 11, 20, 9, 3, 15), DurationEnd = new DateTime(2024, 11, 20, 12, 1, 28) },
                new Attendance { Id = 8, EmployeeId = 2, DurationStart = new DateTime(2024, 11, 20, 13, 1, 50), DurationEnd = new DateTime(2024, 11, 20, 16, 57, 35) },
                new Attendance { Id = 9, EmployeeId = 2, DurationStart = new DateTime(2024, 11, 21, 8, 59, 48), DurationEnd = new DateTime(2024, 11, 21, 12, 4, 9) },
                new Attendance { Id = 10, EmployeeId = 2, DurationStart = new DateTime(2024, 11, 21, 13, 3, 5), DurationEnd = new DateTime(2024, 11, 21, 16, 59, 55) },
                new Attendance { Id = 11, EmployeeId = 2, DurationStart = new DateTime(2024, 11, 22, 9, 0, 37), DurationEnd = new DateTime(2024, 11, 22, 11, 58, 22) },
                new Attendance { Id = 12, EmployeeId = 2, DurationStart = new DateTime(2024, 11, 22, 13, 2, 13), DurationEnd = new DateTime(2024, 11, 22, 16, 58, 17) },

                // Brody (EmployeeId: 3)
                new Attendance { Id = 13, EmployeeId = 3, DurationStart = new DateTime(2024, 11, 20, 9, 1, 5), DurationEnd = new DateTime(2024, 11, 20, 12, 0, 45) },
                new Attendance { Id = 14, EmployeeId = 3, DurationStart = new DateTime(2024, 11, 20, 13, 0, 30), DurationEnd = new DateTime(2024, 11, 20, 16, 59, 18) },
                new Attendance { Id = 15, EmployeeId = 3, DurationStart = new DateTime(2024, 11, 21, 9, 3, 12), DurationEnd = new DateTime(2024, 11, 21, 11, 55, 39) },
                new Attendance { Id = 16, EmployeeId = 3, DurationStart = new DateTime(2024, 11, 21, 13, 2, 50), DurationEnd = new DateTime(2024, 11, 21, 16, 57, 44) },
                new Attendance { Id = 17, EmployeeId = 3, DurationStart = new DateTime(2024, 11, 22, 9, 0, 10), DurationEnd = new DateTime(2024, 11, 22, 12, 1, 37) },
                new Attendance { Id = 18, EmployeeId = 3, DurationStart = new DateTime(2024, 11, 22, 13, 3, 28), DurationEnd = new DateTime(2024, 11, 22, 16, 59, 59) }
            };

            InsertOrUpdateEntities(context, context.Attendances, attendances, a => a.Id);
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
