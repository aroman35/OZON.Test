using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using OZON.Test.Application.Infrastructure;
using OZON.Test.Application.Models;
using OZON.Test.Application.Queries;

namespace OZON.Test.Application.Commands.SetBonuses
{
    public class SetBonusesHandler : AbstractRequestHandler, IRequestHandler<SetBonusesRequest, Unit>
    {
        private readonly ILogger<SetBonusesHandler> _logger;

        public SetBonusesHandler(IApplicationContext context, IMapper mapper, ILogger<SetBonusesHandler> logger) : base(
            context, mapper) =>
            _logger = logger;

        public async Task<Unit> Handle(SetBonusesRequest request, CancellationToken cancellationToken)
        {
            var teamLead = (await _context.Employees
                                .Include(x => x.Bonuses)
                                .Include(x => x.ReportedEmployees)
                                .ThenInclude(x => x.Bonuses)
                                .SingleOrDefaultAsync(x => x.Id == request.LeadId, cancellationToken))
                            ?? throw new ApplicationException($"There is no employee with id {request.LeadId}");
            
            if(!teamLead.ReportedEmployees.Any())
                throw new ApplicationException($"{teamLead.GetMappedModel(_mapper)} is not lead");

            var fullTeam = GetAllTeamMembers(teamLead).ToList();
            
            var luckyMembers = fullTeam
                .Where(x =>
                    !x.Bonuses.Any() ||
                    x.Bonuses
                        .OrderByDescending(b => b.BonusDate)
                        .First()
                        .BonusDate.Year < request.Year)
                .ToList();
            
            var random = new Random();
            
            luckyMembers.ForEach(x =>
            {
                var bonus = new BonusDto
                {
                    BonusAmount = random.Next(10, 50) * 1000M,
                    BonusDate = DateTime.Now,
                    Employee = x
                };
                x.Bonuses.Add(bonus);
            });

            _context.Employees.UpdateRange(luckyMembers);
            var affectedEntries = await _context.SaveChangesAsync(cancellationToken);
            _logger.Log(LogLevel.Debug, $"Affected {affectedEntries}");
            
            return Unit.Value;
        }

        private IEnumerable<EmployeeDto> GetAllTeamMembers(EmployeeDto lead)
        {
            var stack = new Stack<IEnumerator<EmployeeDto>>();
            stack.Push(lead.ReportedEmployees.GetEnumerator());

            yield return lead;

            while (stack.Any())
            {
                var node = stack.Pop();
                while (node.MoveNext())
                {
                    yield return node.Current;
                    if (node.Current.ReportedEmployees.Any())
                    {
                        stack.Push(node);
                        stack.Push(node.Current.ReportedEmployees.GetEnumerator());
                        break;
                    }
                }
            }
        }
    }
}