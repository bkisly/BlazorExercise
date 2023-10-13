using BlazorExercise.Models;

namespace BlazorExercise.Services.Data
{
    public interface IDeviceDataService
    {
        IEnumerable<Device> GetDevices();
        Device GetDeviceById(int id);
        Device CreateDevice(Device device);
        void UpdateDevice(Device device, int id);
        void DeleteDevice(int id);
    }
}
