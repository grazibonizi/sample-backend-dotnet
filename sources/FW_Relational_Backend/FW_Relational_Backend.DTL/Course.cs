using FW_Relational_Backend.Abstraction.DTL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FW_Relational_Backend.DTL
{
    public class Course : IEntity<int>
    {
        public Course()
        {
            this.Students = new HashSet<Student>();
        }

        public int Id { get; set; }
        public string CourseName { get; set; }
        public int? TeacherId { get; set; }

        public virtual Teacher Teacher { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
}
