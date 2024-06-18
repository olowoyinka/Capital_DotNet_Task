using DynamicApplication.DataAccess.Models;
using DynamicApplication.DataAccess.Utilities;
using Microsoft.Azure.Cosmos;
using System.Net;

namespace DynamicApplication.DataAccess.Respositories;

public class UserApplicationProgramRespository : IUserApplicationProgramRespository
{
    private Container _container;
    
    public UserApplicationProgramRespository (CosmosClient dbClient, string databaseName, string containerName)
    {
        this._container = dbClient.GetContainer(databaseName, containerName);
    }


    public async Task<bool> AddItemAsync (UserApplicationProgram model)
    {
        var result = await _container.CreateItemAsync(model, new PartitionKey(AppConstants.PartitionKey));

        return result.StatusCode == HttpStatusCode.OK ? true : false;
    }


    public async Task<UserApplicationProgram> FindById(Guid id)
    {
        try
        {
            ItemResponse<UserApplicationProgram> response = await _container.ReadItemAsync<UserApplicationProgram>
                                                                            (id.ToString(), new PartitionKey(AppConstants.PartitionKey));
            
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }
    }


    public async Task<bool> UpdateItemAsync<UserApplicationProgram>(UserApplicationProgram item)
    {
        var result = await _container.UpsertItemAsync(item, new PartitionKey(AppConstants.PartitionKey));

        return result.StatusCode == HttpStatusCode.OK ? true : false;
    }
    

    public async Task<bool> DeleteItemAsync<UserApplicationProgram>(string id)
    {
        var result = await _container.DeleteItemAsync<UserApplicationProgram>(id, new PartitionKey(AppConstants.PartitionKey));

        return result.StatusCode == HttpStatusCode.OK ? true : false;
    }
}