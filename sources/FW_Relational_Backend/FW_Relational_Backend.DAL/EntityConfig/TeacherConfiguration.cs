using FW_Relational_Backend.DTL;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW_Relational_Backend.DAL.EntityConfig
{
    public class TeacherConfiguration : EntityTypeConfiguration<Teacher>
    {
        public TeacherConfiguration()
        {
            Property(p => p.TeacherName).IsRequired().HasMaxLength(250);
        }
    }
}
