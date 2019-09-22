using System;

namespace OZON.Test.Domain.Exceptions
{
    public class DomainException : Exception
    {
        public readonly Type EntityType;

        public DomainException(string message, Type entityType) : base(message) =>
            EntityType = entityType;
    }
}