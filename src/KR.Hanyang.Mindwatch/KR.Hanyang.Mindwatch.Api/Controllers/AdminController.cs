using KR.Hanyang.Mindwatch.Domain.MlService;
using KR.Hanyang.Mindwatch.Infrastructure.Persistence;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace KR.Hanyang.Mindwatch.Api.Controllers
{
    [Route("api/admin")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly MindwatchDbContext _dbContext;
        private readonly IMlService _mlService;

        public AdminController(MindwatchDbContext dbContext, IMlService mlService)
        {
            _dbContext = dbContext;
            _mlService = mlService;
        }

        [HttpPost("apply-migrations")]
        public IActionResult ApplyMigrations()
        {
            try
            {
                // Fetch migrations applied before calling Migrate()
                var previouslyAppliedMigrations = _dbContext.Database.GetAppliedMigrations().ToList();

                // Apply migrations
                _dbContext.Database.Migrate();

                // Fetch migrations applied after calling Migrate()
                var appliedMigrations = _dbContext.Database.GetAppliedMigrations().Except(previouslyAppliedMigrations);

                string message = "There are no pending migrations.";
                if (appliedMigrations.Any())
                {
                    message = "Migrations applied successfully.";
                }

                return Ok(new
                {
                    Message = message,
                    AppliedMigrations = appliedMigrations
                });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred while applying migrations: {ex.Message}");
            }
        }

        [HttpPost("predict")]
        public async Task<IActionResult> Predict([FromBody] MlServiceInput input)
        {
            if (input == null || string.IsNullOrWhiteSpace(input.Text))
            {
                return BadRequest("Input text cannot be null or empty.");
            }

            try
            {
                var result = await _mlService.PredictAsync(input);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }
    }
}
