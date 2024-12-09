using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Hanyang.Mindwatch.Domain.Entities
{
    public class Questionnaire
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public required string Notes { get; set; }
        public ICollection<Question>? Questions { get; set; }
        public ICollection<QuestionnaireRun>? QuestionnaireRuns { get; set; }
    }
}
