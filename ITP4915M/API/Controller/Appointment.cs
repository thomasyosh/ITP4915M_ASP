using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ITP4915M.AppLogic.Exceptions;

namespace ITP4915M.API.Controller
{
    [Route("api/[controller]")]
    // [Authorize]
    public class _Appointment : ControllerBase
    {
        private readonly ITP4915M.AppLogic.Controllers.AppointmentController ac;

        public _Appointment(Data.DataContext db)
        {
            ac = new ITP4915M.AppLogic.Controllers.AppointmentController(db);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAppointment(int day , int month, [FromHeader] string Language = "en")
        {
            if (day == 0 || month == 0)
                return Ok(await ac.GetAllAppointment(User.Identity.Name, Language));
            else 
                return Ok(await ac.GetAppointment(User.Identity.Name , day, month, Language));
        }


        [HttpPut("assign/team/{id}")]
        public async Task<IActionResult> AssignTeam(string id , [FromBody] string TeamId)
        {
            try 
            {
                ac.AssignTeam(id , TeamId);
                return Ok();
            }catch(ICustException e)
            {
                return StatusCode(e.ReturnCode , e.GetHttpResult());
            }

        }
    }
}