namespace BaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            DeleteStudent();
        }


        static void DeleteStudent()
        {
            using (Spd321Context db = new Spd321Context())
            {
                var students = db.Students.FirstOrDefault(s => s.Name == "John");
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
                var students = db.Students.FirstOrDefault(s => s.Name == "John");
                students.BirthDay = new DateOnly(1999, 1, 1);

                //db.Students.Update(students);

                db.SaveChanges();
            }
        }

        static void ReadStudent()
        {
            using (Spd321Context db = new Spd321Context())
            {
                var students = db.Students.ToList();
                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
        }


        static void AddStudent()
        {
            using (Spd321Context db = new Spd321Context())
            {
                Student student = new Student
                {
                    Name = "John",
                    BirthDay = new DateOnly(2000, 1, 1)
                };

                db.Students.Add(student);
                db.SaveChanges();
            }
        }
    }
}


