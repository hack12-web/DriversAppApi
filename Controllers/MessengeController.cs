using DriversAppApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DriversAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessengeController: ControllerBase
    {
        private readonly DriverService _driverService;
        public MessengeController(DriverService driverService)
        {
            _driverService = driverService;
        }
        [HttpGet]
        public async Task<ActionResult> GetMessge()
        {
            var allMessage = await _driverService.GetMessenger();
            if(allMessage.Any())
                return Ok(allMessage);
            return NotFound();
        }
    }
}