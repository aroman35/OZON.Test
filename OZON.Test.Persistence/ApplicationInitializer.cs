using System;
using OZON.Test.Application.Infrastructure;
using OZON.Test.Application.Models;
using OZON.Test.Domain.Entities;

namespace OZON.Test.Persistence
{
    public class ApplicationInitializer
    {
        public static void Initialize(IApplicationContext context)
        {
            var initializer = new ApplicationInitializer();
            initializer.SeedEverything(context);
        }

        public void SeedEverything(IApplicationContext context)
        {
            SeedDepartments(context);
            SeedEmployees(context);
            SeedBonuses(context);
            SeedTeams(context);
        }

        public void SeedDepartments(IApplicationContext context)
        {
            var departments = new[]
            {
                new DepartmentPm {Id = 1, DepartmentName = "IT"},
                new DepartmentPm {Id = 2, DepartmentName = "HR"}
            };
            
            context.Departments.AddRange(departments);
            context.SaveChangesAsync(default).GetAwaiter().GetResult();
        }
        
        public void SeedEmployees(IApplicationContext context)
        {
            var employees = new[]
            {
                new EmployeePm
                {
                    Id = 1, DepartmentId = 1, FirstName = "User_1", LastName = "User_1_LN", Salary = 90000M,
                    JoiningDate = DateTime.Now.AddDays(-180),
                    Bonuses = new[]
                    {
                        new BonusPm
                        {
                            Id = 1, EmployeeId = 1, BonusDate = DateTime.Now.AddDays(-90), BonusAmount = 10000M
                        }
                    }
                }
            };
            context.Employees.AddRange(employees);
            context.SaveChangesAsync(default).GetAwaiter().GetResult();
        }
        
        public void SeedBonuses(IApplicationContext context)
        {
            
        }
        
        public void SeedTeams(IApplicationContext context)
        {
            
        }
    }
}