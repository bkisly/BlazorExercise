using BlazorExercise.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorExercise.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Device> Devices => Set<Device>();

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        { }
    }
}
