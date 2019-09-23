using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OZON.Test.Application.Infrastructure;
using OZON.Test.Application.Models;
using OZON.Test.Application.Queries;

namespace OZON.Test.Application.Commands
{
    public class SetRandomBonusesHandler : AbstractRequestHandler, IRequestHandler<SetRandomBonuses>
    {
        public SetRandomBonusesHandler(IApplicationContext context) : base(context)
        {
        }

        public async Task<Unit> Handle(SetRandomBonuses request, CancellationToken cancellationToken)
        {
            var employees = await _context.Employees.ToListAsync(cancellationToken);
            var rand = new Random();

            var bonuses = new HashSet<BonusPm>();
            var happyEmployees = new HashSet<EmployeePm>();
            
            
            for (var i = 0; i < 3000; i++)
            {
                try
                {
                    var empl = employees.Skip(rand.Next(9999)).First();
                    happyEmployees.Add(empl);
                    bonuses.Add( new BonusPm
                    {
                        Employee = empl,
                        BonusDate = DateTime.Now.AddDays(rand.Next(10, 365) * -1),
                        BonusAmount = rand.Next(1, 10) * 1000M
                    });
                }
                catch
                {
                    continue;
                }
            }
            
            await _context.Bonuses.AddRangeAsync(bonuses, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            
            return Unit.Value;
        }
    }
}