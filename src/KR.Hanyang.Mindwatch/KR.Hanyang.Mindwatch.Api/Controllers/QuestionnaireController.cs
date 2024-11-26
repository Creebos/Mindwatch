using KR.Hanyang.Mindwatch.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using KR.Hanyang.Mindwatch.Domain.Entities;

namespace KR.Hanyang.Mindwatch.Api.Controllers
{
    [ApiController]
    [Route("api/questionnaires")]
    public class QuestionnaireController : ControllerBase
    {
        private readonly IMindwatchRepository _repository;
        private readonly ILogger<QuestionnaireController> _logger;

        public QuestionnaireController(ILogger<QuestionnaireController> logger, IMindwatchRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        // Get All Questionnaires
        [HttpGet]
        public async Task<IActionResult> GetAllQuestionnaires()
        {
            var questionnaires = await _repository.FindAllAsync<Questionnaire>();
            return Ok(questionnaires);
        }

        // Get Questionnaire By ID
        [HttpGet("{id}")]
        public async Task<IActionResult> GetQuestionnaireById(int id)
        {
            var questionnaire = await _repository.FindByIdAsync<Questionnaire>(id);
            if (questionnaire == null)
                return NotFound();
            return Ok(questionnaire);
        }

        // Insert or Update Questionnaire By ID
        [HttpPost]
        public async Task<IActionResult> InsertOrUpdateQuestionnaire([FromBody] Questionnaire questionnaire)
        {
            if (questionnaire.Id == 0)
            {
                await _repository.InsertAsync(questionnaire);
            }
            else
            {
                await _repository.UpdateAsync(questionnaire);
            }
            return Ok(questionnaire);
        }

        // Get All QuestionnaireRuns by Questionnaire ID
        [HttpGet("{questionnaireId}/runs")]
        public async Task<IActionResult> GetQuestionnaireRunsByQuestionnaireId(int questionnaireId)
        {
            var questionnaireRuns = await _repository.FindByPredicateAsync<QuestionnaireRun>(qr => qr.QuestionnaireId == questionnaireId);
            return Ok(questionnaireRuns);
        }

        // Insert or Update QuestionnaireRun for Questionnaire
        [HttpPost("{questionnaireId}/runs")]
        public async Task<IActionResult> InsertOrUpdateQuestionnaireRun(int questionnaireId, [FromBody] QuestionnaireRun run)
        {
            if (run.Id == 0)
            {
                run.QuestionnaireId = questionnaireId;
                await _repository.InsertAsync(run);
            }
            else
            {
                await _repository.UpdateAsync(run);
            }
            return Ok(run);
        }

        // Get All Questions for Questionnaire by Questionnaire ID
        [HttpGet("{questionnaireId}/questions")]
        public async Task<IActionResult> GetQuestionsByQuestionnaireId(int questionnaireId)
        {
            var questions = await _repository.FindByPredicateAsync<Question>(q => q.QuestionnaireId == questionnaireId);
            return Ok(questions);
        }

        // Insert or Update Question for Questionnaire
        [HttpPost("{questionnaireId}/questions")]
        public async Task<IActionResult> InsertOrUpdateQuestion(int questionnaireId, [FromBody] Question question)
        {
            if (question.Id == 0)
            {
                question.QuestionnaireId = questionnaireId;
                await _repository.InsertAsync(question);
            }
            else
            {
                await _repository.UpdateAsync(question);
            }
            return Ok(question);
        }

        // Get All Answers for Question, QuestionnaireRun, and Employee
        [HttpGet("answers")]
        public async Task<IActionResult> GetAnswers([FromQuery] int? questionId, [FromQuery] int? questionnaireRunId, [FromQuery] int? employeeId)
        {
            var answers = await _repository.FindByPredicateAsync<Answer>(a =>
                (!questionId.HasValue || a.QuestionId == questionId) &&
                (!questionnaireRunId.HasValue || a.QuestionnaireRunId == questionnaireRunId) &&
                (!employeeId.HasValue || a.AnsweredByEmployeeId == employeeId));
            return Ok(answers);
        }

        // Insert or Update Answer
        [HttpPost("answers")]
        public async Task<IActionResult> InsertOrUpdateAnswer([FromBody] Answer answer)
        {
            if (answer.Id == 0)
            {
                await _repository.InsertAsync(answer);
            }
            else
            {
                await _repository.UpdateAsync(answer);
            }
            return Ok(answer);
        }

        // Delete Answer
        [HttpDelete("answers/{id}")]
        public async Task<IActionResult> DeleteAnswer(int id)
        {
            var answer = await _repository.FindByIdAsync<Answer>(id);
            if (answer == null)
                return NotFound();
            await _repository.DeleteAsync(answer);
            return NoContent();
        }
    }
}