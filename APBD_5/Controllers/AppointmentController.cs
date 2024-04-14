using APBD_5.Classes;
using Microsoft.AspNetCore.Mvc;

namespace APBD_5.Controllers;

[ApiController]
[Route("appointment")]
public class AppointmentController : ControllerBase
{
    private IMockDatabase _mockDatabase;

    public AppointmentController(IMockDatabase mockDatabase)
    {
        _mockDatabase = mockDatabase;
    }

    [HttpGet("{id}")]
    public IActionResult GetAppointmentsRelatedToAnimal(int id)
    {
        var appointments = _mockDatabase.GetAppointmentsRelatedToAnimal(id);
        if (appointments.Count == 0)
        {
            return NotFound();
        }

        return Ok(appointments);
    }

    [HttpPost]
    public IActionResult Add(Appointment appointment)
    {
        _mockDatabase.AddAppointment(appointment);
        return Created($"$appointments/{appointment.Id}", appointment);
    }
}