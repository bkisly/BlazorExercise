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
    }
}