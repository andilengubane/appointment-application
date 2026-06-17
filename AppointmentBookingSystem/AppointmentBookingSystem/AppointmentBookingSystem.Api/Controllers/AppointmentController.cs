using MediatR;
using Microsoft.AspNetCore.Mvc;
using AppointmentBookingSystem.Domain.Entities;
using AppointmentBookingSystem.Application.Command.AppointmentCommand;
using AppointmentBookingSystem.Application.Quiries.AppointmentQueries;

namespace AppointmentBookingSystem.Api.Controllers
{
    [ApiController]
    public class AppointmentController(ISender sender, ILogger<AppointmentController> _logger) : ControllerBase
    {
        [HttpGet("api/getallappointmentsasync")]
        public async Task<IActionResult> GetAllAppointmentAsync()
        {
            var result = await sender.Send(new GetAllAppointmentQuery());
            return Ok(result);
        }

        [HttpGet("api/getappointmentbyidasync")]
        public async Task<IActionResult> GetAppointmentByIdAsync(Guid id)
        {
            var result = await sender.Send(new GetAppointmentByIdQuery(id));
            if (result is not null)
            {
                _logger.LogInformation($"Appointment details: {result}");
                return Ok(result);
            }
            return StatusCode(500, new { message = "appointment not found." });
        }

        [HttpPost("api/addappointmentasync")]
        public async Task<IActionResult> AddAppointmentAsync([FromBody] AppointmentEntity appointmentEntity)
        {
            var result = await sender.Send(new AddAppointmentCommand(appointmentEntity));
            _logger.LogInformation($"Add appointment details {DateTime.Today}: {result}");
            return Ok(result);
        }

        [HttpPut("api/updateappontmentasync/{id}")]
        public async Task<IActionResult> UpdateAppointmentAsync([FromRoute] Guid id, [FromBody] AppointmentEntity appointmentEntity)
        {
            var result = await sender.Send(new UpdateAppointmentCommand(id, appointmentEntity));
            return Ok(result);
        }
    }
}
