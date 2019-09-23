using System.Collections;
using System.Collections.Generic;
using MediatR;
using OZON.Test.Domain.Entities;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Queries.EmployeesWithMaxBonuses
{
    public class EmployeesWithMaxBonusesRequest : IRequest<IDictionary<IDepartment, Dictionary<IEmployee, decimal>>>
    {
    }
}