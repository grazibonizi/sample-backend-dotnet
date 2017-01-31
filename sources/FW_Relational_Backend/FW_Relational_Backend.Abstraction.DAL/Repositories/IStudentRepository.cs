using FW_Relational_Backend.Abstraction.DAL.Base;
using FW_Relational_Backend.DTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW_Relational_Backend.Abstraction.DAL.Repositories
{
    public interface IStudentRepository : IRepository<Student, int>
    {
    }
}
