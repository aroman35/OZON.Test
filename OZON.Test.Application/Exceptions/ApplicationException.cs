using System;

namespace OZON.Test.Application.Exceptions
{
    public class ApplicationException : Exception
    {
        public ApplicationException(string message) : base(message)
        {
            
        }
    }
}