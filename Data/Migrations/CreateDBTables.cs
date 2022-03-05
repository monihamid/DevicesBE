using FluentMigrator.Runner;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace DevicesBE.Data.Migrations
{
    public static class CreateDBTables
    {
        public static IApplicationBuilder CreateTables(this IApplicationBuilder app)
        {
            using var scope = app.ApplicationServices.CreateScope();
            var runner = scope.ServiceProvider.GetService<IMigrationRunner>();
            runner.ListMigrations();
            runner.MigrateUp(202202261248);
            return app;
        }
        
    }
}
