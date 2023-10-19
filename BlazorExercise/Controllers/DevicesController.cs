using BlazorExercise.Models;
using BlazorExercise.Repositories;
using BlazorExercise.Services.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorExercise.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DevicesController : ControllerBase
    {
        private readonly IDeviceDataService _deviceDataService;

        public DevicesController(IDeviceDataService deviceDataService)
        {
            _deviceDataService = deviceDataService;
        }

        [HttpGet]
        public IActionResult GetDevices()
        {
            return Ok(_deviceDataService.GetDevices());
        }

        [HttpGet("{id:int}")]
        public IActionResult GetDevice(int id)
        {
            return Ok(_deviceDataService.GetDeviceById(id));
        }

        [HttpPost]
        public IActionResult CreateDevice(Device device)
        {
            return CreatedAtAction(nameof(CreateDevice), _deviceDataService.CreateDevice(device));
        }

        [HttpPut("{id:int}")]
        public IActionResult EditDevice(int id, [FromBody] Device device)
        {
            _deviceDataService.UpdateDevice(device, id);
            return NoContent();
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteDevice(int id)
        {
            _deviceDataService.DeleteDevice(id);
            return NoContent();
        }
    }
}
