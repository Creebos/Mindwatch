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
        public required string Name { get; set; }
        public required string FirstName { get; set; }
        public required string ShortName { get; set; }
        public required string Email { get; set; }
        public required string PhoneNumber { get; set; }
        public EmployeeRole Role { get; set; }
        public int? TeamId { get; set; }
        public Team? Team { get; set; }
        public ICollection<QuestionnaireRun>? QuestionnaireRuns { get; set; }
        public ICollection<Team>? SupervisedTeams { get; set; }
        public ICollection<Attendance>? Attendances { get; set; }
        public ICollection<Commit>? Commits { get; set; }
    }
}
