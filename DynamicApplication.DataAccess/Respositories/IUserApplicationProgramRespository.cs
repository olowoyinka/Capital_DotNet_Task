using DynamicApplication.DataAccess.Models;

namespace DynamicApplication.DataAccess.Respositories;

public interface IUserApplicationProgramRespository
{
    Task<bool> AddItemAsync(UserApplicationProgram model);

    Task<UserApplicationProgram> FindById(Guid id);

    Task<bool> UpdateItemAsync<UserApplicationProgram>(UserApplicationProgram item);

    Task<bool> DeleteItemAsync<UserApplicationProgram>(string id);
}