using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Employee.Models
{
    public class SqlDataManip : IEmployee
    { 
        
        private readonly AppDb appDb;

        public SqlDataManip(AppDb appDb)
        {
            this.appDb = appDb;
        }
        public void Add(EmployeeTem employee)
        {
            appDb.EmployeeManip.Add(employee);
            appDb.SaveChanges();
        }

        public void Delete(int id)
        {

            EmployeeTem emp = appDb.EmployeeManip.Find(id);
            if (emp != null)
            {
                appDb.EmployeeManip.Remove(emp);
                appDb.SaveChanges();
            }
        }

        public EmployeeTem Get(int id)
        {
            return appDb.EmployeeManip.Find(id);
        }

        public List<EmployeeTem> GetAll()
        {
            return appDb.EmployeeManip.ToList<EmployeeTem>();
        }

        public void Update(EmployeeTem employee)
        {
            var emp = appDb.EmployeeManip.Attach(employee);
            emp.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            appDb.SaveChanges();
        }
    }
}
