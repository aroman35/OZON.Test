using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using OZON.Test.Application.Infrastructure;
using OZON.Test.Application.Models;
using OZON.Test.Domain.Extensions;

namespace OZON.Test.Application.Queries.EmployeesWithMaxBonuses
{
    public class EmployeesWithMaxBonusesHandler
        : AbstractRequestHandler, IRequestHandler<EmployeesWithMaxBonusesRequest, IDictionary<string, IEnumerable<string>>>
    {
        public EmployeesWithMaxBonusesHandler(IApplicationContext context, IMapper mapper) : base(context, mapper)
        {
            
        }

        public async Task<IDictionary<string, IEnumerable<string>>> Handle(EmployeesWithMaxBonusesRequest request,
            CancellationToken cancellationToken)
        {
            var fiscalYearStartDate = DateTime.Parse($"1/1/{DateTime.Now.Year.ToString()}", new CultureInfo("en-US"));
            
            Func<IEnumerable<BonusDto>, decimal> getTotalByYear = bonuses =>
                bonuses.Where(bonus => bonus.BonusDate > fiscalYearStartDate).Sum(bonus => bonus.BonusAmount);

            var result = await _context.Employees
                .Include(x => x.Bonuses)
                .GroupBy(x => x.Department)
                .ToDictionaryAsync(x => x.Key.GetDescription(),
                    x =>
                    {
                        var mvpEmployee = x.OrderByDescending(e => getTotalByYear(e.Bonuses)).First();
                        var maxBonusCount = getTotalByYear(mvpEmployee.Bonuses);

                        return x.Where(e => getTotalByYear(e.Bonuses) == maxBonusCount)
                            .Select(e => e.GetMappedModel(_mapper).ToString());
                    }, cancellationToken);

            return result;
        }
    }
}