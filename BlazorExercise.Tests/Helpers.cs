using BlazorExercise.Data;
using BlazorExercise.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorExercise.Tests
{
    internal static class Helpers
    {
        internal static IEnumerable<Device> CreateFakeDevices()
        {
            var categories = new List<DeviceCategory>
            {
                new() { Name = "C1" },
                new() { Name = "C2" },
                new() { Name = "C3" },
            };

            return new[]
            {
                new Device { Name = "D1", Category = categories[0], Description = "Desc 1", Price = 23.9M },
                new Device { Name = "D2", Category = categories[0], Description = "Desc 2", Price = 3.12M },
                new Device { Name = "D3", Category = categories[1], Description = "Desc 3", Price = 199M },
                new Device { Name = "D4", Category = categories[1], Description = "Desc 4", Price = 2.56M },
                new Device { Name = "D5", Category = categories[2], Description = "Desc 5", Price = 45.65M },
                new Device { Name = "D6", Category = categories[2], Description = "Desc 6", Price = 14.6M }
            };
        }

        internal static ApplicationDbContext CreateFakeContext(IEnumerable<Device> devices, string databaseName)
        {
            var options = new DbContextOptionsBuilder<ApplicationDbContext>().UseInMemoryDatabase(databaseName: databaseName).Options;
            return new ApplicationDbContext(options);
        }
    }
}
