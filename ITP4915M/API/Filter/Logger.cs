using System.Net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using ITP4915M.Helpers;
using ITP4915M.Helpers.LogHelper;

namespace ITP4915M.API.Filters;
public class LogAccessAuthAttribute : Attribute , IAuthorizationFilter 
{
    public void OnAuthorization(AuthorizationFilterContext context)
    {
        ConsoleLogger.Debug("S");
    }
}