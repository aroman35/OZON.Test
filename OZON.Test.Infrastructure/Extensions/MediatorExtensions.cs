using System.Reflection;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using OZON.Test.Application.Queries;
using OZON.Test.Infrastructure.Mediator;

namespace OZON.Test.Infrastructure.Extensions
{
    public static class MediatorExtensions
    {
        public static IServiceCollection AddMediatorServices(this IServiceCollection services) =>
            services.AddMediatR(typeof(AbstractRequestHandler).GetTypeInfo().Assembly)
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestPerformanceTrack<,>))
                .AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));
        
    }
}