using DynamicApplication.DataAccess.Models;
using DynamicApplication.DataAccess.Respositories;
using DynamicApplication.Service.DTOs.Requests;
using DynamicApplication.Service.DTOs.Responses;
using DynamicApplication.Service.Interfaces;
using DynamicApplication.Service.MappingExtensions;
using DynamicApplication.Service.Utilities;
using System.Net;

namespace DynamicApplication.Service.Implementations;


public class ApplicationProgramService : IApplicationProgramService
{
    private readonly IApplicationProgramRespository _applicationProgramRespository;
    private readonly IUserApplicationProgramRespository _userApplicationProgramRespository;

    public ApplicationProgramService(IApplicationProgramRespository applicationProgramRespository, 
                                      IUserApplicationProgramRespository userApplicationProgramRespository)
    {
        _applicationProgramRespository = applicationProgramRespository;
        _userApplicationProgramRespository = userApplicationProgramRespository;
    }

    public async Task<Result<DataResponseDTO<string>, Error>> CreateApplicationProgram (ApplicationProgramRequestDTO request)
    {
        var piValidation = PersonInformationValidation(request.PersonalInformation);

        if (!piValidation.success)
            return new Error(HttpStatusCode.BadRequest, piValidation.message);

        var questionValidation = QuestionValidation(request.Questions);

        if (!questionValidation.success)
            return new Error(HttpStatusCode.BadRequest, questionValidation.message);

        var model = request.ToModel();

        await _applicationProgramRespository.AddItemAsync(model);

        return new DataResponseDTO<string> { Data = "Successfully Created" };
    }

    
    public async Task<Result<DataResponseDTO<string>, Error>> UpdateApplicationProgram (Guid applicationProgramId, ApplicationProgramRequestDTO request)
    {
        var piValidation = PersonInformationValidation(request.PersonalInformation);

        if (!piValidation.success)
            return new Error(HttpStatusCode.BadRequest, piValidation.message);

        var questionValidation = QuestionValidation(request.Questions);

        if (!questionValidation.success)
            return new Error(HttpStatusCode.BadRequest, questionValidation.message);

        var getApplicationProgram = await _applicationProgramRespository.FindById(applicationProgramId);

        if (getApplicationProgram == null)
            return new Error(HttpStatusCode.NotFound, "Application Program not found");

        var model = request.ToModel(applicationProgramId);

        await _applicationProgramRespository.UpdateItemAsync(model);

        return new DataResponseDTO<string> { Data = "Successfully Updated" };
    }


    public async Task<Result<DataResponseDTO<ApplicationProgramResponseDTO>, Error>> GetApplicationProgramById (Guid applicationProgramId)
    {
        var getApplicationProgram = await _applicationProgramRespository.FindById(applicationProgramId);

        if (getApplicationProgram == null)
            return new Error(HttpStatusCode.NotFound, "Application Program not found");

        var model = getApplicationProgram.ToDTO();

        return new DataResponseDTO<ApplicationProgramResponseDTO> { Data = model };
    }

    public async Task<Result<DataResponseDTO<List<ApplicationProgramMiniResponseDTO>>, Error>> AllGetApplicationProgram()
    {
        string query = "SELECT * FROM c";

        var getApplicationProgram = await _applicationProgramRespository.GetItemsAsync<ApplicationProgramMini>(query);

        if (getApplicationProgram == null)
            return new Error(HttpStatusCode.NotFound, "Application Program not found");

        var model = getApplicationProgram.ToDTO();

        return new DataResponseDTO<List<ApplicationProgramMiniResponseDTO>> { Data = model };
    }


    public async Task<Result<DataResponseDTO<string>, Error>> CreateUserApplicationProgram (UserApplicationProgramRequestDTO request)
    {
        var piValidation = UserPersonInformationValidation(request.PersonalInformation);

        if (!piValidation.success)
            return new Error(HttpStatusCode.BadRequest, piValidation.message);

        var questionValidation = UserQuestionValidation(request.Questions);

        if (!questionValidation.success)
            return new Error(HttpStatusCode.BadRequest, questionValidation.message);

        var getApplicationProgram = await _applicationProgramRespository.FindById(request.ApplicationProgramId);

        if (getApplicationProgram == null)
            return new Error(HttpStatusCode.NotFound, "Application Program not found");

        var model = request.ToModel(request.ApplicationProgramId);

        await _userApplicationProgramRespository.AddItemAsync(model);

        return new DataResponseDTO<string> { Data = "Successfully Submitted" };
    }


