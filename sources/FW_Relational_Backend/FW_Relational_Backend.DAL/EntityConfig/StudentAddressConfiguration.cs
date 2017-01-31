using FW_Relational_Backend.DTL;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW_Relational_Backend.DAL.EntityConfig
{
    public class StudentAddressConfiguration : EntityTypeConfiguration<StudentAddress>
    {
        public StudentAddressConfiguration()
        {
            Property(p => p.Address).IsRequired().HasMaxLength(250);
            Property(p => p.State).IsRequired().HasMaxLength(250);
            Property(p => p.City).IsRequired().HasMaxLength(250);
        }
    }
}
