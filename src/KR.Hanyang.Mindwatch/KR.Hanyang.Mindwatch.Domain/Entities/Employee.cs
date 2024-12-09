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
        public required string GithubId { get; set; }
    }
}
