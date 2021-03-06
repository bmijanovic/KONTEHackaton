using KONTEHackaton.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KONTEHackaton.Data.Context
{
    public class FacultyContext : DbContext
    {
        public DbSet<WorkingHours> WorkingHours { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Desk> Desks { get; set; }

        public FacultyContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<WorkingHours>()
                .HasMany(x => x.Faculties)
                .WithOne(x => x.WorkingHours)
                .IsRequired();
            modelBuilder.Entity<Faculty>()
                .HasOne(x => x.WorkingHours)
                .WithMany(x => x.Faculties)
                .HasForeignKey(x => x.WorkingHoursId)
                .IsRequired();

 
            modelBuilder.Entity<Room>()
                .HasOne(x => x.Faculty).
                WithMany(x => x.Rooms).
                HasForeignKey(x => x.FacultyId).
                IsRequired();
            modelBuilder.Entity<Faculty>()
                .HasMany(x => x.Rooms)
                .WithOne(x => x.Faculty)
                .IsRequired();


            modelBuilder.Entity<Desk>()
                .HasOne(x => x.Room)
                .WithMany(x => x.Desks)
                .HasForeignKey(x => x.RoomId)
                .IsRequired();
            modelBuilder.Entity<Room>()
                .HasMany(x => x.Desks)
                .WithOne(x => x.Room)
                .IsRequired();

        }


    }
}
