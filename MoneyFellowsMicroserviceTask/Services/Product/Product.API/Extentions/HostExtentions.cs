using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Products.API.Extentions
{
    public static class HostExtentions
    {
        public static IHost MigrateDatabase<TContext> (this IHost host, Action<TContext, IServiceProvider> seeder, int? retry = 0) where TContext : DbContext
        {
            int retryForAvailability = retry.Value;

            using var scope = host.Services.CreateScope();
            var services = scope.ServiceProvider;
            var context = services.GetService<TContext>();

            try
            {
                InvokeSeeder(seeder, context, services);
            }
            catch (SqlException ex)
            {
                if (retryForAvailability < 10) {
                retryForAvailability  ++;
                    Thread.Sleep(2000);
                    MigrateDatabase<TContext>(host, seeder, retryForAvailability);
                }
            }

            return host;
        }


        private static void InvokeSeeder<TContext>(Action<TContext, IServiceProvider> seeder, TContext context, IServiceProvider services) where TContext: DbContext
        {
            context.Database.Migrate();
            seeder(context, services);
        }    
    }
}
