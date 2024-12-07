﻿using KR.Hanyang.Mindwatch.Domain.Entities;
using KR.Hanyang.Mindwatch.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace KR.Hanyang.Mindwatch.Infrastructure.Persistence.Repositories
{
    internal class MindwatchRepository : GenericRepository, IMindwatchRepository
    {
        private readonly MindwatchDbContext _context;

        public MindwatchRepository(MindwatchDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Employee?> GetEmployeeWithDetailsByIdAsync(int id)
        {
            return await _context.Set<Employee>()
                .Include(e => e.Team)
                .Include(e => e.Attendances)
                .Include(e => e.QuestionnaireRuns)
                .Include(e => e.Commits)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<QuestionnaireRun?> GetQuestionnaireRunWithDetailsById(int id)
        {
            return await _context.Set<QuestionnaireRun>()
                .Include(e => e.Questionnaire)
                .ThenInclude(r => r.Questions)
                .Include(e => e.Answers)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Questionnaire?> GetQuestionnaireWithDetailsByIdAsync(int id)
        {
            return await _context.Set<Questionnaire>()
                .Include(e => e.Questions)
                .Include(r => r.QuestionnaireRuns)
                .FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<Team?> GetTeamWithDetailsByIdAsync(int id)
        {
            return await _context.Set<Team>()
                .Include(t => t.SupervisorEmployee)
                .Include(t => t.Employees)
                .FirstOrDefaultAsync(t => t.Id == id);
        }
    }
}
