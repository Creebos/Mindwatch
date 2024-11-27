
using KR.Hanyang.Mindwatch.Application.Results;
using KR.Hanyang.Mindwatch.Domain.Entities;

namespace KR.Hanyang.Mindwatch.Application.Contracts
{
    public interface IQuestionnaireService
    {
        Task<OperationResult<IEnumerable<Questionnaire>>> GetAllQuestionnaires();
        Task<OperationResult<Questionnaire>> GetQuestionnaireById(int id);
        Task<OperationResult<QuestionnaireRun>> GetQuestionaireRunById(int id);
        Task<OperationResult<Answer>> UpdateOrInsertAnswer(Answer answer);
        Task<OperationResult<Questionnaire>> UpdateOrInsertQuestionnaire(Questionnaire questionnaire);
        Task<OperationResult<Question>> UpdateOrInsertQuestion(Question question);
        Task<OperationResult<QuestionnaireRun>> UpdateOrInsertQuestionnaireRun(QuestionnaireRun questionnaireRun);
    }
}
