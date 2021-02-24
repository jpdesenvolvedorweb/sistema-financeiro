using System;

namespace Model.Entity.Exceptions
{
    public class Exception : ApplicationException
    {
        public Exception(string message): base(message)
        {
        }
    }
}