    private (bool success, string message) PersonInformationValidation(PersonalInformationRequestDTO request)
    {
        if (request == null)
            return (false, "PersonInformation is null");

        if ((request.FirstName.IsMandatory) &&
             (request.FirstName.IsInternal || request.FirstName.IsHidden))
            return (false, "FirstName is Mandatory, IsInternal and IsHidden can't be true");

        if ((request.LastName.IsMandatory) &&
             (request.LastName.IsInternal || request.LastName.IsHidden))
            return (false, "LastName is Mandatory, IsInternal and IsHidden can't be true");

        if ((request.Email.IsMandatory) &&
             (request.Email.IsInternal || request.Email.IsHidden))
            return (false, "Email is Mandatory, IsInternal and IsHidden can't be true");

        if (request.FirstName.Field is not AppConstants.STRING)
            return (false, $"FirstName Field can only {AppConstants.STRING}");

        if (request.LastName.Field is not AppConstants.STRING)
            return (false, $"LastName Field can only {AppConstants.STRING}");

        if (request.Email.Field is not AppConstants.STRING)
            return (false, $"Email Field can only {AppConstants.STRING}");

        if (request.Phone.Field is not AppConstants.NUMBER)
            return (false, $"Phone Field can only {AppConstants.NUMBER}");

        if (request.IDNumber.Field is not AppConstants.NUMBER)
            return (false, $"ID Number Field can only {AppConstants.NUMBER}");

        if (request.DateOfBirth.Field is not AppConstants.DATE)
            return (false, $"DateOfBirth Field can only {AppConstants.DATE}");

        if (request.Nationality.Field is not AppConstants.DROPDOWN)
           return (false, $"Nationality Field should have {AppConstants.DROPDOWN}");

        if (request.CurrentResidence.Field is not AppConstants.DROPDOWN)
           return (false, $"CurrentResidence Field should have {AppConstants.DROPDOWN}");

        if (request.Gender.Field != AppConstants.DROPDOWN)
           return (false, $"Gender Field should have {AppConstants.DROPDOWN}");

        return (true, string.Empty);
    }

    
    private (bool success, string message) QuestionValidation(List<QuestionsRequestDTO> request)
    {
        if (request == null || request.Count <= 0)
            return (true, string.Empty);

        var listQuestionType = new List<string>() { AppConstants.NUMBER, AppConstants.DATE, 
                                                    AppConstants.PARAGRAPH, AppConstants.YESNO,
                                                    AppConstants.DROPDOWN, AppConstants.MULTIPLE };

        var isQuestionTypeExist = request.Where(s => !listQuestionType.Contains(s.Type)).Count();

        if (isQuestionTypeExist > 0)
            return (false, "Invalid Type of Questions");

        foreach (var itemRequest in request)
        {
            if ((itemRequest.Type is AppConstants.PARAGRAPH) && itemRequest.Field is not AppConstants.STRING)
                return (false, $"{AppConstants.PARAGRAPH} field must be {AppConstants.STRING}");

            if ((itemRequest.Type is AppConstants.YESNO) && itemRequest.Field is not AppConstants.BOOL)
                return (false, $"{AppConstants.YESNO} field must be {AppConstants.BOOL}");

            if ((itemRequest.Type is AppConstants.NUMBER) && itemRequest.Field is not AppConstants.NUMBER)
                return (false, $"{AppConstants.NUMBER} field must be {AppConstants.NUMBER}");

            if ((itemRequest.Type is AppConstants.DATE) && itemRequest.Field is not AppConstants.DATE)
                return (false, $"{AppConstants.DATE} field must be {AppConstants.DATE}");

            if (itemRequest.Type is AppConstants.DROPDOWN)
            {
                if (itemRequest.Field is not AppConstants.DROPDOWN)
                    return (false, $"{AppConstants.DROPDOWN} field must be {AppConstants.DROPDOWN}");

                if (itemRequest.ListFields.Count() <= 0)
                    return (false, $"{AppConstants.DROPDOWN} ListFields can't be empty");
            }

            if (itemRequest.Type is AppConstants.MULTIPLE)
            {
                if (itemRequest.Field is not AppConstants.MULTIPLE)
                    return (false, $"{AppConstants.MULTIPLE} field must be {AppConstants.MULTIPLE}");

                if (itemRequest.ListFields.Count() <= 0)
                    return (false, $"{AppConstants.MULTIPLE} ListFields can't be empty");

                if (itemRequest.MaxAllowed <= 0)
                    return (false, $"{itemRequest.MaxAllowed} must be greater than zero");
            }
                
        }

        return (true, string.Empty);
    }


