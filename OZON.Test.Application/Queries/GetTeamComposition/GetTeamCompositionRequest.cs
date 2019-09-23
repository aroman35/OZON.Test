using System.Collections.Generic;
using MediatR;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Queries.GetTeamComposition
{
    public class GetTeamCompositionRequest : IRequest<IEnumerable<ITeam>>
    {
    }
}