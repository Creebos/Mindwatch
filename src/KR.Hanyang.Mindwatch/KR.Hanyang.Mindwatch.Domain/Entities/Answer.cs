using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Hanyang.Mindwatch.Domain.Entities
{
    public class Answer
    {
        public int Id { get; set; }
        public int QuestionId { get; set; }
        public Question? Question { get; set; }
        public int QuestionnaireRunId { get; set; }
        public QuestionnaireRun? QuestionnaireRun { get; set; }
        public required string AnswerText { get; set; }
    }
}
