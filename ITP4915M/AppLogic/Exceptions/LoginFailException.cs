using Newtonsoft.Json.Linq;
using System.Net;

namespace ITP4915M.AppLogic.Exceptions;

public class LoginFailException : ICustException
{
    public LoginFailException(string msg) : base(msg, HttpStatusCode.Unauthorized)
    {
    }
    public override JObject GetHttpResult()
    {
        return IExceptionHttpResponseBuilder.Create(ReturnCode, this.Message);
    }
}