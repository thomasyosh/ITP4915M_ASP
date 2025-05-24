using System.Net;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace ITP4915M.AppLogic.Exceptions;


public class BadArgException : ICustException
{
    public BadArgException(string msg ):base(msg, HttpStatusCode.BadRequest)
    {
    }

    public override JObject GetHttpResult()
    {
        return IExceptionHttpResponseBuilder.Create( ReturnCode, this.Message);
    }
    



}