using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseFirst
{
    public class Login
    {
        public int Id { get; set; }
        public string LoginName { get; set; } = null!;
        public string Password { get; set; } = null!;

        public Student? Student { get; set; } = null!;

        public override string ToString()
        {
            return $"Id: {Id}, LoginName: {LoginName}, Password {Password}";
        }
    }
}
