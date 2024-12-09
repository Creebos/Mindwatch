using KR.Hanyang.Mindwatch.Api.Helpers;
using KR.Hanyang.Mindwatch.Application.Contracts;
using KR.Hanyang.Mindwatch.Domain.Entities;
using KR.Hanyang.Mindwatch.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KR.Hanyang.Mindwatch.Api.Controllers
{
    [ApiController]
    [Route("api/employees")]
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
    }
}
