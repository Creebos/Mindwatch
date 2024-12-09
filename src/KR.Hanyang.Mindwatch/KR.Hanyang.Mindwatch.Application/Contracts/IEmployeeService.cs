
using KR.Hanyang.Mindwatch.Application.Results;
using KR.Hanyang.Mindwatch.Domain.Entities;
using KR.Hanyang.Mindwatch.Domain.Interfaces;
using System.Runtime.CompilerServices;

namespace KR.Hanyang.Mindwatch.Application.Contracts
{
    public interface IEmployeeService
    {
        Task<OperationResult<IEnumerable<Employee>>> GetAllEmployees();
        Task<OperationResult<Employee>> GetEmployeeById(int id);
        Task<OperationResult<Employee>> UpdateOrInsertEmployee(Employee employee);
    }
}
