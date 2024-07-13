using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BaseFirst;

public partial class Spd321Context : DbContext
{
    public Spd321Context()
    {
       //Database.EnsureDeleted();
       //Database.EnsureCreated();
    }


    public Spd321Context(DbContextOptions<Spd321Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Student> Students { get; set; }
    public virtual DbSet<Group> Groups { get; set; }
    public virtual DbSet<Curator> Curators { get; set; }
    public virtual DbSet<Course> Courses { get; set; }
    public virtual DbSet<Exam> Exam { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer(
            "Data Source=TAURUS\\SQLEXPRESS;" +
            "Initial Catalog=SPD321;" +
            "Integrated Security=True;" +
            "Connect Timeout=30;" +
            "Encrypt=False;" +
            "Trust Server Certificate=True;" +
            "Application Intent=ReadWrite;" +
            "Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Ignore<Address>();

        //modelBuilder.Ignore<Group>();

        modelBuilder.Entity<Student>().Ignore(s => s.PersonalInfo);

        //modelBuilder.Entity<Student>().ToTable("Users");

        //modelBuilder.Entity<Student>()
        //    .HasKey(s => new {s.Name, s.LastName})
        //    .HasName("MyName");

        //modelBuilder.Entity<Student>().HasAlternateKey(s => s.PersonalInfo);

        //modelBuilder.Entity<Group>().HasIndex(g => g.Name).IsUnique();

        modelBuilder.Entity<Student>()
            .Property(s => s.BirthDay)
            .HasDefaultValue(new DateOnly(2000, 1, 1));

        modelBuilder.Entity<Student>()
            .Property(s => s.CreatedAt)
            .HasDefaultValueSql("GETDATE()");


        //modelBuilder.Entity<Student>()
        //    .HasOne(s => s.Group)
        //    .WithMany(g => g!.Students)
        //    .HasForeignKey(s => s.GroupId);


        //modelBuilder.Entity<Student>()
        //    .HasOne(s => s.Login)
        //    .WithOne(l => l.Student)
        //    .HasForeignKey<Student>(s => s.Id);
        //modelBuilder.Entity<Student>().ToTable("Students");
        //modelBuilder.Entity<Login>().ToTable("Students");



        modelBuilder.Entity<Student>().HasData(
            new Student
            {
                Id = 1,
                FirstName = "John",
                LastName = "Doe",
                BirthDay = new DateOnly(2000, 1, 1),
                GroupId = 1,
                AddressId = 1,
                LoginId = 1
            },
            new Student
            {
                Id = 2,
                FirstName = "Jane",
                LastName = "Doe",
                BirthDay = new DateOnly(1999, 1, 1),
                GroupId = 2,
                AddressId = 2,
                LoginId = 2
              
            },
            new Student
            {
                Id = 3,
                FirstName = "Jack",
                LastName = "Doe",
                BirthDay = new DateOnly(1998, 1, 1),
                GroupId = 1,
                AddressId = 2,
                LoginId = 3
            }
        );

        modelBuilder.Entity<Group>().HasData(
            new Group
            {
                Id = 1,
                Name = "Group 1",
                Description = "Description 1",
                CuratorId = 2
            },
            new Group
            {
                Id = 2,
                Name = "Group 2",
                Description = "Description 2",
                CuratorId = 1
            }
        );


        modelBuilder.Entity<Curator>().HasData(
            new Curator
            {
                Id = 1,
                Name = "Curator 1"
            },
            new Curator
            {
                Id = 2,
                Name = "Curator 2"
            }
        );


        modelBuilder.Entity<Address>().HasData(
            new Address
            {
                Id = 1,
                Name = "Odesa"
            },
            new Address
            {
                Id = 2,
                Name = "Dnipro"
            }
        );


        modelBuilder.Entity<Login>().HasData(
            new Login
            {
                Id = 1,
                LoginName = "login1",
                Password = "password1"
            },
            new Login
            {
                Id = 2,
                LoginName = "login2",
                Password = "password2"
            },
            new Login
            {
                Id = 3,
                LoginName = "login3",
                Password = "password3"
            }
        );


        modelBuilder.Entity<Course>().HasData(
            new Course
            {
                Id = 1,
                Name = "SQL"
            },
            new Course
            {
                Id = 2,
                Name = "EF Core"
            }
        );

        modelBuilder.Entity<Exam>().HasData(
            new Exam
            {
                Id = 1,
                StudentId = 1,
                CourseId = 1,
                Mark = 10
            },
            new Exam
            {
                Id = 2,
                StudentId = 1,
                CourseId = 2,
                Mark = 12
            },
            new Exam
            {
                Id = 3,
                StudentId = 2,
                CourseId = 1,
                Mark = 11
            }
        );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
