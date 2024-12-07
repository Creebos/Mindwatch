using KR.Hanyang.Mindwatch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace KR.Hanyang.Mindwatch.Infrastructure.Persistence
{
    public static class DatabaseSeeder
    {
        public static void Seed(MindwatchDbContext context)
        {
            context.Database.EnsureCreated();

            // Employees
            var employees = new List<Employee>
            {
                new Employee { Id = 1, Name = "Smith", FirstName = "John", ShortName = "JSmith", Email = "john.smith@company.com", PhoneNumber = "1234567890", GithubId = "johnsmith" },
                new Employee { Id = 2, Name = "Doe", FirstName = "Jane", ShortName = "JDoe", Email = "jane.doe@company.com", PhoneNumber = "0987654321", GithubId = "janedoe" }
            };

            InsertOrUpdateEntities(context, context.Employees, employees, e => e.Id);

            // Questionnaires
            var questionnaires = new List<Questionnaire>
            {
                new Questionnaire { Id = 1, Title = "Workplace Wellbeing", Description = "Survey about workplace satisfaction and stress levels", Notes = "Confidential" },
                new Questionnaire { Id = 2, Title = "Tech Team Feedback", Description = "Feedback for improving productivity", Notes = "Internal Use Only" }
            };

            InsertOrUpdateEntities(context, context.Questionnaires, questionnaires, q => q.Id);

            // Questions
            var questions = new List<Question>
            {
                new Question { Id = 1, QuestionnaireId = 1, QuestionText = "How satisfied are you with your job?", SortOrder = 1 },
                new Question { Id = 2, QuestionnaireId = 1, QuestionText = "Do you feel stressed at work?", SortOrder = 2 },
                new Question { Id = 3, QuestionnaireId = 2, QuestionText = "How can we improve team communication?", SortOrder = 1 }
            };

            InsertOrUpdateEntities(context, context.Questions, questions, q => q.Id);

            // Questionnaire Runs
            var questionnaireRuns = new List<QuestionnaireRun>
            {
                new QuestionnaireRun
                {
                    Id = 1,
                    QuestionnaireId = 1,
                    QuestionnaireRunStatus = QuestionnaireRunStatus.Open,
                    CreatedAt = DateTime.UtcNow.AddDays(-7),
                    OpenDateTime = DateTime.UtcNow.AddDays(-5),
                    CloseDateTime = DateTime.UtcNow.AddDays(2)
                },
                new QuestionnaireRun
                {
                    Id = 2,
                    QuestionnaireId = 2,
                    QuestionnaireRunStatus = QuestionnaireRunStatus.Done,
                    CreatedAt = DateTime.UtcNow.AddDays(-14),
                    OpenDateTime = DateTime.UtcNow.AddDays(-12),
                    CloseDateTime = DateTime.UtcNow.AddDays(-10)
                }
            };

            InsertOrUpdateEntities(context, context.QuestionnaireRuns, questionnaireRuns, qr => qr.Id);

            // Answers
            var answers = new List<Answer>
            {
                new Answer { Id = 1, QuestionId = 1, QuestionnaireRunId = 1, AnswerText = "Very satisfied" },
                new Answer { Id = 2, QuestionId = 2, QuestionnaireRunId = 1, AnswerText = "Sometimes" },
                new Answer { Id = 3, QuestionId = 3, QuestionnaireRunId = 2, AnswerText = "More frequent team meetings" }
            };

            InsertOrUpdateEntities(context, context.Answers, answers, a => a.Id);

            // Incidents
            var incidents = new List<Incident>
            {
                new Incident { Id = 1, Title = "System Outage", Description = "The database server went down.", AuthorEmail = "john.smith@company.com" },
                new Incident { Id = 2, Title = "Late Deliverable", Description = "The latest sprint deliverable was delayed.", AuthorEmail = "jane.doe@company.com" }
            };

            InsertOrUpdateEntities(context, context.Incidents, incidents, i => i.Id);
        }

        private static void InsertOrUpdateEntities<T>(
            MindwatchDbContext context,
            DbSet<T> dbSet,
            IEnumerable<T> entities,
            Func<T, object> keySelector) where T : class
        {
            string tableName = dbSet.EntityType.GetTableName();

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
                        dbSet.Add(entity);
                    }
                    else
                    {
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
