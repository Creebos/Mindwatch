namespace KR.Hanyang.Mindwatch.Domain.Entities
{
    public class Question
    {
        public int Id { get; set; }
        public int QuestionnaireId { get; set; }
        public Questionnaire? Questionnaire { get; set; }
        public required string QuestionText { get; set; }
        public int SortOrder { get; set; }
    }
}