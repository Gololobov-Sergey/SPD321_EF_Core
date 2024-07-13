using Microsoft.EntityFrameworkCore;

namespace BaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ReadStudentCourse();

        }

        static void AddStudentGroup3()
        {
            using (Spd321Context db = new Spd321Context())
            {

                Student student = new Student
                {
                    FirstName = "Anna",
                    LastName = "Doe",
                    BirthDay = new DateOnly(2010, 1, 1)
                };

                Group group = new Group
                {
                    Name = "SPD321",
                    Description = "Software Development",
                    Students = new List<Student> { student }
                };

                db.Groups.Add(group);
                db.Students.Add(student);

                db.SaveChanges();


            }
        }


        static void AddStudentGroup()
        {
            using (Spd321Context db = new Spd321Context())
            {
                Group group = new Group
                {
                    Name = "SPD321",
                    Description = "Software Development"
                };

                db.Groups.Add(group);
                db.SaveChanges();

                Student student = new Student
                {
                    FirstName = "Anna",
                    LastName = "Doe",
                    BirthDay = new DateOnly(2010, 1, 1),
                    GroupId = group.Id
                };

                db.Students.Add(student);
                
                db.SaveChanges();
            }
        }


        static void DeleteStudent()
        {
            using (Spd321Context db = new Spd321Context())
            {
                var students = db.Students.FirstOrDefault(s => s.FirstName == "John");
                if (students != null)
                {
                    db.Students.Remove(students);
                    db.SaveChanges();
                }
            }
        }


        static void EditStudent()
        {
            using (Spd321Context db = new Spd321Context())
            {
                var students = db.Students.FirstOrDefault(s => s.FirstName == "John");
                students.BirthDay = new DateOnly(1999, 1, 1);

                //db.Students.Update(students);

                db.SaveChanges();
            }
        }


        static void ReadStudentExam()
        {
            using (Spd321Context db = new Spd321Context())
            {
                var students = db.Students
                    .Include(s => s.Exam)
                        .ThenInclude(e => e.Course)
                    .ToList();
                foreach (var s in students)
                {
                    Console.WriteLine($"{s.LastName} {s.FirstName}");
                    foreach (var e in s.Exam)
                    {
                        Console.WriteLine($"  {e.Course.Name} {e.Mark}");
                    }
                }
            }
        }

        static void ReadStudentCourse()
        {
            using (Spd321Context db = new Spd321Context())
            {
                var students = db.Students
                    .Include(s => s.Courses)
                    .ToList();
                foreach (var s in students)
                {
                    Console.Write($"{s.LastName} {s.FirstName} : ");
                    foreach (var e in s.Courses)
                    {
                        Console.Write($" {e.Name}, ");
                    }
                    Console.WriteLine();
                }
            }
        }

        static void ReadStudent()
        {
            using (Spd321Context db = new Spd321Context())
            {
                var students = db.Students
                    .Include(s => s.Group)
                    .ToList();
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
        }


        static void ReadStudentGroupCuratorsAddressLogin()
        {
            using (Spd321Context db = new Spd321Context())
            {
                var students = db.Students
                    .Include(s => s.Group)
                        .ThenInclude(g => g.Curator)
                    .Include(s => s.Address)
                    .Include(s => s.Login)
                    .Where(s => s.Address!.Name == "Dnipro");

                string sql = students.ToQueryString();

                Console.WriteLine(sql);



                foreach (var s in students.ToList())
                {
                    Console.WriteLine($"{s.LastName} {s.FirstName}, {s.Group!.Name}, {s.Group!.Curator!.Name}, {s.Address!.Name}, {s.Login!.LoginName} {s.Login!.Password}");
                }
            }
        }

        static void ReadStudentGroupCuratorsAddress()
        {
            using (Spd321Context db = new Spd321Context())
            {
                var students = db.Students
                    .Include(s => s.Group)
                        .ThenInclude(g => g.Curator)
                    .Include(s => s.Address)
                    .Where(s => s.Address!.Name == "Dnipro")
                    .ToList();

                foreach (var s in students)
                {
                    Console.WriteLine($"{s.LastName} {s.FirstName}, {s.Group!.Name}, {s.Group!.Curator!.Name}, {s.Address!.Name}");
                }
            }
        }


        static void ReadStudentGroupCurators()
        {
            using (Spd321Context db = new Spd321Context())
            {
                var students = db.Students
                    .Include(s => s.Group)
                        //.ThenInclude(g => g.Curator)
                    .Include(s => s.Group!.Curator)
                    .ToList();

                foreach (var s in students)
                {
                    Console.WriteLine($"{s.LastName} {s.FirstName}, {s.Group!.Name} {s.Group!.Curator!.Name}");
                }
            }
        }


        static void ReadGroupStudent()
        {
            using (Spd321Context db = new Spd321Context())
            {
                var groups = db.Groups
                    .Include(g => g.Students)
                    .ToList();
                foreach (var group in groups)
                {
                   Console.WriteLine(group.Name);
                    foreach (var student in group.Students)
                    {
                        Console.WriteLine($"  {student.FirstName} {student.LastName}");
                    }
                }
            }
        }


        static void AddStudent()
        {
            using (Spd321Context db = new Spd321Context())
            {
                Student student = new Student
                {
                    FirstName = "John22222",
                    LastName = "Doe",   
                    BirthDay = new DateOnly(2000, 1, 1),
                    GroupId = 1 
                };

                db.Students.Add(student);
                db.SaveChanges();
            }
        }
    }
}


