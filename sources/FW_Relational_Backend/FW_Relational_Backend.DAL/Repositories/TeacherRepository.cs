using FW_Relational_Backend.Abstraction.DAL.Base;
using FW_Relational_Backend.DAL;
using FW_Relational_Backend.DTL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW_Relational_Backend.Abstraction.DAL.Repositories
{
    public class TeacherRepository : EFRepository<Teacher, int>, ITeacherRepository
    {
        public TeacherRepository(DbContext context)
            : base(context)
        {
        }
    }
}
