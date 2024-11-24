using KR.Hanyang.Mindwatch.Application.Contracts;
using KR.Hanyang.Mindwatch.Domain.Entities;
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

        public async Task<IReadOnlyCollection<Employee>> GetAllEmployees()
        {
            return await _context.Employees.ToListAsync();
        }
    }
}
