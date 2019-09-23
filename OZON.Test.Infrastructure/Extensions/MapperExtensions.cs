using System.Reflection;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using OZON.Test.Infrastructure.AutoMapper;

namespace OZON.Test.Infrastructure.Extensions
{
    public static class MapperExtensions
    {
        public static IServiceCollection AddMapperServices(this IServiceCollection services) =>
            services.AddAutoMapper(typeof(AutoMapperProfile));
    }
}