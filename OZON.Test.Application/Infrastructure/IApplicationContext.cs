using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OZON.Test.Application.Models;

namespace OZON.Test.Application.Infrastructure
{
    public interface IApplicationContext : IDisposable
    {
        DbSet<IDepartmentPm<IEmployeePm>> Departments { get; }
        DbSet<IEmployeePm> Employees { get; }
        DbSet<IBonusPm> Bonuses { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}