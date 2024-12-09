using KR.Hanyang.Mindwatch.Application.Contracts;
using KR.Hanyang.Mindwatch.Application.Results;
using KR.Hanyang.Mindwatch.Domain.Entities;
using KR.Hanyang.Mindwatch.Domain.Interfaces;
using Microsoft.Extensions.Logging;

namespace KR.Hanyang.Mindwatch.Application.Services
{
    internal class EmployeeService : IEmployeeService
    {
        private readonly ILogger<EmployeeService> _logger;
        private readonly IMindwatchRepository _repository;

        public EmployeeService(ILogger<EmployeeService> logger, IMindwatchRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<OperationResult<IEnumerable<Employee>>> GetAllEmployees()
        {
            _logger.LogInformation("Fetching all employees.");

            var employees = await _repository.FindAllAsync<Employee>();

            return OperationResult<IEnumerable<Employee>>.Success(employees);
        }

        public async Task<OperationResult<Employee>> GetEmployeeById(int id)
        {
            _logger.LogInformation("Fetching employee with details by ID: {EmployeeId}", id);

            var employee = await _repository.FindByIdAsync<Employee>(id);
            if (employee == null)
            {
                _logger.LogWarning("Employee not found with ID: {EmployeeId}", id);

                return OperationResult<Employee>.NotFound();
            }

            return OperationResult<Employee>.Success(employee);
        }

        public async Task<OperationResult<Employee>> UpdateOrInsertEmployee(Employee employee)
        {
            _logger.LogInformation("Updating or inserting employee: {EmployeeId}", employee.Id);

            var validationErrors = new List<string>();
            if (string.IsNullOrEmpty(employee.Name)) validationErrors.Add("Name is required.");
            if (string.IsNullOrEmpty(employee.FirstName)) validationErrors.Add("First Name is required.");
            if (string.IsNullOrEmpty(employee.ShortName)) validationErrors.Add("Short Name is required.");
            if (string.IsNullOrEmpty(employee.Email)) validationErrors.Add("Email is required.");
            if (string.IsNullOrEmpty(employee.PhoneNumber)) validationErrors.Add("Phone Number is required.");

            if (validationErrors.Count > 0)
            {
                _logger.LogWarning("Validation failed for employee: {EmployeeId}", employee.Id);
                return OperationResult<Employee>.Invalid(validationErrors);
            }

            if (employee.Id == 0)
            {
                await _repository.InsertAsync(employee);
                _logger.LogInformation("Inserted new employee: {EmployeeId}", employee.Id);

                return OperationResult<Employee>.Success(employee);
            }
            else
            {
                // Fetch the existing employee from the database
                var existingEmployee = await _repository.FindByIdAsync<Employee>(employee.Id);
                if (existingEmployee == null)
                {
                    _logger.LogWarning("Employee not found with ID: {EmployeeId}", employee.Id);
                    return OperationResult<Employee>.NotFound();
                }

                // Update only specific fields; ignore collections
                existingEmployee.Name = employee.Name;
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.ShortName = employee.ShortName;
                existingEmployee.Email = employee.Email;
                existingEmployee.PhoneNumber = employee.PhoneNumber;

                await _repository.UpdateAsync(existingEmployee);
                _logger.LogInformation("Updated existing employee: {EmployeeId}", employee.Id);

                return OperationResult<Employee>.Success(existingEmployee);
            }
        }
    }
}