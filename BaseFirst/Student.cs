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

    public string FirstName { get; set; } = null!;
    public string LastName { get; set; } = null!;

    public DateOnly BirthDay { get; set; }

    [NotMapped]
    public string?  PersonalInfo { get; set; }

    public DateTime CreatedAt { get; set; }

    public int GroupId { get; set; }            // FK

    public Group? Group { get; set; } = null!;  // Navigation property

    public int AddressId { get; set; }

    public Address? Address { get; set; }

    public int LoginId { get; set; }

    public Login? Login { get; set; }

    public List<Course> Courses { get; set; } = [];
    public List<Exam> Exam { get; set; } = [];


    override public string ToString()
    {
        return $"Id: {Id}, Name: {LastName} {FirstName}, BirthDay: {BirthDay}, Group: {Group!.Name}";
    }
}
