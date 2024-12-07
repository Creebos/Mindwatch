using KR.Hanyang.Mindwatch.Domain.Entities;

namespace KR.Hanyang.Mindwatch.Domain.Interfaces
{
    public interface IMindwatchRepository : IGenericRepository
    {
        Task<QuestionnaireRun?> GetQuestionnaireRunWithDetailsById(int id);
        Task<Questionnaire?> GetQuestionnaireWithDetailsByIdAsync(int id);
    }
}
