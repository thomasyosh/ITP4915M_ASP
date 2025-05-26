namespace ITP4915M.AppLogic.Attribute
{
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Class)]
    public class TranslatableAttribute : System.Attribute
    {
        public TranslatableAttribute()
        {
        }
    }
}