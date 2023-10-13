using BlazorExercise.Models;
using BlazorExercise.Repositories;

namespace BlazorExercise.Services.Data
{
    public class DeviceDataService : IDeviceDataService
    {
        private readonly IDeviceRepository _repository;

        public DeviceDataService(IDeviceRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<Device> GetDevices()
        {
            return _repository.Devices.ToArray();
        }

        public Device GetDeviceById(int id)
        {
            return _repository.Devices.Single(d => d.Id == id);
        }

        public Device CreateDevice(Device device)
        {
            return _repository.CreateDevice(device);
        }

        public void UpdateDevice(Device device, int id)
        {
            _repository.UpdateDevice(id, device);
        }

        public void DeleteDevice(int id)
        {
            _repository.DeleteDevice(id);
        }
    }
}
