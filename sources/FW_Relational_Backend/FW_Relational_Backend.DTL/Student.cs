using FW_Relational_Backend.Abstraction.DTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW_Relational_Backend.DTL
{
    public class Student : IEntity<int>
    {
        public Student()
        {
            this.Courses = new HashSet<Course>();
        }

        public int Id { get; set; }
        public string StudentName { get; set; }
        
        public virtual StudentAddress StudentAddress { get; set; }
        public virtual ICollection<Course> Courses { get; set; }
    }
}
