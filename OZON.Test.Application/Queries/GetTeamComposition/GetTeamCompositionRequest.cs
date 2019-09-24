using System.Collections.Generic;
using MediatR;

namespace OZON.Test.Application.Queries.GetTeamComposition
{
    public class GetTeamCompositionRequest : IRequest<IEnumerable<EmployeeTeamModel>>
    {
    }
}