using DriversAppApi.Models;
using DriversAppApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace DriversAppApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MessengeController: ControllerBase
    {
        private MessengerService _messengerService;

        public MessengeController(MessengerService messengerService)
        {
            _messengerService = messengerService;
        }
        [HttpGet("{id:length(24)}")]
        public async Task<IActionResult> GetMessengerById(string id)
        {
            var existingDriver = await _messengerService.GetAsync(id);
            if(existingDriver is null)
                return NotFound();
            return Ok(existingDriver);
        }
        [HttpGet]
        public async Task<ActionResult> GetMessenger()
        {
            var allMessage = await _messengerService.GetAsync();
            if(allMessage.Any())
                return Ok(allMessage);
            return NotFound();
        }
        [HttpPost]
        public async Task<IActionResult> CreateMessenger(Messenger messenger)
        {
            await _messengerService.CreateAsync(messenger);
            return CreatedAtAction(nameof(GetMessengerById), new{id = messenger.Id}, messenger);
        }
        [HttpPut("{id:length(24)}")]
        public async Task<IActionResult> PutMessenger(string id, Messenger messenger)
        {
            var existingMessenger = await _messengerService.GetAsync(id);
            if(existingMessenger is null)
                return BadRequest();
            id = messenger.Id;
            await _messengerService.UpdateAsync(messenger);
            return NoContent();
        }
        [HttpDelete("{id:length(24)}")]
        public async Task<IActionResult> DeleteMessenger(string id)
        {
            var existingMessenger = await _messengerService.GetAsync(id);
            if(existingMessenger is null)
                return BadRequest();
            await _messengerService.DeleteAsync(id);
            return NoContent();
        }
    }
}