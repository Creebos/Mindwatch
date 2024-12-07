using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Hanyang.Mindwatch.Domain.Entities
{
    public class QuestionnaireRun
    {
        public int Id { get; set; }
        public int QuestionnaireId { get; set; }
        public Questionnaire? Questionnaire { get; set; }
        public QuestionnaireRunStatus QuestionnaireRunStatus { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime OpenDateTime { get; set; }
        public DateTime CloseDateTime { get; set; }
        public ICollection<Answer>? Answers { get; set; }
    }
}
