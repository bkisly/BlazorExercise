using BlazorExercise.Models;
using BlazorExercise.Repositories;

namespace BlazorExercise.Tests
{
    public class DeviceRepositoryTests
    {
        [Fact]
        public void CanQueryObjects()
        {
            // Arrange

            var devices = Helpers.CreateFakeDevices().ToArray();
            using var context = Helpers.CreateFakeContext(devices, "RepositoryQueryObjects");
            var repository = new DeviceRepository(context);

            context.Devices.AddRange(devices);
            context.SaveChanges();

            // Act

            var queriedDevices = repository.Devices;

            // Assert

            Assert.Equal(devices, queriedDevices);
        }

        [Fact]
        public void CanAddObjects()
        {
            // Arrange

            var devices = Helpers.CreateFakeDevices().ToArray();
            using var context = Helpers.CreateFakeContext(devices, "RepositoryAddObjects");
            var repository = new DeviceRepository(context);

            // Act

            foreach (var device in devices)
            {
                repository.CreateDevice(device);
            }

            // Assert

            Assert.Equal(devices, repository.Devices);
        }

        [Fact]
        public void CanUpdateObjects()
        {
            // Arrange

            var devices = Helpers.CreateFakeDevices().ToArray();
            using var context = Helpers.CreateFakeContext(devices, nameof(CanUpdateObjects));
            var repository = new DeviceRepository(context);

            foreach (var device in devices)
            {
                context.Devices.Add(device);
            }

            context.SaveChanges();

            // Act

            repository.UpdateDevice(2, new Device { Name = "Changed", Price = 24M, Category = context.DeviceCategories.First()});

            // Assert

            Assert.Equal( "Changed", context.Devices.Single(d => d.Id == 2).Name);
            Assert.Equal( 24M, context.Devices.Single(d => d.Id == 2).Price);
        }
    }
}