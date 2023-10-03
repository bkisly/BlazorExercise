using BlazorExercise.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorExercise.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Device> Devices => Set<Device>();
        public DbSet<DeviceCategory> DeviceCategories => Set<DeviceCategory>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }
    }
}
