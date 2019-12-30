using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Models
{
    public class AppDb: DbContext
    {
        public AppDb(DbContextOptions<AppDb> options): base(options)
        {
        }
        public DbSet<EmployeeTem> EmployeeManip { get; set; }
    }
}
