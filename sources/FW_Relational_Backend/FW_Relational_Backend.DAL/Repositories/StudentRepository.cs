using FW_Relational_Backend.Abstraction.DAL.Base;
using FW_Relational_Backend.DAL;
using FW_Relational_Backend.DTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace FW_Relational_Backend.Abstraction.DAL.Repositories
{
    public class StudentRepository : EFRepository<Student, int>, IStudentRepository
    {
        public StudentRepository(DbContext context) 
            : base(context)
        {
        }
    }
}
