using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OZON.Test.Application.Infrastructure;
using OZON.Test.Application.Models;
using OZON.Test.Application.Queries;

namespace OZON.Test.Application.Commands.SeedTestData
{
    public class SeedTestDataHandler : AbstractRequestHandler, IRequestHandler<SeedTestDataCommand>
    {
        private readonly TestDataGenerator _generator;

        public SeedTestDataHandler(IApplicationContext context, TestDataGenerator generator) : base(context) =>
            _generator = generator;

        public async Task<Unit> Handle(SeedTestDataCommand request, CancellationToken cancellationToken)
        {
            if (await _context.Database.EnsureCreatedAsync(cancellationToken))
                await SeedAll(request.EmployeeCount, cancellationToken);
            
            return Unit.Value;
        }

        private async Task SeedAll(int employeeCount, CancellationToken cancellationToken)
        {
            var employees = await SeedEmployees(employeeCount, cancellationToken);
            await SeedBonuses(employees.ToList(), cancellationToken);
        }
        private async Task<IEnumerable<EmployeeDto>> SeedEmployees(int employeeCount, CancellationToken cancellationToken)
        {
            var employees = _generator.GetTestEmployees(employeeCount);
            
            await _context.Employees.AddRangeAsync(employees, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return employees;
        }
        private async Task SeedBonuses(List<EmployeeDto> employees, CancellationToken cancellationToken)
        {
            var bonuses = _generator.GetTestBonuses(employees);
            
            await _context.Bonuses.AddRangeAsync(bonuses, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
    }
}