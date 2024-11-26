using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Hanyang.Mindwatch.Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string FirstName { get; set; }
        public string ShortName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Questionnaire> CreatedQuestionnaires { get; set; }
        public ICollection<QuestionnaireRun> InitiatedQuestionnaireRuns { get; set; }
        public ICollection<Attendance> Attendances { get; set; }
    }
}
