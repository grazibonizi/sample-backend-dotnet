
using FizzWare.NBuilder;
using System;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using FW_Relational_Backend.DAL.Tests;
using System.Collections.Generic;
using FW_Relational_Backend.DAL.Contexts;
using FW_Relational_Backend.DTL;

namespace FW_Relational_Backend.DAL.Tests.MSSQL_Integration_Tests
{
    public class Seeder
    {
        protected void Seed(DefaultContext context)
        {
            var teachers = Builder<Teacher>.CreateListOfSize(10)
                .All()
                    .With(c => c.TeacherName = Faker.Name.FullName()).Build();
            context.Teachers.AddOrUpdate(teachers.ToArray());

            var courses = Builder<Course>.CreateListOfSize(20)
                .All()
                    .With(c => c.CourseName = Faker.Company.CatchPhrase())
                    .With(c => c.Teacher = teachers[Faker.RandomNumber.Next(0, 10)]).Build();
            context.Courses.AddOrUpdate(courses.ToArray());

            var students = Builder<Student>.CreateListOfSize(100)
                .All()
                    .With(c => c.StudentName = Faker.Name.FullName())
                    .With(c => c.StudentAddress = new StudentAddress()
                    {
                        Address = Faker.Address.StreetAddress(),
                        City = Faker.Address.City(),
                        State = Faker.Address.UsState()
                    })
                    .With(c => c.Courses = new List<Course>(3)
                    {
                        courses[Faker.RandomNumber.Next(0, 10)],
                        courses[Faker.RandomNumber.Next(0, 10)],
                        courses[Faker.RandomNumber.Next(0, 10)]
                    })
                    .Build();
            context.Students.AddOrUpdate(students.ToArray());

            context.SaveChanges();
        }
    }
}
