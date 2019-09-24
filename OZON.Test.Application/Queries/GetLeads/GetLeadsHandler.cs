using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OZON.Test.Application.Infrastructure;

namespace OZON.Test.Application.Queries.GetLeads
{
    public class GetLeadsHandler : AbstractRequestHandler, IRequestHandler<GetLeadsRequest, IDictionary<int, string>>
    {
        public GetLeadsHandler(IApplicationContext context, IMapper mapper) : base(context, mapper)
        {
        }

        public async Task<IDictionary<int, string>> Handle(GetLeadsRequest request, CancellationToken cancellationToken)
        {
            var leads = await _context.Employees.Where(x => x.ReportedEmployees.Any())
                .ToDictionaryAsync(x => x.Id, x => x.GetMappedModel(_mapper).ToString(), cancellationToken);
            
            return leads;
        }
    }
}