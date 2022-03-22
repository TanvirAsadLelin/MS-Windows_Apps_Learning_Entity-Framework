using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.Entity;

namespace CodeFirstApproach_EntityFramework.Model
{
    internal class EmployeeDB_Context : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
    }
}
