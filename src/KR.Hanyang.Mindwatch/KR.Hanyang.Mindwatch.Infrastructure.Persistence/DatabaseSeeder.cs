using KR.Hanyang.Mindwatch.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace KR.Hanyang.Mindwatch.Infrastructure.Persistence
{
    public static class DatabaseSeeder
    {
        public static void Seed(MindwatchDbContext context)
        {
            // Employee Table 
            if (!context.Employees.Any())
            {
                context.Employees.AddRange(
                    new Employee { Name = "Perreira", FirstName = "Leandro", ShortName = "LPer", PhoneNumber = "079 hett sie gseit", Email = "LPer@mindwatch.com" },
                    new Employee { Name = "Meyer", FirstName = "Yves", ShortName = "YMey", PhoneNumber = "079 hett sie gseit", Email = "YMey@mindwatch.com" },
                    new Employee { Name = "Brody", FirstName = "Brody", ShortName = "Brod", PhoneNumber = "079 hett sie gseit", Email = "Brod@mindwatch.com" }
                );
            }

            context.SaveChanges();
        }
    }
}
