using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFirst
{
    public class Group
    {
        public int Id { get; set; }

        public string Name { get; set; } = null!;

        public string Description { get; set; } = null!;

        public List<Student> Students { get; set; } = [];

        public int CuratorId { get; set; }

        public Curator? Curator { get; set; } = null!;
    }
}
