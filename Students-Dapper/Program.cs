using Microsoft.Data.SqlClient;
using Dapper;
using Students_Dapper.Models;
using System.Data;


namespace Students_Dapper
{
    internal class Program
    {
        static string connectionString =
               "Data Source=TAURUS\\SQLEXPRESS;" +
               "Initial Catalog=SPD321;" +
               "Integrated Security=True;" +
               "Connect Timeout=30;" +
               "Encrypt=False;" +
               "Trust Server Certificate=True;" +
               "Application Intent=ReadWrite;" +
               "Multi Subnet Failover=False";

        //static SqlConnection connection = new SqlConnection(connectionString);

        static void Main(string[] args)
        {
            //Select();

            //Insert();

            //Update();

            //GetCount();

            //SelectFromID();

            //SelectField();

            //SelectStudentAndGroup();

            //SelectStudentAndGroupAndCurator();

            //SelectStudentReader();

            SelectStudentToTable().PrintList();
        }


        static void Select()
        {
            using (var connection = new SqlConnection(connectionString))
            {

                string sql = "SELECT * FROM Students";

                var students = connection.Query<Student>(sql);

                foreach (var student in students)
                {
                    Console.WriteLine(student);
                }
            }
        }


        static void SelectFromID()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                Console.Write("ID : ");
                int id = Convert.ToInt32(Console.ReadLine());
                string sql = $"SELECT * FROM Students WHERE Id = {id}";

                var student = connection.QuerySingleOrDefault<Student>(sql);

                Console.WriteLine(student);

            }
        }


        static void SelectStudentAndGroup()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * " +
                             "FROM Students s " +
                             "JOIN Groups g ON s.GroupId = g.Id";

                var students = connection.Query<Student, Group, Student>(sql, (s, g) =>
                {                     
                    s.Group = g;
                    return s;
                }, 
                splitOn: "Id");


                foreach (var s in students)
                {
                    Console.WriteLine($"{s.Id} {s.FirstName} {s.LastName} {s.BirthDay.ToShortDateString()} {s.Group.Name}");
                }
            }
        }


        static void SelectStudentAndGroupAndCurator()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * " +
                             "FROM Students s " +
                             "JOIN Groups g ON s.GroupId = g.Id " +
                             "JOIN Curators c ON g.CuratorId = c.Id";

                var students = connection.Query<Student, Group, Curator, Student>(sql, (s, g, c) =>
                {
                    s.Group = g;
                    g.Curator = c;
                    return s;
                },
                splitOn: "Id");


                foreach (var s in students)
                {
                    Console.WriteLine($"{s.Id} {s.FirstName} {s.LastName} {s.BirthDay.ToShortDateString()} {s.Group.Name} {s.Group!.Curator!.Name}");
                }
            }
        }


        static void SelectStudentReader()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT * FROM Students";
                var reader = connection.ExecuteReader(sql);
                while(reader.Read())
                {
                    string fn = reader.GetString(1);
                    string ln = reader.GetString(2);
                    //Console.WriteLine(reader["FirstName"] + " " + reader["LastName"]);
                    Console.WriteLine($"{fn} {ln}");
                }
            }
        }


        static DataTable SelectStudentToTable()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sql = "SELECT s.FirstName, s.Lastname, s.BirthDay, g.Name, c.Name " +
                              "FROM Students s " +
                              "JOIN Groups g ON s.GroupId = g.Id " +
                              "JOIN Curators c ON g.CuratorId = c.Id";

                var reader = connection.ExecuteReader(sql);
                DataTable table = new DataTable();
                table.Load(reader);

               return table;

                //foreach (DataRow row in table.Rows)
                //{
                //    Console.WriteLine($"{row[0]} {row[1]} {row[2]} {row[3]} {row[4]}");
                //}
            }
        }


        static void SelectField()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                Console.Write("ID : ");
                int id = Convert.ToInt32(Console.ReadLine());
                string sql = $"SELECT FirstName, LastName FROM Students WHERE Id = {id}";

                var student = connection.QuerySingleOrDefault(sql);
                if (student != null)
                {
                    Console.WriteLine(student.FirstName + " " + student.LastName);
                }
                
            }
        }

        static void Insert()
        {
            using (var connection = new SqlConnection(connectionString))
            {
                string sqlLogin = "INSERT INTO " +
                    "Login (LoginName, Password) " +
                    "VALUES (@Log, @Pass)";
               var paramLogin = new List<object>{
                    new{ @log = "login44", @pass = "password44" },
                    new{ @log = "login55", @pass = "password55" },
                    new{ @log = "login66", @pass = "password66" }
                };
                int rowsLogin = connection.Execute(sqlLogin, paramLogin);


                //string sqlLoginId = "SELECT Id FROM Login WHERE LoginName='login33' AND Password='password33'";
                //int ID = connection.ExecuteScalar<int>(sqlLoginId);


                //string sql = "INSERT INTO " +
                //    "Students (FirstName, LastName, BirthDay, GroupId, AddressId, LoginId) " +
                //    "VALUES(@FN, @LN, @BD, @GrID, @AddID, @LogID)";
                //object[] param = {
                //    new{
                //        FN = "Anna",
                //        LN = "Smith",
                //        BD = "2002-05-05",
                //        GrId = 1,
                //        AddId = 1,
                //        LogID = ID
                //    }
                //};
                
                //int rows = connection.Execute(sql, param);
                //Console.WriteLine($"Added {rows} rows");
            }
        }

        static void Update()
        {
            using (var connection = new SqlConnection(connectionString))
            {

                string sql = $"UPDATE Students SET GroupID = 2 WHERE Id = 5";

                var rows = connection.Execute(sql);
                Console.WriteLine($"Added {rows} rows");
            }
        }

        static void GetCount()
        {
            using (var connection = new SqlConnection(connectionString))
            {

                string sql = "SELECT COUNT(*) FROM Students";


                var rows = connection.ExecuteScalar<int>(sql);
                Console.WriteLine($"Count {rows} rows");
            }
        }

    }
}
