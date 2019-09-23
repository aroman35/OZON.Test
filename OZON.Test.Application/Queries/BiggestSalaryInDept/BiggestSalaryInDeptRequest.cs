using System.Collections.Generic;
using MediatR;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Queries.BiggestSalaryInDept
{
    public class BiggestSalaryInDeptRequest : IRequest<IDictionary<string, IEmployee>>
    {
    }
}