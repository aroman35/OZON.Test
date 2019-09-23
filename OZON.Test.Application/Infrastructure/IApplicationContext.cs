using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using OZON.Test.Application.Models;

namespace OZON.Test.Application.Infrastructure
{
    public interface IApplicationContext : IDisposable
    {
        DbSet<DepartmentPm> Departments { get; set; }
        DbSet<EmployeePm> Employees { get; set; }
        DbSet<BonusPm> Bonuses { get; set; }
        DbSet<DreamTeamPm> Teams { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DatabaseFacade Database { get; }
        void DetachAllEntities();
    }
}