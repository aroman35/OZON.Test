using System.Collections.Generic;
using MediatR;

namespace OZON.Test.Application.Queries.BiggestSalaryInDept
{
    public class BiggestSalaryInDeptRequest : IRequest<IDictionary<string, IEnumerable<string>>>
    {
    }
}