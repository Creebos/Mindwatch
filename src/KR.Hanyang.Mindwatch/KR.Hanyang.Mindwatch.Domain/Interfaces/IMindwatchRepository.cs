using KR.Hanyang.Mindwatch.Domain.Entities;

namespace KR.Hanyang.Mindwatch.Domain.Interfaces
{
    public interface IMindwatchRepository : IGenericRepository
    {
        Task<Employee?> GetEmployeeWithDetailsByIdAsync(int id);
        Task<Team?> GetTeamWithDetailsByIdAsync(int id);
    }
}
