using FW_Relational_Backend.DTL;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW_Relational_Backend.DAL.EntityConfig
{
    public class CourseConfiguration : EntityTypeConfiguration<Course>
    {
        public CourseConfiguration()
        {
            Property(p => p.CourseName).IsRequired().HasMaxLength(250);

            //one-to-many relationship
            HasRequired(p => p.Teacher)
                .WithMany(c => c.Courses)
                .HasForeignKey(k => k.TeacherId);
        }
    }
}
