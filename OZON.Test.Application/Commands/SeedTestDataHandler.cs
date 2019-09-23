using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using OZON.Test.Application.Infrastructure;
using OZON.Test.Application.Models;
using OZON.Test.Application.Queries;

namespace OZON.Test.Application.Commands
{
    public class SeedTestDataHandler : AbstractRequestHandler, IRequestHandler<SeedTestDataCommand>
    {
        public SeedTestDataHandler(IApplicationContext context) : base(context)
        {
        }

        public async Task<Unit> Handle(SeedTestDataCommand request, CancellationToken cancellationToken)
        {
            if (await _context.Database.EnsureCreatedAsync(cancellationToken))
                await SeedAll(cancellationToken);
            
            return Unit.Value;
        }

        private async Task SeedAll(CancellationToken cancellationToken)
        {
            await SeedDepartments(cancellationToken);
            var employees = await SeedEmployees(cancellationToken);
            await SeedTeams(employees, cancellationToken);
            await SeedBonuses(employees, cancellationToken);
        }
        private async Task SeedDepartments(CancellationToken cancellationToken)
        {
            var departments = new DepartmentPm[]
            {
                new DepartmentPm {Id = 1, DepartmentName = "It"},
                new DepartmentPm {Id = 2, DepartmentName = "HR"},
                new DepartmentPm {Id = 3, DepartmentName = "Finance"},
                new DepartmentPm {Id = 4, DepartmentName = "Logistic"},
                new DepartmentPm {Id = 5, DepartmentName = "Manufactury"},
                new DepartmentPm {Id = 6, DepartmentName = "Another dept 1"},
                new DepartmentPm {Id = 7, DepartmentName = "Another dept 2"},
                new DepartmentPm {Id = 8, DepartmentName = "Another dept 3"},
                new DepartmentPm {Id = 9, DepartmentName = "Another dept 4"},
                new DepartmentPm {Id = 10, DepartmentName = "Another dept 5"},
            };

            await _context.Departments.AddRangeAsync(departments, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        private async Task<IEnumerable<EmployeePm>> SeedEmployees(CancellationToken cancellationToken)
        {
            var employees = new List<EmployeePm>();

            for (var i = 0; i < 10000; i++)
            {
                var rand = new Random();
                var emp = new EmployeePm
                {
                    DepartmentId = rand.Next(1, 10),
                    FirstName = $"Test_{i:0000}",
                    LastName = $"Test_{i:0000}",
                    Salary = rand.Next(26, 100) * 1000M,
                    JoiningDate = DateTime.Now.AddDays(rand.Next(90, 730) * -1)
                };
                employees.Add(emp);
            }
            await _context.Employees.AddRangeAsync(employees, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
            return employees;
        }
        private async Task SeedTeams(IEnumerable<EmployeePm> employees, CancellationToken cancellationToken)
        {
            var teams = new List<DreamTeamPm>();
            
            for (var i = 0; i < 100; i++)
            {
                var teamMembers = employees
                    .Skip(i * 100)
                    .Take(100);

                teams.Add(new DreamTeamPm
                {
                    Lead = teamMembers.OrderByDescending(x => x.Salary).First(),
                    Members = teamMembers.ToList()
                });
            }
            
            
            await _context.Teams.AddRangeAsync(teams, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);
        }
        
        private async Task SeedBonuses(IEnumerable<EmployeePm> employees, CancellationToken cancellationToken)
        {
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
        }
    }
}