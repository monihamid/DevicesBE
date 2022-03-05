using System;
using System.Reflection;
using Data.Models;
using FluentMigrator.Runner;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using DevicesBE.Data.Migrations;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.AspNetCore.Builder;

namespace DevicesBE
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
            services.AddControllers();
            services
            .AddLogging(c => c.AddFluentMigratorConsole())
            .AddFluentMigratorCore()
            .ConfigureRunner(c => c
            .AddSqlServer()
            .WithGlobalConnectionString(Configuration["Connection"])  //  "Server=localhost;Database=Demo;User Id=sa;Password=MSsql@123")
            .ScanIn(Assembly.GetExecutingAssembly()).For.All());
            services.AddDbContext<CoreDbContext> (
                ob => ob.UseSqlServer(Configuration["Connection"],
                sso => sso.MigrationsAssembly(Assembly.GetExecutingAssembly().GetName().Name)
                )); 
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "DevicesBE", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, 
        IWebHostEnvironment env,
        IServiceProvider serviceProvider)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "DevicesBE v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            serviceProvider.GetService<CoreDbContext>()
            .Database.GetService<IMigrator>()
            .Migrate(Configuration.GetValue<string>("Migration"));
            Database.CreateDatabase(Configuration["ConnectionString"], "DeviceDB");
            app.CreateTables();
        }
    }
}
