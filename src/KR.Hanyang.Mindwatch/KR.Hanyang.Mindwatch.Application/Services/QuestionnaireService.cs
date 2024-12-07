using KR.Hanyang.Mindwatch.Application.Contracts;
using KR.Hanyang.Mindwatch.Application.Results;
using KR.Hanyang.Mindwatch.Domain.Entities;
using KR.Hanyang.Mindwatch.Domain.Interfaces;
using Microsoft.Extensions.Logging;
using System.Security;

namespace KR.Hanyang.Mindwatch.Application.Services
{
    internal class QuestionnaireService : IQuestionnaireService
    {
        private readonly ILogger<QuestionnaireService> _logger;
        private readonly IMindwatchRepository _repository;

        public QuestionnaireService(ILogger<QuestionnaireService> logger, IMindwatchRepository repository)
        {
            _logger = logger;
            _repository = repository;
        }

        public async Task<OperationResult<IEnumerable<Questionnaire>>> GetAllQuestionnaires()
        {
            _logger.LogInformation("Fetching all questionnaires.");

            var questionnaires = await _repository.GetAllQuestionnaires();

            return OperationResult<IEnumerable<Questionnaire>>.Success(questionnaires);
        }

        public async Task<OperationResult<QuestionnaireRun>> GetQuestionaireRunById(int id)
        {
            _logger.LogInformation("Fetching questionnaire run with details by ID: {Id}", id);

            var questionnaireRun = await _repository.GetQuestionnaireRunWithDetailsById(id);
            if (questionnaireRun == null)
            {
                _logger.LogWarning("Questionnaire run not found with ID: {Id}", id);
                return OperationResult<QuestionnaireRun>.NotFound();
            }

            return OperationResult<QuestionnaireRun>.Success(questionnaireRun);
        }

        public async Task<OperationResult<Questionnaire>> GetQuestionnaireById(int id)
        {
            _logger.LogInformation("Fetching questionnaire with details by ID: {Id}", id);

            var questionnaire = await _repository.GetQuestionnaireWithDetailsByIdAsync(id);
            if (questionnaire == null)
            {
                _logger.LogWarning("Questionnaire not found with ID: {Id}", id);
                return OperationResult<Questionnaire>.NotFound();
            }

            return OperationResult<Questionnaire>.Success(questionnaire);
        }

        public async Task<OperationResult<Answer>> UpdateOrInsertAnswer(Answer answer)
        {
            _logger.LogInformation("Updating or inserting answer for Question ID: {QuestionId}, QuestionnaireRun ID: {QuestionnaireRunId}", answer.QuestionId, answer.QuestionnaireRunId);

            var validationErrors = new List<string>();
            if (string.IsNullOrEmpty(answer.AnswerText)) validationErrors.Add("Answer text is required.");
            if (answer.QuestionId <= 0) validationErrors.Add("Valid Question ID is required.");
            if (answer.QuestionnaireRunId <= 0) validationErrors.Add("Valid QuestionnaireRun ID is required.");

            if (validationErrors.Count > 0)
            {
                _logger.LogWarning("Validation failed for answer.");
                return OperationResult<Answer>.Invalid(validationErrors);
            }

            Answer? currentAnswer = (await _repository.FindByPredicateAsync<Answer>(f => f.QuestionnaireRunId == answer.QuestionnaireRunId && f.QuestionId == answer.QuestionId)).FirstOrDefault();

            if (currentAnswer == null)
            {
                await _repository.InsertAsync(answer);
                _logger.LogInformation("Inserted new answer.");

                return OperationResult<Answer>.Success(answer);
            }
            else
            {
                currentAnswer.AnswerText = answer.AnswerText;

                await _repository.UpdateAsync(currentAnswer);
                _logger.LogInformation("Updated existing answer.");

                return OperationResult<Answer>.Success(currentAnswer);
            }
        }

