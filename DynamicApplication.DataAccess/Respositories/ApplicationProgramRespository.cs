using DynamicApplication.DataAccess.Models;
using DynamicApplication.DataAccess.Utilities;
using Microsoft.Azure.Cosmos;
using System.Net;

namespace DynamicApplication.DataAccess.Respositories;

public class ApplicationProgramRespository : IApplicationProgramRespository
{
    private Container _container;
    
    public ApplicationProgramRespository (CosmosClient dbClient, string databaseName, string containerName)
    {
        this._container = dbClient.GetContainer(databaseName, containerName);
    }


    public async Task<bool> AddItemAsync (ApplicationProgram model)
    {
        var result = await _container.CreateItemAsync(model, new PartitionKey(AppConstants.PartitionKey));

        return result.StatusCode == HttpStatusCode.OK ? true : false;
    }


    public async Task<ApplicationProgram> FindById(Guid id)
    {
        try
        {
            ItemResponse<ApplicationProgram> response = await _container.ReadItemAsync<ApplicationProgram>
                                                                            (id.ToString(), new PartitionKey(AppConstants.PartitionKey));
            
            return response.Resource;
        }
        catch (CosmosException ex) when (ex.StatusCode == HttpStatusCode.NotFound)
        {
            return null;
        }
    }


    public async Task<IEnumerable<ApplicationProgramMini>> GetItemsAsync<ApplicationProgramMini> (string queryString)
    {
        var query = _container.GetItemQueryIterator<ApplicationProgramMini>(new QueryDefinition(queryString));

        List<ApplicationProgramMini> results = new List<ApplicationProgramMini>();
        
        while (query.HasMoreResults)
        {
            var response = await query.ReadNextAsync();
            
            results.AddRange(response.ToList());
        }
        
        return results;
    }


    public async Task<bool> UpdateItemAsync<ApplicationProgram>(ApplicationProgram item)
    {
        var result = await _container.UpsertItemAsync(item, new PartitionKey(AppConstants.PartitionKey));

        return result.StatusCode == HttpStatusCode.OK ? true : false;
    }


    public async Task<bool> DeleteItemAsync<ApplicationProgram>(string id)
    {
        var result = await _container.DeleteItemAsync<ApplicationProgram>(id, new PartitionKey(AppConstants.PartitionKey));

        return result.StatusCode == HttpStatusCode.OK ? true : false;
    }
}