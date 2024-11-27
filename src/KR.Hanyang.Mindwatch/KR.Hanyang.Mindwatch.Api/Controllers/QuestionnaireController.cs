using KR.Hanyang.Mindwatch.Api.Helpers;
using KR.Hanyang.Mindwatch.Application.Contracts;
using KR.Hanyang.Mindwatch.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace KR.Hanyang.Mindwatch.Api.Controllers
{
    [ApiController]
    [Route("api/questionnaires")]
    public class QuestionnaireController : ControllerBase
    {
        private readonly IQuestionnaireService _service;
        private readonly ILogger<QuestionnaireController> _logger;

        public QuestionnaireController(ILogger<QuestionnaireController> logger, IQuestionnaireService service)
        {
            _logger = logger;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllQuestionnaires()
        {
            _logger.LogInformation("Fetching all questionnaires.");

            var result = await _service.GetAllQuestionnaires();

            return this.ToActionResult(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionnaireById(int id)
        {
            _logger.LogInformation("Fetching questionnaire by ID: {Id}", id);

            var result = await _service.GetQuestionnaireById(id);

            return this.ToActionResult(result);
        }

        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateQuestionnaire([FromBody] Questionnaire questionnaire)
        {
            _logger.LogInformation("Inserting or updating questionnaire.");

            var result = await _service.UpdateOrInsertQuestionnaire(questionnaire);

            return this.ToActionResult(result);
        }

        [HttpGet("questionnaire-runs/{id}")]
        public async Task<IActionResult> GetQuestionnaireRunById(int id)
        {
            _logger.LogInformation("Fetching questionnaire run by ID: {Id}", id);

            var result = await _service.GetQuestionaireRunById(id);

            return this.ToActionResult(result);
        }

        [HttpPost("questionnaire-runs")]
        public async Task<IActionResult> InsertOrUpdateQuestionnaireRun([FromBody] QuestionnaireRun questionnaireRun)
        {
            _logger.LogInformation("Inserting or updating questionnaire run.");

            var result = await _service.UpdateOrInsertQuestionnaireRun(questionnaireRun);

            return this.ToActionResult(result);
        }

        [HttpPost("answers")]
        public async Task<IActionResult> InsertOrUpdateAnswer([FromBody] Answer answer)
        {
            _logger.LogInformation("Inserting or updating answer.");

            var result = await _service.UpdateOrInsertAnswer(answer);

            return this.ToActionResult(result);
        }

        [HttpPost("questions")]
        public async Task<IActionResult> InsertOrUpdateQuestion([FromBody] Question question)
        {
            _logger.LogInformation("Inserting or updating question.");

            var result = await _service.UpdateOrInsertQuestion(question);

            return this.ToActionResult(result);
        }
    }
}