        public async Task<OperationResult<Question>> UpdateOrInsertQuestion(Question question)
        {
            _logger.LogInformation("Updating or inserting question for Questionnaire ID: {QuestionnaireId}", question.QuestionnaireId);

            var validationErrors = new List<string>();
            if (string.IsNullOrEmpty(question.QuestionText)) validationErrors.Add("Question text is required.");
            if (question.QuestionnaireId <= 0) validationErrors.Add("Valid Questionnaire ID is required.");
            if (question.SortOrder < 0) validationErrors.Add("Sort order must be non-negative.");

            if (validationErrors.Count > 0)
            {
                _logger.LogWarning("Validation failed for question.");
                return OperationResult<Question>.Invalid(validationErrors);
            }

            if (question.Id == 0)
            {
                await _repository.InsertAsync(question);
                _logger.LogInformation("Inserted new question.");

                return OperationResult<Question>.Success(question);
            }
            else
            {
                var currentQuestion = await _repository.FindByIdAsync<Question>(question.Id);
                if (currentQuestion == null)
                {
                    _logger.LogWarning("Question not found with ID: {QuestionId}", question.Id);
                    return OperationResult<Question>.NotFound();
                }

                currentQuestion.QuestionText = question.QuestionText;
                currentQuestion.SortOrder = question.SortOrder;

                await _repository.UpdateAsync(currentQuestion);
                _logger.LogInformation("Updated existing question.");

                return OperationResult<Question>.Success(currentQuestion);
            }
        }

        public async Task<OperationResult<Questionnaire>> UpdateOrInsertQuestionnaire(Questionnaire questionnaire)
        {
            _logger.LogInformation("Updating or inserting questionnaire.");

            var validationErrors = new List<string>();
            if (string.IsNullOrEmpty(questionnaire.Title)) validationErrors.Add("Title is required.");
            if (string.IsNullOrEmpty(questionnaire.Description)) validationErrors.Add("Description is required.");
            if (string.IsNullOrEmpty(questionnaire.Notes)) validationErrors.Add("Notes is required.");

            if (validationErrors.Count > 0)
            {
                _logger.LogWarning("Validation failed for questionnaire.");
                return OperationResult<Questionnaire>.Invalid(validationErrors);
            }

            if (questionnaire.Id == 0)
            {
                await _repository.InsertAsync(questionnaire);
                _logger.LogInformation("Inserted new questionnaire.");

                return OperationResult<Questionnaire>.Success(questionnaire);
            }
            else
            {
                var currentQuestionnaire = await _repository.FindByIdAsync<Questionnaire>(questionnaire.Id);
                if (currentQuestionnaire == null)
                {
                    _logger.LogWarning("Questionnaire not found with ID: {QuestionnaireId}", questionnaire.Id);
                    return OperationResult<Questionnaire>.NotFound();
                }

                currentQuestionnaire.Title = questionnaire.Title;
                currentQuestionnaire.Description = questionnaire.Description;
                currentQuestionnaire.Notes = questionnaire.Notes;

                await _repository.UpdateAsync(currentQuestionnaire);
                _logger.LogInformation("Updated existing questionnaire.");

                return OperationResult<Questionnaire>.Success(currentQuestionnaire);
            }
        }

        public async Task<OperationResult<QuestionnaireRun>> UpdateOrInsertQuestionnaireRun(QuestionnaireRun questionnaireRun)
        {
            _logger.LogInformation("Updating or inserting questionnaire run.");

            var validationErrors = new List<string>();
            if (questionnaireRun.QuestionnaireId <= 0) validationErrors.Add("Valid Questionnaire ID is required.");

            if (validationErrors.Count > 0)
            {
                _logger.LogWarning("Validation failed for questionnaire run.");
                return OperationResult<QuestionnaireRun>.Invalid(validationErrors);
            }

            if (questionnaireRun.Id == 0)
            {
                await _repository.InsertAsync(questionnaireRun);
                _logger.LogInformation("Inserted new questionnaire run.");

                return OperationResult<QuestionnaireRun>.Success(questionnaireRun);
            }
            else
            {
                var currentQuestionnaireRun = await _repository.FindByIdAsync<QuestionnaireRun>(questionnaireRun.Id);
                if (currentQuestionnaireRun == null)
                {
                    _logger.LogWarning("QuestionnaireRun not found with ID: {QuestionnaireRunId}", questionnaireRun.Id);
                    return OperationResult<QuestionnaireRun>.NotFound();
                }

                currentQuestionnaireRun.QuestionnaireRunStatus = questionnaireRun.QuestionnaireRunStatus;
                currentQuestionnaireRun.CloseDateTime = questionnaireRun.CloseDateTime;
                currentQuestionnaireRun.OpenDateTime = questionnaireRun.OpenDateTime;

                await _repository.UpdateAsync(currentQuestionnaireRun);
                _logger.LogInformation("Updated existing questionnaire run.");

                return OperationResult<QuestionnaireRun>.Success(currentQuestionnaireRun);
            }
        }
    }
}
