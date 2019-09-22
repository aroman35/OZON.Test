using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OZON.Test.Application.Infrastructure.Models;

namespace OZON.Test.Application.Infrastructure
{
    public interface IApplicationContext : IDisposable
    {
        DbSet<IDepartmentPm> Departments { get; }
        DbSet<IEmployeePm> Employees { get; }
        DbSet<IBonusPm> Bonuses { get; }
        DbSet<ITeamPm> Teams { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}