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
            CreateMap<IDepartmentPm, IDepartment>()
                .ConstructUsing(x => new Department(x.DepartmentName));
            
            CreateMap<IEmployeePm, IEmployee>()
                .ConstructUsing((x, y) =>
                {
                    var dept = y.Mapper.Map<IDepartment>(x.Department);
                        return new Employee(x.FirstName, x.LastName, x.Salary, x.JoiningDate, dept);
                    });
            
            CreateMap<IBonusPm, IBonus>()
                .ConstructUsing((model, ctx) =>
                    new Bonus(ctx.Mapper.Map<IEmployee>(model.Employee), model.BonusDate, model.BonusAmount));
            
            CreateMap<ITeamPm, ITeam>()
                .ConstructUsing((model, ctx) =>
                    new DreamTeam(ctx.Mapper.Map<IEmployee>(model.Lead), model.Members.Select(x => ctx.Mapper.Map<IEmployee>(x))));
        }
    }
}