using DynamicApplication.Service.DTOs.Requests;
using DynamicApplication.Service.DTOs.Responses;
using DynamicApplication.Service.Utilities;

namespace DynamicApplication.Service.Interfaces;

public interface IApplicationProgramService
{
    Task<Result<DataResponseDTO<string>, Error>> CreateApplicationProgram(ApplicationProgramRequestDTO request);

    Task<Result<DataResponseDTO<string>, Error>> UpdateApplicationProgram(Guid applicationProgramId, ApplicationProgramRequestDTO request);

    Task<Result<DataResponseDTO<ApplicationProgramResponseDTO>, Error>> GetApplicationProgramById(Guid applicationProgramId);

    Task<Result<DataResponseDTO<List<ApplicationProgramMiniResponseDTO>>, Error>> AllGetApplicationProgram();

    Task<Result<DataResponseDTO<string>, Error>> CreateUserApplicationProgram(UserApplicationProgramRequestDTO request);
}