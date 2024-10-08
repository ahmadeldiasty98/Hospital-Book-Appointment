using Book_Appointment.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Book_Appointment.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Doctors> doctors { get; set; }
        public DbSet<BookedApp> bookedApps { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=Hospital-507;Integrated Security=True;TrustServerCertificate=True");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Doctors>().HasData(
                new Doctors { Id = 1, Name = "Dr. John Smith", Specialization = "Cardiology", Img = "doctor1.jpg" },
                new Doctors { Id = 2, Name = "Dr. Sarah Johnson", Specialization = "Pediatrics", Img = "doctor2.jpg" },
                new Doctors { Id = 3, Name = "Dr. Emily Davis", Specialization = "Dermatology", Img = "doctor4.jpg" },
                new Doctors { Id = 4, Name = "Dr. Michael Lee", Specialization = "Orthopedics", Img = "doctor3.jpg" },
                new Doctors { Id = 5, Name = "Dr. William Clark", Specialization = "Neurology", Img = "doctor5.jpg" }
            );

            base.OnModelCreating(modelBuilder);
        }
    }
}
