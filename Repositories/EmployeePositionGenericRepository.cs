using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;

namespace EntityFramework.LabExercise2.Repositories
{
    public class EmployeePositionGenericRepository:GenericRepository<Position>, IRepository<Position>
    {
        public EmployeePositionGenericRepository(RecruitmentContext context):base(context)
        {
        }

    }
}
