using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Models
{
    public interface IEmployee
    {
        public void Add(EmployeeTem employee);
        public void Delete(int id);
        public void Update(EmployeeTem employee);
        public List<EmployeeTem> GetAll();
        public EmployeeTem Get(int id);
    }
}
