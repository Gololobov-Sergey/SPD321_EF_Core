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

    //public virtual DbSet<Group> Groups { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=TAURUS\\SQLEXPRESS;Initial Catalog=SPD321;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Student>(entity =>
        {
            entity.Property(e => e.Name).HasMaxLength(50);
            //entity.Property(e => e.LastName).HasMaxLength(50);
        });

        modelBuilder.Ignore<Address>();

        modelBuilder.Ignore<Group>();

        modelBuilder.Entity<Student>().Ignore(s => s.PersonalInfo);

        //modelBuilder.Entity<Student>().ToTable("Users");

        //modelBuilder.Entity<Student>()
        //    .HasKey(s => new {s.Name, s.LastName})
        //    .HasName("MyName");

        //modelBuilder.Entity<Student>().HasAlternateKey(s => s.PersonalInfo);

        modelBuilder.Entity<Student>()
            .Property(s => s.BirthDay)
            .HasDefaultValue(new DateOnly(2000, 1, 1));

        modelBuilder.Entity<Student>()
            .Property(s => s.CreatedAt)
            .HasDefaultValueSql("GETDATE()");

        modelBuilder.Entity<Student>().HasData(
            new Student
            {
                Id = 1,
                Name = "John",
                LastName = "Doe",
                BirthDay = new DateOnly(2000, 1, 1)
            },
            new Student
            {
                Id = 2,
                Name = "Jane",
                LastName = "Doe",
                BirthDay = new DateOnly(1999, 1, 1)
            }
        );

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
