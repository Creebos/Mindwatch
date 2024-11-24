using KR.Hanyang.Mindwatch.Application.Contracts;
using KR.Hanyang.Mindwatch.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KR.Hanyang.Mindwatch.Api.Controllers
{
    [ApiController]
    [Route("employees")]
    public class EmployeeController : ControllerBase
    {
        private readonly IMindwatchRepository _repository;
        private readonly ILogger<EmployeeController> _logger;

        public EmployeeController(ILogger<EmployeeController> logger, IMindwatchRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // Get All Employees
        [HttpGet]
        public async Task<IActionResult> GetAllEmployees()
        {
            var employees = await _repository.FindAllAsync<Employee>();
            return Ok(employees);
        }

        // Get Employee by ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _repository.FindByIdAsync<Employee>(id);
            if (employee == null)
                return NotFound();
            return Ok(employee);
        }

        // Insert or Update Employee
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateEmployee([FromBody] Employee employee)
        {
            if (employee.Id == 0)
            {
                await _repository.InsertAsync(employee);
            }
            else
            {
                await _repository.UpdateAsync(employee);
            }
            return Ok(employee);
        }

        // Delete Employee by ID
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _repository.FindByIdAsync<Employee>(id);
            if (employee == null)
                return NotFound();

            await _repository.DeleteAsync(employee);
            return NoContent();
        }

        // Get All Attendances
        [HttpGet("{id}/attendances")]
        public async Task<IActionResult> GetAllAttendances(int id)
        {
            var attendances = await _repository.FindByPredicateAsync<Attendance>(q => q.EmployeeId == id);
            return Ok(attendances);
        }

        // Update or Insert Attendance for an Employee
        [HttpPost("{id}/attendances")]
        public async Task<IActionResult> InsertOrUpdateAttendance(int id, [FromBody] Attendance attendance)
        {
            attendance.EmployeeId = id;

            if (attendance.Id == 0)
            {
                await _repository.InsertAsync(attendance);
            }
            else
            {
                await _repository.UpdateAsync(attendance);
            }
            return Ok(attendance);
        }

        // Delete Attendance by ID
        [HttpDelete("attendances/{attendanceId}")]
        public async Task<IActionResult> DeleteAttendance(int attendanceId)
        {
            var attendance = await _repository.FindByIdAsync<Attendance>(attendanceId);
            if (attendance == null)
                return NotFound();

            await _repository.DeleteAsync(attendance);
            return NoContent();
        }
    }
}
