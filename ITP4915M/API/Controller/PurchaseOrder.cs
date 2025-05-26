using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.AspNetCore.Authorization;
using ITP4915M.AppLogic.Exceptions;

namespace ITP4915M.API.Controller
{
    [Route("api/purchase/order")]
    public class Purchase_PurchaseOrder : ControllerBase
    {
        private AppLogic.Controllers.PurchaseOrderController controller;

        public Purchase_PurchaseOrder(Data.DataContext db)
        {
            controller = new AppLogic.Controllers.PurchaseOrderController(db);
        }


        [HttpGet]
        [Authorize]
        public IActionResult GetAll([FromHeader] string Language)
        {
            try
            {
                return Ok(controller.GetAll(User.Identity.Name , Language));
            }
            catch (ICustException e)
            {
                return StatusCode(e.ReturnCode , e.GetHttpResult());
            }
        }


        [HttpGet("{id}")]
        [Authorize]
        public IActionResult GetById(string id, [FromHeader] string Language)
        {
            try 
            {
                return Ok(controller.GetById(User.Identity.Name,id , Language));
            }catch(ICustException e)
            {
                return StatusCode(e.ReturnCode , e.GetHttpResult());
            }
        }

        [HttpPost]
        [Authorize]
        public IActionResult Post([FromBody] Data.Dto.PurchaseOrderInDto dto)
        {
            try
            {
                // print the raw request body
                controller.CreateEntry(dto, User.Identity.Name);
                return Ok();
            }
            catch (ICustException e)
            {
                return StatusCode(e.ReturnCode , e.GetHttpResult());
            }
        }
        
        [HttpDelete]
        public IActionResult Delete([FromHeader] string id)
        {
            try
            {
                controller.Delete(id);
                return Ok();
            }
            catch (ICustException e)
            {
                return StatusCode(e.ReturnCode , e.GetHttpResult());
            }
        }

        [HttpPut]
        [Authorize]
        public IActionResult Update([FromBody] Data.Dto.PurchaseOrderUpdateDto Content)
        {
            // the user will pass the entire object to the server (same with the post method, with id)
            
            try 
            {
                controller.Update(User.Identity.Name , Content);
                return Ok();

            }catch( ICustException e)
            {
                return StatusCode( e.ReturnCode , e.GetHttpResult());
            }

        }  

        [HttpPut("status/{id}")]
        [Authorize]
        public IActionResult UpdateOrderStatus(string id , [FromBody] int status)
        {
            try
            {
                controller.UpdateStatus(User.Identity.Name , id , status);
                return Ok();
            }
            catch (ICustException e)
            {
                return StatusCode(e.ReturnCode , e.GetHttpResult());
            }
        }
    }
}