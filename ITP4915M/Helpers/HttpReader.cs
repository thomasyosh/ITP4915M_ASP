using ITP4915M.Helpers.LogHelper;
using System.Text;
using System.Collections;

namespace ITP4915M.Helpers;
public static class HttpReader
{
    public static string GetClientSocket(HttpContext context)
    {
        return $"{context.Connection.RemoteIpAddress}:{context.Connection.RemotePort.ToString()}";
    }

    public static string GetHeaderString(HttpRequest req)
    {
        var sbHeaders = new StringBuilder();
        foreach (var header in req.Headers)
            sbHeaders.Append($"{header.Key}: {header.Value}\n");

        return sbHeaders.ToString();
    }



    public static string GetURL(HttpRequest req, bool withMethod = false)
    {
        if (withMethod)
            return $"{req.Protocol} {req.Method} {req.Scheme}://{req.Host}{req.Path}{req.QueryString.Value}";
        return $"{req.Scheme}://{req.Host}{req.Path}{req.QueryString.Value}";
    }

    public static Dictionary<object, object> GetClaims(HttpRequest req)
    {
        var principal = Helpers.Secure.JwtToken.ReadToken(req.Headers["Authorization"].ToString().Split(' ')[1]);
        var claims = principal.Claims;
        var s = new Dictionary<object, object>();
        foreach (var c in claims)
        {
            s.Add(c.Type.Split('/')[c.Type.Split('/').Length - 1], c.Value);
        }

        return s;
    }
}