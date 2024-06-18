using DynamicApplication.DataAccess.Respositories;
using Microsoft.Azure.Cosmos;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicApplication.DataAccess;


public static class DependencyInjection
{
    public static IServiceCollection AddDataAccess (this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IApplicationProgramRespository>(InitializeCosmosClientInstanceAsync(configuration.GetSection("CosmosDb")).GetAwaiter().GetResult());
        services.AddSingleton<IUserApplicationProgramRespository>(UserInitializeCosmosClientInstanceAsync(configuration.GetSection("CosmosDb")).GetAwaiter().GetResult());

        return services;
    }


    private static async Task<ApplicationProgramRespository> InitializeCosmosClientInstanceAsync(IConfiguration configurationSection)
    {
        string databaseName = configurationSection.GetSection("DatabaseName").Value;
        string containerName = configurationSection.GetSection("ContainerName").Value;
        string account = configurationSection.GetSection("Account").Value;
        string key = configurationSection.GetSection("Key").Value;

        CosmosClient client = new CosmosClient(account, key);
        
        ApplicationProgramRespository cosmosDbService = new ApplicationProgramRespository(client, databaseName, containerName);
        
        DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);
        
        await database.Database.CreateContainerIfNotExistsAsync(containerName, "/category");

        return cosmosDbService;
    }

    private static async Task<UserApplicationProgramRespository> UserInitializeCosmosClientInstanceAsync(IConfiguration configurationSection)
    {
        string databaseName = configurationSection.GetSection("DatabaseName").Value;
        string containerName = configurationSection.GetSection("UserContainerName").Value;
        string account = configurationSection.GetSection("Account").Value;
        string key = configurationSection.GetSection("Key").Value;

        CosmosClient client = new CosmosClient(account, key);

        UserApplicationProgramRespository cosmosDbService = new UserApplicationProgramRespository(client, databaseName, containerName);

        DatabaseResponse database = await client.CreateDatabaseIfNotExistsAsync(databaseName);

        await database.Database.CreateContainerIfNotExistsAsync(containerName, "/category");

        return cosmosDbService;
    }
}