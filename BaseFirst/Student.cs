using System;
using System.Collections.Generic;

namespace BaseFirst;

public partial class Student
{
    public int Id { get; set; }

    public string Name { get; set; } = null!;

    public DateOnly BirthDay { get; set; }


    override public string ToString()
    {
        return $"Id: {Id}, Name: {Name}, BirthDay: {BirthDay}";
    }
}
