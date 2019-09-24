using System.Collections.Generic;
using MediatR;

namespace OZON.Test.Application.Queries.GetLeads
{
    public class GetLeadsRequest : IRequest<IDictionary<int, string>>
    {
    }
}