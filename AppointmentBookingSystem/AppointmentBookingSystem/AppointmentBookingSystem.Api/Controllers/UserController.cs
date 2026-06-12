using MediatR;
using Microsoft.AspNetCore.Mvc;
using AppointmentBookingSystem.Domain.Entities;
using AppointmentBookingSystem.Application.Command.UserCommand;
using AppointmentBookingSystem.Application.Quiries.UserQueries;

namespace AppointmentBookingSystem.Api.Controllers
{

    [ApiController]
    public class UserController(ISender sender, ILogger<UserController> _logger) : ControllerBase
    {
        [HttpGet("api/getallusersasync")]
        public async Task<IActionResult> GetAllUserAsync()
        {
            var result = await sender.Send(new GetAllUsersQuery());
            return Ok(result);
        }

        [HttpGet("api/getuserbyidasync")]
        public async Task<IActionResult> GetUserByIdAsync(string username, string password)
        {
            var result = await sender.Send(new GetUserByIdQuery(password, username));
            if (result is not null)
            {
                _logger.LogInformation($"User details: {result}");
                return Ok(result);
            }
            return StatusCode(500, new { message = "user not found." });
        }

        [HttpPost("api/adduserasync")]
        public async Task<IActionResult> AddUserAsync([FromBody] UserEntity userEntitiy)
        {
            var result = await sender.Send(new AddUserCommand(userEntitiy));
            _logger.LogInformation($"Add user details {DateTime.Today}: {result}");
            return Ok(result);
        }

        //// PUT api/<UserController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        //// DELETE api/<UserController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
