using Core.Database.MongoDB;
using MediaSyncServer.DataAccess;
using Microsoft.Extensions.DependencyInjection;

namespace MediaSyncServer.DependencyInjection;

public static class ApplicationRegistration
{
    public static void RegisterServices(this IServiceCollection services, IHostEnvironment env, IConfiguration configuration)
    {

        services.AddTransient(val =>
        {
            IMongoConfig mongoConfig = new MongoConfig
            {
                MongoConnectionString = configuration.GetValue<string>("MongoConnectionString"),
                MongoDatabaseName = configuration.GetValue<string>("MongoDatabaseName")
            };
            return mongoConfig;
        });

        //Repositories
        services.AddTransient<UserRepository>();
    }
}
