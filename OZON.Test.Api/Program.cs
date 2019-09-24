using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OZON.Test.Application.Commands;
using OZON.Test.Application.Commands.SeedTestData;
using OZON.Test.Application.Infrastructure;
using OZON.Test.Persistence;

namespace OZON.Test.Api
{
    public class Program
    {
        public static void Main(string[] args) =>
            MainAsync(args).GetAwaiter().GetResult();

        public static async Task MainAsync(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();
            using (var scope = host.Services.CreateScope())
            {
                var mediator = scope.ServiceProvider.GetRequiredService<IMediator>();
                await mediator.Send(new SeedTestDataCommand(10000));
            }

            await host.RunAsync();
        }
        
        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseKestrel(opts => opts.ListenLocalhost(5000))
                .UseStartup<Startup>();
    }
}