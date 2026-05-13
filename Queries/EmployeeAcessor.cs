using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CS_DB_Exercise.Queries
{
    public class EmployeeAcessor
    {
        public DepartementAccessor(AppDbContext context)
        {
            _context = context;
        }

        public EmployeeEntity? FindByDeptId(int deptId)
        {
            var employee = _context.employee.Find(deptId);
        }
    }
}