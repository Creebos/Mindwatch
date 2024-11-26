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
        public string Description { get; set; }
        public int CreatedByEmployeeId { get; set; }
        public Employee CreatedByEmployee { get; set; }
        public ICollection<Question> Questions { get; set; }
        public ICollection<QuestionnaireRun> QuestionnaireRuns { get; set; }
    }
}
