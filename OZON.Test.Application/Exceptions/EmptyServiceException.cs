using System;

namespace OZON.Test.Application.Exceptions
{
    public class EmptyServiceException : ApplicationException
    {
        public readonly Type ServiceType;

        public EmptyServiceException(Type serviceType)
            : base($"Couldn't resolve {serviceType}") =>
            ServiceType = serviceType;
    }
}