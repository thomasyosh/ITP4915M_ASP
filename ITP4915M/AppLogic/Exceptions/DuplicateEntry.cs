using System.Net;
using Newtonsoft.Json.Linq;

namespace ITP4915M.AppLogic.Exceptions;

public class DuplicateEntryException :  ICustException
{
    public DuplicateEntryException(string msg) : base(msg, HttpStatusCode.BadRequest)
    {
    }
    
    public override JObject GetHttpResult()
    {
        return IExceptionHttpResponseBuilder.Create(ReturnCode, this.Message);
    }
}