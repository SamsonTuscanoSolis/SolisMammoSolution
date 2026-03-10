using Microsoft.EntityFrameworkCore;
using WebApiProject.Models;

namespace WebApiProject.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Appointment> Appointments => Set<Appointment>();
        public DbSet<ExamResult> ExamResults => Set<ExamResult>();
        public DbSet<Communication> Communications => Set<Communication>();
        public DbSet<Insurance> Insurances => Set<Insurance>();
    }

}
