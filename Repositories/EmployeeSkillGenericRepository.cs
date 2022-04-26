using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using EntityFramework.LabExercise2.Data;
using EntityFramework.LabExercise2.Models;

namespace EntityFramework.LabExercise2.Repositories
{
    internal class EmployeeSkillGenericRepository:GenericRepository<EmployeeSkill>, IRepository<EmployeeSkill>
    {
        public EmployeeSkillGenericRepository(RecruitmentContext context):base(context)
        {
        }

        public IEnumerable<dynamic> FindAll(string cemployeeCode)
        {
            var skills = this.Context.EmployeeSkills.Join(Context.Skills,p => p.CSkillCode,i => i.CSkillCode,(p,i) => new
                {CEmployeeCode = p.CEmployeeCode,CSkillCode = i.VSkill}).Where(x => x.CEmployeeCode == cemployeeCode).ToList();
            
            return skills;
        }



    }
}

