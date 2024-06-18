using DynamicApplication.DataAccess.Models;

namespace DynamicApplication.DataAccess.Respositories;

public interface IApplicationProgramRespository
{
    Task<bool> AddItemAsync(ApplicationProgram model);

    Task<ApplicationProgram> FindById(Guid id);

    Task<IEnumerable<ApplicationProgramMini>> GetItemsAsync<ApplicationProgramMini>(string queryString);

    Task<bool> UpdateItemAsync<ApplicationProgram>(ApplicationProgram item);

    Task<bool> DeleteItemAsync<ApplicationProgram>(string id);
}