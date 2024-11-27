using KR.Hanyang.Mindwatch.Api.Helpers;
using KR.Hanyang.Mindwatch.Application.Contracts;
using KR.Hanyang.Mindwatch.Domain.Entities;
using KR.Hanyang.Mindwatch.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KR.Hanyang.Mindwatch.Api.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger, IEmployeeService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            _logger.LogInformation("Fetching all employees.");

            var result = await _service.GetAllEmployees();

            return this.ToActionResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            _logger.LogInformation("Fetching employee by ID: {EmployeeId}", id);

            var result = await _service.GetEmployeeById(id);

            return this.ToActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateEmployee([FromBody] Employee employee)
        {
            _logger.LogInformation("Inserting or updating employee.");

            var result = await _service.UpdateOrInsertEmployee(employee);

            return this.ToActionResult(result);
        }

        [HttpGet("{id}/supervised-teams")]
        public async Task<IActionResult> GetSupervisedTeamsByEmployeeId(int id)
        {
            _logger.LogInformation("Fetching supervised teams for employee ID: {EmployeeId}", id);

            var result = await _service.GetSupervisedTeamsByEmployeeId(id);

            return this.ToActionResult(result);
        }

        [HttpGet("/teams")]
        public async Task<IActionResult> GetAllTeams()
        {
            _logger.LogInformation("Fetching all teams.");

            var result = await _service.GetAllTeams();

            return this.ToActionResult(result);
        }

        [HttpGet("/teams/{id}")]
        public async Task<IActionResult> GetTeamById(int id)
        {
            _logger.LogInformation("Fetching team by ID: {TeamId}", id);

            var result = await _service.GetTeamById(id);

            return this.ToActionResult(result);
        }

        [HttpPost("/teams")]
        public async Task<IActionResult> InsertOrUpdateTeam([FromBody] Team team)
        {
            _logger.LogInformation("Inserting or updating team.");

            var result = await _service.UpdateOrInsertTeam(team);

            return this.ToActionResult(result);
        }
    }
}
