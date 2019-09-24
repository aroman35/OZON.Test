using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OZON.Test.Application.Infrastructure;

namespace OZON.Test.Application.Queries.GetTeamComposition
{
    public class GetTeamCompositionHandler
        : AbstractRequestHandler, IRequestHandler<GetTeamCompositionRequest, IEnumerable<EmployeeTeamModel>>
    {
        public GetTeamCompositionHandler(IApplicationContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IEnumerable<EmployeeTeamModel>> Handle(GetTeamCompositionRequest request, CancellationToken cancellationToken)
        {
            var result = await _context.Employees.Include(x => x.ReportTo).Where(x => x.ReportTo != null)
                .Select(x => new EmployeeTeamModel(x)).ToListAsync(cancellationToken);
            
            return result.OrderByDescending(x => x.Team.Count());
        }
    }
}