using BlazorExercise.Data;
using BlazorExercise.Models;
using Microsoft.EntityFrameworkCore;

namespace BlazorExercise.Utils
{
    public static class DataFactory
    {
        public static void PopulateDeviceCategories(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider
                .GetRequiredService<ApplicationDbContext>();

            if (context.Database.GetPendingMigrations().Any())
                context.Database.Migrate();

            if (context.DeviceCategories.Any()) 
                return;

            context.DeviceCategories.AddRange(
                new List<DeviceCategory>
                {
                    new() { Name = "PC hardware" },
                    new() { Name = "Smartphones" },
                    new() { Name = "Peripherals" },
                    new() { Name = "Accessories" },
                });

            context.SaveChanges();
        }
    }
}
