using KR.Hanyang.Mindwatch.Domain.Entities;

namespace KR.Hanyang.Mindwatch.Application.Contracts
{
    public interface IMindwatchRepository : IGenericRepository
    {
        public Task<IReadOnlyCollection<Employee>> GetAllEmployees();
    }
}
