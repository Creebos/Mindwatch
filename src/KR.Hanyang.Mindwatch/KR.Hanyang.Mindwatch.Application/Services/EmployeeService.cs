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

        public async Task<OperationResult<IEnumerable<Team>>> GetAllTeams()
        {
            _logger.LogInformation("Fetching all teams.");
            var teams = await _repository.FindAllAsync<Team>();
            return OperationResult<IEnumerable<Team>>.Success(teams);
        }

        public async Task<OperationResult<Employee>> GetEmployeeById(int id)
        {
            _logger.LogInformation("Fetching employee with details by ID: {EmployeeId}", id);
            var employee = await _repository.GetEmployeeWithDetailsByIdAsync(id);
            if (employee == null)
            {
                _logger.LogWarning("Employee not found with ID: {EmployeeId}", id);
                return OperationResult<Employee>.NotFound();
            }
            return OperationResult<Employee>.Success(employee);
        }

        public async Task<OperationResult<IEnumerable<Team>>> GetSupervisedTeamsByEmployeeId(int id)
        {
            _logger.LogInformation("Fetching supervised teams for employee ID: {EmployeeId}", id);
            var teams = await _repository.FindByPredicateAsync<Team>(t => t.SupervisorEmployeeId == id);
            return OperationResult<IEnumerable<Team>>.Success(teams);
        }

        public async Task<OperationResult<Team>> GetTeamById(int id)
        {
            _logger.LogInformation("Fetching team with details by ID: {TeamId}", id);
            var team = await _repository.GetTeamWithDetailsByIdAsync(id);
            if (team == null)
            {
                _logger.LogWarning("Team not found with ID: {TeamId}", id);
                return OperationResult<Team>.NotFound();
            }
            return OperationResult<Team>.Success(team);
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
            if (employee.Role == 0) validationErrors.Add("Role is required.");

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
                existingEmployee.Role = employee.Role;
                existingEmployee.TeamId = employee.TeamId;

                await _repository.UpdateAsync(existingEmployee);
                _logger.LogInformation("Updated existing employee: {EmployeeId}", employee.Id);

                return OperationResult<Employee>.Success(existingEmployee);
            }
        }

        public async Task<OperationResult<Team>> UpdateOrInsertTeam(Team team)
        {
            _logger.LogInformation("Updating or inserting team: {TeamId}", team.Id);

            var validationErrors = new List<string>();

            if (string.IsNullOrEmpty(team.Name)) validationErrors.Add("Team Name is required.");
            if (team.SupervisorEmployeeId == 0) validationErrors.Add("Supervisor Employee ID is required.");

            if (validationErrors.Count > 0)
            {
                _logger.LogWarning("Validation failed for team: {TeamId}", team.Id);
                return OperationResult<Team>.Invalid(validationErrors);
            }

            if (team.Id == 0)
            {
                await _repository.InsertAsync(team);
                _logger.LogInformation("Inserted new team: {TeamId}", team.Id);

                return OperationResult<Team>.Success(team);
            }
            else
            {
                // Fetch the existing team from the database
                var existingTeam = await _repository.FindByIdAsync<Team>(team.Id);
                if (existingTeam == null)
                {
                    _logger.LogWarning("Team not found with ID: {TeamId}", team.Id);
                    return OperationResult<Team>.NotFound();
                }

                // Update only specific fields; ignore collections
                existingTeam.Name = team.Name;
                existingTeam.SupervisorEmployeeId = team.SupervisorEmployeeId;

                await _repository.UpdateAsync(existingTeam);
                _logger.LogInformation("Updated existing team: {TeamId}", team.Id);

                return OperationResult<Team>.Success(existingTeam);
            }
        }
    }
}