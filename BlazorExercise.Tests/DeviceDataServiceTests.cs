using BlazorExercise.Models;
using BlazorExercise.Repositories;
using BlazorExercise.Services.Data;
using Moq;

namespace BlazorExercise.Tests
{
    public class DeviceDataServiceTests
    {
        [Fact]
        public void CanQueryDevices()
        {
            // Arrange

            var devices = Helpers.CreateFakeDevices().ToArray();
            var repository = new Mock<IDeviceRepository>();
            repository.SetupGet(d => d.Devices)
                .Returns(devices.AsQueryable());

            var service = new DeviceDataService(repository.Object);

            // Act

            var queriedDevices = service.GetDevices();

            // Assert

            Assert.Equal(devices, queriedDevices);
            repository.Verify(d => d.Devices, Times.Once);
        }

        [Fact]
        public void CanQueryDeviceById()
        {
            // Arrange

            var devices = Helpers.CreateFakeDevices().ToArray();
            var repository = new Mock<IDeviceRepository>();
            repository.SetupGet(d => d.Devices)
                .Returns(devices.AsQueryable());

            var service = new DeviceDataService(repository.Object);

            // Act

            var queriedDevice1 = service.GetDeviceById(2);
            var queriedDevice2 = service.GetDeviceById(4);

            // Assert

            Assert.Equal(queriedDevice1, devices.SingleOrDefault(d => d.Id == 2));
            Assert.Equal(queriedDevice2, devices.SingleOrDefault(d => d.Id == 4));
        }

        [Fact]
        public void CanAddDevice()
        {
            // Arrange

            var repository = new Mock<IDeviceRepository>();
            repository.Setup(d => d.CreateDevice(It.IsAny<Device>()))
                .Returns<Device>(d =>
                {
                    var devicesArray = new[] { d };
                    repository.SetupGet(repo => repo.Devices).Returns(devicesArray.AsQueryable());
                    return d;
                });

            var service = new DeviceDataService(repository.Object);

            // Act

            var deviceToCreate = new Device { Id = 1, Description = "ABCDE", Name = "ABC", Price = 12.45M };
            var returnedDevice = service.CreateDevice(deviceToCreate);

            // Assert

            Assert.Equal(deviceToCreate, returnedDevice);
            Assert.Equal(new[] { deviceToCreate }, repository.Object.Devices);
            repository.Verify(d => d.CreateDevice(It.IsAny<Device>()), Times.Once);
        }
    }
}
