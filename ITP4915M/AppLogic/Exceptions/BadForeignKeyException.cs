namespace ITP4915M.AppLogic.Exceptions
{
    public class BadForeignKeyException : BadArgException
    {
        public BadForeignKeyException(string msg ):base(msg)
        {
        }

        public override JObject GetHttpResult()
        {
            return IExceptionHttpResponseBuilder.Create( ReturnCode, this.Message);
        }
    }
}