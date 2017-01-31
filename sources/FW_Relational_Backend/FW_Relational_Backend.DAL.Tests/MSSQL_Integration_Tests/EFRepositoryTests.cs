using FizzWare.NBuilder;
using FW_Relational_Backend.DAL.Contexts;
using FW_Relational_Backend.DTL;
using FW_Relational_Backend.DTL.Enums;
using FW_Relational_Backend.Services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace FW_Relational_Backend.DAL.Tests.MSSQL_Integration_Tests
{
    public class EFRepositoryTests
    {
        [Fact]
        public void CRUDIsValid()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<DefaultContext>());
            var cnn = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            using (var context = new DefaultContext(cnn))
            {
                var efRepository = new EFRepository<Student, int>(context);

                //Create
                var name = Faker.Name.FullName();
                var student = Builder<Student>.CreateNew()
                    .With(c => c.StudentName = name)
                    .With(c => c.StudentAddress = new StudentAddress()
                    {
                        Address = Faker.Address.StreetAddress(),
                        City = Faker.Address.City(),
                        State = Faker.Address.UsState()
                    })
                    .Build();
                efRepository.Create(student);
                context.SaveChanges();
                Assert.NotEqual(0, student.Id);
                Assert.NotEqual(0, student.StudentAddress.Id);
                int id = student.Id;

                //ReadById
                var item = efRepository.ReadById(id, y => y.StudentAddress);
                Assert.NotNull(item);
                Assert.NotNull(item.StudentAddress);

                //Update
                var newName = new string(name.Reverse().ToArray());
                var updatedStudent = item;
                updatedStudent.StudentName = newName;
                efRepository.Update(updatedStudent);
                context.SaveChanges();
                
                //Read
                var items = efRepository.Read(x => x.StudentName == name);
                Assert.Empty(items);
                items = efRepository.Read(x => x.StudentName == newName);
                Assert.NotEmpty(items);
                Assert.Equal(1, items.Count);

                //Delete
                efRepository.Delete(items[0]);
                context.SaveChanges();
                items.Clear();
                items = efRepository.Read(x => x.StudentName == newName);
                Assert.Empty(items);
            }
        }
    }
}
