using System.Net;
using Newtonsoft.Json.Linq;


namespace ITP4915M.AppLogic.Exceptions;

public static class IExceptionHttpResponseBuilder
{
    public static JObject Create( int code, string msg)
    {
        string tmp = $"{{\"status\": {code},\"message\":\"{msg}\"}}";
        return JObject.Parse(tmp);
    }
    
}