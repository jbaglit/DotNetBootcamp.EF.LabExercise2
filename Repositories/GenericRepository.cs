using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;

namespace EntityFramework.LabExercise2.Repositories
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> FindAll();
        T FindByEmployeeCode(string employeeCode);
    }

    public class GenericRepository<T> where T : class
    {
        public RecruitmentContext Context { get; set; }

        public GenericRepository(RecruitmentContext context)
        {
            this.Context = context;
        }

        public IEnumerable<T> FindAll()
        {
            IQueryable<T> query = this.Context.Set<T>();
            return query.Select(e => e).ToList();
        }

        public T FindByEmployeeCode(string employeeCode)
        {
            var entity = this.Context.Find<T>(employeeCode);
            if (entity != null)
            {
                return entity;
            }
            throw new Exception($"Employee with Employee Code of ({employeeCode}) doesn't exist.");
        }

    }
}
