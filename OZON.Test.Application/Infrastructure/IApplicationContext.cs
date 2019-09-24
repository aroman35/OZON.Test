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
        DbSet<EmployeeDto> Employees { get; set; }
        DbSet<BonusDto> Bonuses { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        DatabaseFacade Database { get; }
        void DetachAllEntities();
    }
}