    private (bool success, string message) UserPersonInformationValidation(UserPersonalInformationRequestDTO request)
    {
        if (request == null)
            return (false, "PersonInformation is null");

        if ((request.FirstName.IsMandatory) &&
             (request.FirstName.IsInternal || request.FirstName.IsHidden))
            return (false, "FirstName is Mandatory, IsInternal and IsHidden can't be true");

        if ((request.LastName.IsMandatory) &&
             (request.LastName.IsInternal || request.LastName.IsHidden))
            return (false, "LastName is Mandatory, IsInternal and IsHidden can't be true");

        if ((request.Email.IsMandatory) &&
             (request.Email.IsInternal || request.Email.IsHidden))
            return (false, "Email is Mandatory, IsInternal and IsHidden can't be true");

        if (request.FirstName.Field is not AppConstants.STRING)
            return (false, $"FirstName Field can only {AppConstants.STRING}");

        if (string.IsNullOrWhiteSpace(request.FirstName.Value))
            return (false, "FirstName Value can't be empty");

        if (request.LastName.Field is not AppConstants.STRING)
            return (false, $"LastName Field can only {AppConstants.STRING}");

        if (string.IsNullOrWhiteSpace(request.LastName.Value))
            return (false, "LastName Value can't be empty");
        
        if (request.Email.Field is not AppConstants.STRING)
            return (false, $"Email Field can only {AppConstants.STRING}");

        if (string.IsNullOrWhiteSpace(request.Email.Value))
            return (false, "Email Value can't be empty");

        if (request.Phone.Field is not AppConstants.NUMBER)
            return (false, $"Phone Field can only {AppConstants.NUMBER}");

        if (string.IsNullOrWhiteSpace(request.Phone.Value))
            return (false, "Phone Value can't be empty");

        if (!request.Phone.Value.All(char.IsDigit))
            return (false, "Phone Value must be number");

        if (request.IDNumber.Field is not AppConstants.NUMBER)
            return (false, $"ID Number Field can only {AppConstants.NUMBER}");

        if (string.IsNullOrWhiteSpace(request.IDNumber.Value))
            return (false, "IDNumber Value can't be empty");

        if (!request.IDNumber.Value.All(char.IsDigit))
            return (false, "IDNumber Value must be number");

        if (request.DateOfBirth.Field is not AppConstants.DATE)
            return (false, $"DateOfBirth Field can only {AppConstants.DATE}");

        if (string.IsNullOrWhiteSpace(request.DateOfBirth.Value))
            return (false, "DateOfBirth Value can't be empty");

        if (!DateTime.TryParse(request.DateOfBirth.Value, out DateTime parsedDate))
            return (false, "DateOfBirth Value must be Date");

        if (request.Nationality.Field is not AppConstants.DROPDOWN)
            return (false, $"Nationality Field should have {AppConstants.DROPDOWN}");

        if (string.IsNullOrWhiteSpace(request.Nationality.Value))
            return (false, "Nationality Value can't be empty");

        if (request.CurrentResidence.Field is not AppConstants.DROPDOWN)
            return (false, $"CurrentResidence Field should have {AppConstants.DROPDOWN}");

        if (string.IsNullOrWhiteSpace(request.CurrentResidence.Value))
            return (false, "CurrentResidence Value can't be empty");

        if (request.Gender.Field != AppConstants.DROPDOWN)
            return (false, $"Gender Field should have {AppConstants.DROPDOWN}");

        if (string.IsNullOrWhiteSpace(request.Gender.Value))
            return (false, "Gender Value can't be empty");

        return (true, string.Empty);
    }

    
    private (bool success, string message) UserQuestionValidation(List<UserQuestionsRequestDTO> request)
    {
        if (request == null || request.Count <= 0)
            return (true, string.Empty);

        var listQuestionType = new List<string>() { AppConstants.NUMBER, AppConstants.DATE,
                                                    AppConstants.PARAGRAPH, AppConstants.YESNO,
                                                    AppConstants.DROPDOWN, AppConstants.MULTIPLE };

        var isQuestionTypeExist = request.Where(s => !listQuestionType.Contains(s.Type)).Count();

        if (isQuestionTypeExist > 0)
            return (false, "Invalid Type of Questions");

        foreach (var itemRequest in request)
        {
            if (itemRequest.Type is AppConstants.PARAGRAPH)
            {
                if(itemRequest.Field is not AppConstants.STRING)
                    return (false, $"{AppConstants.PARAGRAPH} field must be {AppConstants.STRING}");

                if (string.IsNullOrWhiteSpace(itemRequest.Value))
                    return (false, $"{AppConstants.PARAGRAPH} Value can't be empty");
            }

            if (itemRequest.Type is AppConstants.YESNO)
            {
                if (itemRequest.Field is not AppConstants.BOOL)
                    return (false, $"{AppConstants.YESNO} field must be {AppConstants.BOOL}");

                if (string.IsNullOrWhiteSpace(itemRequest.Value))
                    return (false, $"{AppConstants.YESNO} Value can't be empty");

                if (!bool.TryParse(itemRequest.Value, out bool parsedBoolean))
                    return (false, $"{AppConstants.YESNO} Value must be boolean");
            }

            if (itemRequest.Type is AppConstants.NUMBER)
            {
                if (itemRequest.Field is not AppConstants.NUMBER)
                    return (false, $"{AppConstants.NUMBER} field must be {AppConstants.NUMBER}");

                if (string.IsNullOrWhiteSpace(itemRequest.Value))
                    return (false, $"{AppConstants.NUMBER} Value can't be empty");

                if (!itemRequest.Value.All(char.IsDigit))
                    return (false, $"{AppConstants.NUMBER} Value must be number");
            }

            if (itemRequest.Type is AppConstants.DATE)
            {
                if (itemRequest.Field is not AppConstants.DATE)
                    return (false, $"{AppConstants.DATE} field must be {AppConstants.DATE}");

                if (string.IsNullOrWhiteSpace(itemRequest.Value))
                    return (false, $"{AppConstants.DATE} Value can't be empty");

                if (!DateTime.TryParse(itemRequest.Value, out DateTime parsedDate))
                    return (false, $"{AppConstants.DATE} Value must be Date");
            }

            if (itemRequest.Type is AppConstants.DROPDOWN)
            {
                if (itemRequest.Field is not AppConstants.DROPDOWN)
                    return (false, $"{AppConstants.DROPDOWN} field must be {AppConstants.DROPDOWN}");

                if (itemRequest.ListFields.Count() <= 0)
                    return (false, $"{AppConstants.DROPDOWN} ListFields can't be empty");

                if (string.IsNullOrWhiteSpace(itemRequest.Value))
                    return (false, $"{AppConstants.DROPDOWN} Value can't be empty");

                if (!itemRequest.ListFields.Contains(itemRequest.Value) && !itemRequest.OtherOptions)
                    return (false, $"{AppConstants.DROPDOWN} Value doesn't exist");
            }

            if (itemRequest.Type is AppConstants.MULTIPLE)
            {
                if (itemRequest.Field is not AppConstants.MULTIPLE)
                    return (false, $"{AppConstants.MULTIPLE} field must be {AppConstants.MULTIPLE}");

                if (itemRequest.ListFields.Count() <= 0)
                    return (false, $"{AppConstants.MULTIPLE} ListFields can't be empty");

                if (itemRequest.MaxAllowed <= 0)
                    return (false, $"{itemRequest.MaxAllowed} must be greater than zero");

                if (string.IsNullOrWhiteSpace(itemRequest.Value))
                    return (false, $"{AppConstants.MULTIPLE} Value can't be empty");

                var listValue = itemRequest.Value.Split(',').ToList();

                if (listValue.Count() > itemRequest.MaxAllowed)
                    return (false, $"{AppConstants.MULTIPLE} value can't be grater than {itemRequest.MaxAllowed}");

                if (itemRequest.ListFields.Where(s => !listValue.Contains(s)).Count() > 0 && !itemRequest.OtherOptions)
                    return (false, $"{AppConstants.MULTIPLE} Value invalid");
            }

        }

        return (true, string.Empty);
    }
}