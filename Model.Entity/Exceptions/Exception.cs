using System;

namespace Model.Entity.Exceptions
{
    public class ExceptionX : ApplicationException
    {
        public ExceptionX(string message): base(message)
        {
        }
    }
}
