using BlazorExercise.Data;
using BlazorExercise.Models;

namespace BlazorExercise.Repositories
{
    public class DeviceRepository : IDeviceRepository
    {
        private readonly ApplicationDbContext _context;

        public IQueryable<Device> Devices => _context.Devices;

        public DeviceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void CreateDevice(Device device)
        {
            _context.Devices.Add(device);
            _context.SaveChanges();
        }

        public void UpdateDevice(int deviceId, Device device)
        {
            var deviceToUpdate = _context.Devices.Single(d => d.Id == deviceId);
            device.MapTo(deviceToUpdate);
            _context.SaveChanges();
        }

        public void DeleteDevice(int deviceId)
        {
            var deviceToDelete = _context.Devices.Single(device => device.Id == deviceId);
            _context.Devices.Remove(deviceToDelete);
            _context.SaveChanges();
        }
    }
}
