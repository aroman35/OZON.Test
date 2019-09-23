using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OZON.Test.Application.Infrastructure;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Application.Queries.GetTeamComposition
{
    public class GetTeamCompositionHandler
        : AbstractRequestHandler, IRequestHandler<GetTeamCompositionRequest, IEnumerable<ITeam>>
    {
        public GetTeamCompositionHandler(IApplicationContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<ITeam>> Handle(GetTeamCompositionRequest request, CancellationToken cancellationToken)
        {
            var teams = await _context
                .Teams
                .Include(x => x.Lead)
                .Include(x => x.Members)
                .Select(x => x.GetMappedModel(_mapper))
                .ToListAsync(cancellationToken);
            return teams;
        }
    }
}