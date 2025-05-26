using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using ITP4915M.AppLogic.Exceptions;
namespace ITP4915M.API.Controller
{
    [Route("api/[controller]")]
    public class DefectItem : ControllerBase
    {
        private AppLogic.Controllers.DefectItemController controller;
        public DefectItem(Data.DataContext db) 
        {
            controller = new AppLogic.Controllers.DefectItemController(db);
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Add([FromBody] Data.Dto.DefectItemDto record)
        {
            try
            {
                controller.AddRefectItemRecord(User.Identity.Name, record);
                return Ok();
            }
            catch (ICustException e)
            {
                return StatusCode(e.ReturnCode, e.GetHttpResult());
            }
        }

        [HttpGet]
        [Authorize]
        public IActionResult Get([FromHeader] string Language)
        {
            try
            {
                return Ok(controller.GetAll(User.Identity.Name , Language));
            }
            catch (ICustException e)
            {
                return StatusCode(e.ReturnCode, e.GetHttpResult());
            }
        }        

        [HttpPut]
        [Authorize]
        public IActionResult UpdateDefectItemStatus([FromBody] Data.Dto.DefectItemUpdateStatusDto status)
        {
            try
            {
                controller.UpdateDefectItemStatus(User.Identity.Name ,status);
                return Ok();
            }
            catch (ICustException e)
            {
                return StatusCode(e.ReturnCode, e.GetHttpResult());
            }
        }
    }
}