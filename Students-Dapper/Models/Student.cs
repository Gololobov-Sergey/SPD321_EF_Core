using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Students_Dapper.Models
{
    public class Student
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public DateTime CreatedAt { get; set; }
        public int GroupId { get; set; }

        public Group Group { get; set; }
        public int AddressId { get; set; }
        public int LoginId { get; set; }


        override public string ToString()
        {
            return $"{Id} {FirstName} {LastName} {BirthDay} {GroupId} {AddressId} {LoginId}";
        }
    }
}
