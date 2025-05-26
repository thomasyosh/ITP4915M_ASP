using System.Net;
using Newtonsoft.Json.Linq;

namespace ITP4915M.AppLogic.Exceptions;

public class HasNoElementException : ICustException
{
    public HasNoElementException(string msg) : base(msg, HttpStatusCode.NotFound )
    {
    }
    public HasNoElementException(string msg, HttpStatusCode code) : base(msg, code )
    {
    }
    
    public override JObject GetHttpResult()
    {
        return IExceptionHttpResponseBuilder.Create(ReturnCode,  this.Message);
    }
}