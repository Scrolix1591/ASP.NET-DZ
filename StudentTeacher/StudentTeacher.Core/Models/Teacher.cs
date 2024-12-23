using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentTeacher.Core.Models
{
    public class Teacher : User
    {
        public virtual ICollection<Subject> Subjects { get; set; }
        public int Salary { get; set; }
        public DateTime EmployedAt { get; set; }
    }
}
