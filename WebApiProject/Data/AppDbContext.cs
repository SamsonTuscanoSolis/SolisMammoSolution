using Microsoft.EntityFrameworkCore;
using System.Text.Json;
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

        public DbSet<Order> Orders => Set<Order>();
        public DbSet<OrderItem> OrderItems => Set<OrderItem>();

        public DbSet<Slot> Slots => Set<Slot>();

        public DbSet<CampaignEligibility> CampaignEligibilities => Set<CampaignEligibility>();

        public DbSet<Facility> Facilities => Set<Facility>();

        // Seed the database with some dummy data
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Mark entities as keyless
            modelBuilder.Entity<Patient>().HasNoKey();
            modelBuilder.Entity<Appointment>().HasNoKey();
            modelBuilder.Entity<ExamResult>().HasNoKey();
            modelBuilder.Entity<Communication>().HasNoKey();
            modelBuilder.Entity<Insurance>().HasNoKey();
            modelBuilder.Entity<Order>().HasNoKey();
            modelBuilder.Entity<OrderItem>().HasNoKey();
            modelBuilder.Entity<Slot>().HasNoKey();
            modelBuilder.Entity<CampaignEligibility>().HasNoKey();

            // Facility must have a key to support HasData
            modelBuilder.Entity<Facility>().HasKey(f => f.FacilityId);

            // Convert List<string> to JSON for storage (configure BEFORE seeding)
            //modelBuilder.Entity<Facility>()
            //    .Property(f => f.ModalitiesAvailable)
            //    .HasConversion(
            //        v => JsonSerializer.Serialize(v, (JsonSerializerOptions)null),
            //        v => JsonSerializer.Deserialize<List<string>>(v, (JsonSerializerOptions)null));

            // Add dummy data for Facilities
            modelBuilder.Entity<Facility>().HasData(
                new Facility
                {
                    FacilityId = 1,
                    Name = "City Hospital",
                    Address = "123 Main St, Cityville",
                    Phone = "555-1234",
                    Hours = "8AM - 6PM",
                    ModalitiesAvailable = new List<string> { "MRI", "CT Scan" },
                    AcceptingStatus = true,
                    Latitude = 40.7128,
                    Longitude = -74.0060
                },
                new Facility
                {
                    FacilityId = 2,
                    Name = "Suburban Clinic",
                    Address = "456 Oak Ave, Suburbia",
                    Phone = "555-5678",
                    Hours = "9AM - 5PM",
                    ModalitiesAvailable = new List<string> { "X-ray", "Ultrasound" },
                    AcceptingStatus = true,
                    Latitude = 34.0522,
                    Longitude = -118.2437
                },
                new Facility
                {
                    FacilityId = 3,
                    Name = "Rural Health Center",
                    Address = "789 Pine Rd, Ruraltown",
                    Phone = "555-8765",
                    Hours = "8AM - 4PM",
                    ModalitiesAvailable = new List<string> { "CT Scan" },
                    AcceptingStatus = false,
                    Latitude = 36.7783,
                    Longitude = -119.4179
                }
            );
        }
    }

}
