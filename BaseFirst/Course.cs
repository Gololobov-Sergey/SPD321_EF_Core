using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFirst
{
    public class Course
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public List<Student> Students { get; set; } = [];

        public List<Exam> Exam { get; set; } = [];

    }
}
