using Microsoft.EntityFrameworkCore;

namespace VehicleDBSystem.Models
{
    public class VehicleContext : DbContext
    {
        public VehicleContext(DbContextOptions<VehicleContext> options) 
            : base(options)
        { }
        public DbSet<Vehicle> Vehicles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Vehicle>().HasData(new Vehicle
            {
                VehicleId = 1,
                Year = 1996,
                Make = "HONDA",
                Model = "CIVIC",
                Trim = "LX",
                Type = "SEDAN"
            }, new Vehicle
            {
                VehicleId = 2,
                Year = 1999,
                Make = "HONDA",
                Model = "CIVIC",
                Trim = "DX",
                Type = "SEDAN"
            }, new Vehicle
            {
                VehicleId = 3,
                Year = 1997,
                Make = "HONDA",
                Model = "CIVIC",
                Trim = "CX",
                Type = "HATCHBACK"
            });
        }
    }
}
