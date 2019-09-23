using AutoMapper;
using OZON.Test.Domain.Entities;

namespace OZON.Test.Application.Infrastructure.Models
{
    public interface IDto<TDomainEntity>
    where TDomainEntity: IDomainEntity
    {
        int Id { get; set; }
        TDomainEntity GetMappedModel(IMapper mapper);
    }
}