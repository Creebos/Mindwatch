using KR.Hanyang.Mindwatch.Domain.Entities;
using KR.Hanyang.Mindwatch.Domain.Persistence;
using KR.Hanyang.Mindwatch.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Hanyang.Mindwatch.Application.Persistence
{
    internal class MindwatchRepository : IMindwatchRepository
    {
        private MindwatchDbContext _context;

        public MindwatchRepository(MindwatchDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyCollection<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }
    }
}
