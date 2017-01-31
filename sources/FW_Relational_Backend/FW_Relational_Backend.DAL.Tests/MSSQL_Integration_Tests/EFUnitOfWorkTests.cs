using FW_Relational_Backend.Abstraction.DAL.Base;
using FW_Relational_Backend.Abstraction.DAL.UnitsOfWork;
using FW_Relational_Backend.DAL;
using FW_Relational_Backend.DAL.Contexts;
using FW_Relational_Backend.DAL.UnitsOfWork;
using FW_Relational_Backend.DTL;
using FW_Relational_Backend.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FW_Relational_Backend.DAL.Tests.MSSQL_Integration_Tests
{
    public class EFUnitOfWorkTests
    {
        [Fact]
        public void GetDAO_TransactionFlowIsValid()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<DefaultContext>());
            var cnn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            var context = new DefaultContext(cnn);
            Database.SetInitializer(new CreateDatabaseIfNotExists<DefaultContext>());

            var name = Faker.Name.FullName();
            
            //Saves without commiting
            using (var uow = new EFUnitOfWork(context))
            {
                uow.BeginTransaction(IsolationLevel.ReadCommitted);
                var student = new Student()
                {
                    StudentName = name
                };
                context.Students.Add(student);
                uow.SaveChanges();
            }

            //Asserts that student was not permanently saved
            context = new DefaultContext(cnn);
            using (var uow = new EFUnitOfWork(context))
            {
                var student = context.Students.Where(x => x.StudentName == name).FirstOrDefault();// context.Students.Single(x => x.StudentName == name);
                Assert.Null(student);
            }

            //Saves and commits
            context = new DefaultContext(cnn);
            using (var uow = new EFUnitOfWork(context))
            {
                uow.BeginTransaction(IsolationLevel.ReadCommitted);
                var student = new Student()
                {
                    StudentName = name
                };
                context.Students.Add(student);
                uow.SaveChanges();
                uow.CommitTransaction();
            }

            context = new DefaultContext(cnn);
            using (var uow = new EFUnitOfWork(context))
            {
                //Asserts that student was permanently saved
                var student = context.Students.Single(x => x.StudentName == name);
                Assert.NotNull(student);
                Assert.NotEqual(0, student.Id);

                //Updates student
                var newName = new string(name.Reverse().ToArray());
                student.StudentName = newName;
                uow.BeginTransaction(IsolationLevel.ReadUncommitted);
                context.Entry(student).State = EntityState.Modified;
                uow.SaveChanges();
                uow.RollbackTransaction();
            }

            //Assertas that original value was restored after rollback
            context = new DefaultContext(cnn);
            using (var uow = new EFUnitOfWork(context))
            {
                var student = context.Students.Single(x => x.StudentName == name);
                Assert.NotNull(student);
            }
        }
    }
}
