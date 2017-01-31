using FW_Relational_Backend.Abstraction.DAL.UnitsOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FW_Relational_Backend.Abstraction.DAL.Repositories;
using System.Data.Entity;
using FW_Relational_Backend.DAL.Contexts;

namespace FW_Relational_Backend.DAL.UnitsOfWork
{
    public class DefaultUnitOfWork : EFUnitOfWork, IDefaultUnitOfWork
    {
        private ICourseRepository courseRepository;
        private IStudentRepository studentRepository;
        private ITeacherRepository teacherRepository;

        public DefaultUnitOfWork(DefaultContext context) : base(context)
        {
        }

        public ICourseRepository CourseRepository
        {
            get
            {
                if (courseRepository == null)
                    courseRepository = new CourseRepository(base.context);
                return courseRepository;
            }
        }

        public IStudentRepository StudentRepository
        {
            get
            {
                if (studentRepository == null)
                    studentRepository = new StudentRepository(base.context);
                return studentRepository;
            }
        }

        public ITeacherRepository TeacherRepository
        {
            get
            {
                if (teacherRepository == null)
                    teacherRepository = new TeacherRepository(base.context);
                return teacherRepository;
            }
        }
    }
}
