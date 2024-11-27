using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Hanyang.Mindwatch.Domain.Entities
{
    public class Team
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public int SupervisorEmployeeId { get; set; }
        public Employee? SupervisorEmployee { get; set; }
        public ICollection<Employee>? Employees { get; set; }
    }
}
