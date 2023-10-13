using BlazorExercise.Models;

namespace BlazorExercise.Repositories
{
    public interface IDeviceRepository
    {
        public IQueryable<Device> Devices { get; }

        public Device CreateDevice(Device device);
        public void UpdateDevice(int deviceId, Device device);
        public void DeleteDevice(int deviceId);
    }
}
