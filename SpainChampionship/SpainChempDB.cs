using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Reflection.Emit;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SpainChampionship.Models;

namespace SpainChampionship
{

    public partial class SpainChempDB : DbContext
    {
        public SpainChempDB()
        {
            //Database.EnsureDeleted();
            //Database.EnsureCreated();
        }

        public virtual DbSet<Team> Teams { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)

            => optionsBuilder.UseSqlServer("Data Source=TAURUS\\SQLEXPRESS;" +
                "Initial Catalog=Primera;" +
                "Integrated Security=True;" +
                "Connect Timeout=30;" +
                "Encrypt=False;" +
                "Trust Server Certificate=True;" +
                "Application Intent=ReadWrite;" +
                "Multi Subnet Failover=False");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Team>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Team>()
                .Property(p => p.City)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Team>().HasData(
                new Team { Id = 1, Name = "Real Madrid", City = "Madrid", Wins = 0, Lose = 0, Draw = 0 },
                new Team { Id = 2, Name = "Barcelona", City = "Barcelona", Wins = 0, Lose = 0, Draw = 0 },
                new Team { Id = 3, Name = "Atletico Madrid", City = "Madrid", Wins = 0, Lose = 0, Draw = 0 },
                new Team { Id = 4, Name = "Valencia", City = "Valencia", Wins = 0, Lose = 0, Draw = 0 },
                new Team { Id = 5, Name = "Sevilla", City = "Sevilla", Wins = 0, Lose = 0, Draw = 0 },
                new Team { Id = 6, Name = "Real Sociedad", City = "San Sebastian", Wins = 0, Lose = 0, Draw = 0 },
                new Team { Id = 7, Name = "Villarreal", City = "Villarreal", Wins = 0, Lose = 0, Draw = 0 });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
