using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;

namespace EntityFramework.LabExercise2.Repositories
{
    internal class AnnualSalaryGenericRepository
    {
        public RecruitmentContext Context { get; set; }

        public AnnualSalaryGenericRepository(RecruitmentContext context)
        {
            this.Context = context;
        }

        public List<AnnualSalary> GetAnnualSalary(string employeeCode)
        {
            var annualSalary = this.Context.AnnualSalaries.Where(p => p.CEmployeeCode == employeeCode).ToList();
            if (annualSalary == null)
            {
                return null;
            }
            
            return annualSalary;
        }
    }
}
