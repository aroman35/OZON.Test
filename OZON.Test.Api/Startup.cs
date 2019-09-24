using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using OZON.Test.Api.Settings;
using OZON.Test.Application.Commands;
using OZON.Test.Application.Commands.SeedTestData;
using OZON.Test.Application.Infrastructure;
using OZON.Test.Infrastructure.Extensions;
using OZON.Test.Persistence;
using Swashbuckle.AspNetCore.Swagger;

namespace OZON.Test.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddMapperServices()
                .AddMediatorServices()
                .AddEntityFrameworkNpgsql()
                .AddDbContext<IApplicationContext, ApplicationContext>(opts =>
                {
                    opts.UseNpgsql(Configuration.GetConnectionString("ApplicationDb"));
                    opts.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
                })
                .AddTransient<TestDataGenerator>()
                .AddMvc()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_2)
                .AddJsonOptions(opts =>
                    opts.SerializerSettings.ContractResolver = new IgnoreEmptyEnumerablesResolver());
            
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info
                {
                    Version = "v1",
                    Title = "My API",
                    Description = "My First ASP.NET Core Web API",
                    TermsOfService = "None",
                    Contact = new Contact() { Name = "Talking Dotnet", Email = "contact@talkingdotnet.com", Url = "www.talkingdotnet.com" }
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseMvcWithDefaultRoute();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}