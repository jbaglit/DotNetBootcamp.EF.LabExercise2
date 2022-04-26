using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;

namespace EntityFramework.LabExercise2.Repositories
{
    public class MonthlySalaryGenericRepository
    {
        public RecruitmentContext Context { get; set; }

        public MonthlySalaryGenericRepository(RecruitmentContext context)
        {
            this.Context = context;
        }

        public List<MonthlySalary> GetMonthlySalary(string employeeCode)
        {
            var monthlySalary = this.Context.MonthlySalaries.Where(p => p.CEmployeeCode == employeeCode).ToList();
            if (monthlySalary != null)
            {
                return monthlySalary;
            }
            return null;
        }
    }
}
