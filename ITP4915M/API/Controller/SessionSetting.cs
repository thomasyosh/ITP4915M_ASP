using Microsoft.AspNetCore.Mvc;
using ITP4915M.Controllers;
using ITP4915M.Data;
using ITP4915M.Data.Entity;
using ITP4915M.AppLogic.Models;
using ITP4915M.AppLogic.Controllers;
using ITP4915M.AppLogic.Exceptions;

namespace ITP4915M.API.Controller
{
    [Route("api/[controller]")]
    public class SessionSetting : ControllerBase
    {   
        private readonly SessionSetttingController controller;
        public SessionSetting(DataContext db)
        {
            controller = new SessionSetttingController(db);
        }

        [HttpPost]
        public IActionResult Post( [FromBody] List<Data.Entity.SessionSetting> newSetting)
        {
            try
            {
                controller.UpdateSessionSetting(newSetting);
                return Ok();
            }
            catch (ICustException e)
            {
                return StatusCode(e.ReturnCode, e.GetHttpResult());
            }
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(controller.GetAll("en"));
        }
        
    }
}