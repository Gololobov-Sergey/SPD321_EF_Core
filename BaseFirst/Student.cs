using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseFirst;

//[Table("Users")]
public partial class Student
{
    //[Column("stud_id")]
    
    public int Id { get; set; }

    public string Name { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public DateOnly BirthDay { get; set; }

    [NotMapped]
    public string?  PersonalInfo { get; set; }

    public DateTime CreatedAt { get; set; }


    override public string ToString()
    {
        return $"Id: {Id}, Name: {Name}, BirthDay: {BirthDay}";
    }
}
