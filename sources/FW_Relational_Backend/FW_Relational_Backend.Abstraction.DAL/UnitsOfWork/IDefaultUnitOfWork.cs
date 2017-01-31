using FW_Relational_Backend.Abstraction.DAL.Base;
using FW_Relational_Backend.Abstraction.DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW_Relational_Backend.Abstraction.DAL.UnitsOfWork
{
    public interface IDefaultUnitOfWork : IUnitOfWork
    {
        IStudentRepository StudentRepository { get; }
        ICourseRepository CourseRepository { get; }
        ITeacherRepository TeacherRepository { get; }
    }
}
