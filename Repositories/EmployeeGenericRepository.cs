using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;

namespace EntityFramework.LabExercise2.Repositories
{
    public class EmployeeGenericRepository:GenericRepository<Employee>, IRepository<Employee>
    {
        public EmployeeGenericRepository(RecruitmentContext context):base(context)
        {
        }

    }
}
