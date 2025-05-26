﻿using Microsoft.AspNetCore.Mvc;
using ITP4915M.Controllers;
using ITP4915M.AppLogic.Exceptions;
using ITP4915M.Data;
using ITP4915M.Data.Dto;
using Newtonsoft.Json.Linq;
using ITP4915M.AppLogic.Models;
using Microsoft.AspNetCore.Authorization;
using ITP4915M.AppLogic.Models;
using ITP4915M.AppLogic.Controllers;
using ITP4915M.Helpers.Extension;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ITP4915M.API.Controllers;

[ApiController]
[Route("api/users")]
public class UsersController : ControllerBase
{
    private readonly UserController controller;
    public UsersController(DataContext data)
    {
        controller = new UserController(data);
    }
    
    [HttpGet("index")]
    public JObject Index()
    {
        return JObject.FromObject(new AccountDto());
    }

    // GET: api/<Users>?limit=01
    [HttpGet]
    public IActionResult GetWithLimit(int limit = 0 )
    {
        if (limit == 0)
            return Ok(controller.GetAllUsers());

        try
        {
            return Ok(controller.GetUsers(limit));
        }
        catch (BadArgException e)
        {
            return StatusCode(e.ReturnCode , e.GetHttpResult());
        }
        
    }

    [HttpGet("sql")]
    public async Task<IActionResult> GetAcc(string querystring)
    {
        try
        {
            var o = await controller.GetUsersByConditionString(querystring);
            return Ok(o);
        }
        catch (HasNoElementException e)
        {
            return StatusCode(e.ReturnCode, e.GetHttpResult());
        }
    }

    // GET api/values/5
    [HttpGet("{id}")]
    public async Task<IActionResult> Get(string id)
    {
        try
        {
            return Ok((await controller.GetUserByIDAsync(id)).TryCopy<AccountOutDto>());
        }catch(ICustException e)
        {
            return StatusCode(e.ReturnCode, e.GetHttpResult());
        }
        
    }

    // POST api/values
    [HttpPost]
    public async Task<IActionResult> PostAsync([FromBody] AccountDto value)
    {
        try
        {
            await controller.CreateUser(value);
        }
        catch (ICustException e)
        {
            return StatusCode(e.ReturnCode, e.GetHttpResult());
        }
        
        return Ok();
    }

    // PUT api/values/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] List<UpdateObjectModel> value)
    {
        try
        {
            var o = await controller.UpdateUserAsync(id, value);
            return Ok(o);
        }catch (ICustException e)
        {
            return StatusCode(e.ReturnCode, e.GetHttpResult());
        }

    }

    [HttpPut]
    public async Task<IActionResult> UpdateRange(string condtion , [FromBody] List<UpdateObjectModel> value)
    {
        try
        {
            var o = await controller.UpdateRangeUserAsync(condtion, value);
            return Ok(o);
        }catch(ICustException e)
        {
            return StatusCode(e.ReturnCode, e.GetHttpResult());
        }

    }

    // DELETE api/values/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        try
        {
            await controller.DeleteUserAsync(id);
            return Ok(id);
        }
        catch (ICustException e)
        {
            return StatusCode(e.ReturnCode, e.GetHttpResult());
        }
    }

    [HttpPost("lock")]
    public async Task<IActionResult> Lock([FromBody] LockUserModel value)
    {
        try
        {
            await controller.LockUserAsync(value.id , (int) value.lockDay);
            return Ok("User Locked until " + DateTime.Now.AddDays(value.lockDay) + " days");
        }
        catch (ICustException e)
        {
            return StatusCode(e.ReturnCode, e.GetHttpResult());
        }
    }
    
    [HttpPost("unlock")]
    public async Task<IActionResult> Unlock([FromBody] UnlockUserModel value)
    {
        try
        {
            await controller.UnlockUserAsync(value.id);
            return Ok(value.id);
        }
        catch (ICustException e)
        {
            return StatusCode(e.ReturnCode, e.GetHttpResult());
        }
    }

    [HttpGet("icon")]
    [Authorize]
    public async Task<IActionResult> GetIcon()
    {
        try
        {
            Tuple<byte[] , string> icon = controller.GetUserIcon(User.Identity.Name );
            return File(icon.Item1 , $"image/{icon.Item2}");
        }
        catch (ICustException e)
        {
            return StatusCode(e.ReturnCode, e.GetHttpResult());
        }
    }

    [HttpGet("{id}/icon")]
    public async Task<IActionResult> GetUserIconByID (string id)
    {
        try
        {
            Tuple <byte[] , string> icon = controller.GetUserIconByID(id);
            return File(icon.Item1 , $"image/{icon.Item2}");
        }
        catch (ICustException e)
        {
            return StatusCode(e.ReturnCode, e.GetHttpResult());
        }
    }

    [HttpPost("myicon")]
    [Authorize]
    public async Task<IActionResult> UpdateUserIcon([FromBody] string base64Image)
    {
        try
        {
            await controller.UpdateMyUserIcon(User.Identity.Name , base64Image);
            return Ok();
        }
        catch (ICustException e)
        {
            return StatusCode(e.ReturnCode, e.GetHttpResult());
        }
    }

    [HttpPost("{id}/icon")]
    public async Task<IActionResult> UpdateUserIcon(string id , [FromBody] string base64Image)
    {
        try
        {
            await controller.UpdateUserIcon(id, base64Image);
            return Ok();
        }
        catch (ICustException e)
        {
            return StatusCode(e.ReturnCode, e.GetHttpResult());
        }
    }

}