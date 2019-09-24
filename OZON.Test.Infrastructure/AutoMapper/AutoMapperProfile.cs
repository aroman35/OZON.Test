using System.Linq;
using AutoMapper;
using OZON.Test.Application.Infrastructure.Models;
using OZON.Test.Domain.Entities;
using OZON.Test.Domain.Entities.Abstractions;

namespace OZON.Test.Infrastructure.AutoMapper
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<IEmployeeDto, IEmployee>()
                .ConstructUsing((x, y) =>
                    new Employee(x.FirstName, x.LastName, x.Salary, x.JoiningDate, x.Department, y.Mapper.Map<IEmployee>(x.ReportTo)));
            
            CreateMap<IBonusDto, IBonus>()
                .ConstructUsing((model, ctx) =>
                    new Bonus(ctx.Mapper.Map<IEmployee>(model.Employee), model.BonusDate, model.BonusAmount));
        }
    }
}