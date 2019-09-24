using System.Collections.Generic;
using MediatR;

namespace OZON.Test.Application.Queries.EmployeesWithMaxBonuses
{
    public class EmployeesWithMaxBonusesRequest : IRequest<IDictionary<string, IEnumerable<string>>>
    {
    }
}