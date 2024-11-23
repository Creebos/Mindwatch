using KR.Hanyang.Mindwatch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KR.Hanyang.Mindwatch.Domain.Persistence
{
    public interface IMindwatchRepository
    {
        public Task<IReadOnlyCollection<Employee>> GetAllEmployees();
    }
}
