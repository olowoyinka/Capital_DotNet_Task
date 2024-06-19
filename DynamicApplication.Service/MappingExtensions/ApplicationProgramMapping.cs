using DynamicApplication.DataAccess.Models;
using DynamicApplication.DataAccess.Utilities;
using DynamicApplication.Service.DTOs.Requests;
using DynamicApplication.Service.DTOs.Responses;

namespace DynamicApplication.Service.MappingExtensions
{
    public static class ApplicationProgramMapping
    {
        public static ApplicationProgram ToModel(this ApplicationProgramRequestDTO model, Guid? Id = null)
        {
            return new ApplicationProgram
            {
                id = Id == null ? Guid.NewGuid().ToString() : Id.Value.ToString(),
                Description = model.Description,
                Title = model.Title,
                CreatedOn = DateTimeOffset.UtcNow,
                ModifiedOn = DateTimeOffset.UtcNow,
                category = AppConstants.PartitionKey,
                PersonalInformation = new PersonalInformation
                {
                    CurrentResidence = new PersonalInformationMetaData
                    {
                        Field = model.PersonalInformation.CurrentResidence.Field,
                        IsHidden = model.PersonalInformation.CurrentResidence.IsHidden,
                        IsInternal = model.PersonalInformation.CurrentResidence.IsInternal,
                        IsMandatory = model.PersonalInformation.CurrentResidence.IsMandatory,
                    },
                    DateOfBirth = new PersonalInformationMetaData
                    {
                        Field = model.PersonalInformation.DateOfBirth.Field,
                        IsHidden = model.PersonalInformation.DateOfBirth.IsHidden,
                        IsInternal = model.PersonalInformation.DateOfBirth.IsInternal,
                        IsMandatory = model.PersonalInformation.DateOfBirth.IsMandatory,
                    },
                    Email = new PersonalInformationMetaData
                    {
                        Field = model.PersonalInformation.Email.Field,
                        IsHidden = model.PersonalInformation.Email.IsHidden,
                        IsInternal = model.PersonalInformation.Email.IsInternal,
                        IsMandatory = model.PersonalInformation.Email.IsMandatory,
                    },
                    IDNumber = new PersonalInformationMetaData
                    {
                        Field = model.PersonalInformation.IDNumber.Field,
                        IsHidden = model.PersonalInformation.IDNumber.IsHidden,
                        IsInternal = model.PersonalInformation.IDNumber.IsInternal,
                        IsMandatory = model.PersonalInformation.IDNumber.IsMandatory,
                    },
                    FirstName = new PersonalInformationMetaData
                    {
                        Field = model.PersonalInformation.FirstName.Field,
                        IsHidden = model.PersonalInformation.FirstName.IsHidden,
                        IsInternal = model.PersonalInformation.FirstName.IsInternal,
                        IsMandatory = model.PersonalInformation.FirstName.IsMandatory,
                    },
                    Gender = new PersonalInformationMetaData
                    {
                        Field = model.PersonalInformation.Gender.Field,
                        IsHidden = model.PersonalInformation.Gender.IsHidden,
                        IsInternal = model.PersonalInformation.Gender.IsInternal,
                        IsMandatory = model.PersonalInformation.Gender.IsMandatory,
                    },
                    LastName = new PersonalInformationMetaData
                    {
                        Field = model.PersonalInformation.LastName.Field,
                        IsHidden = model.PersonalInformation.LastName.IsHidden,
                        IsInternal = model.PersonalInformation.LastName.IsInternal,
                        IsMandatory = model.PersonalInformation.LastName.IsMandatory,
                    },
                    Nationality = new PersonalInformationMetaData
                    {
                        Field = model.PersonalInformation.Nationality.Field,
                        IsHidden = model.PersonalInformation.Nationality.IsHidden,
                        IsInternal = model.PersonalInformation.Nationality.IsInternal,
                        IsMandatory = model.PersonalInformation.Nationality.IsMandatory,
                    },
                    Phone = new PersonalInformationMetaData
                    {
                        Field = model.PersonalInformation.Phone.Field,
                        IsHidden = model.PersonalInformation.Phone.IsHidden,
                        IsInternal = model.PersonalInformation.Phone.IsInternal,
                        IsMandatory = model.PersonalInformation.Phone.IsMandatory,
                    },
                },
                Questions = model.Questions.Select(s => new Questions
                {
                    Description = s.Description,
                    Field = s.Field,
                    ListFields = s.ListFields,
                    MaxAllowed = s.MaxAllowed,
                    OtherOptions = s.OtherOptions,
                    Type = s.Type,
                }).ToList()
            };
        }


        public static ApplicationProgramResponseDTO ToDTO(this ApplicationProgram model)
        {
            return new ApplicationProgramResponseDTO
            {
                ApplicationProgramId = Guid.Parse(model.id),
                Description = model.Description,
                Title = model.Title,
                PersonalInformation = new PersonalInformationResponseDTO
                {
                    CurrentResidence = new PersonalInformationMetaDataResponseDTO
                    {
                        Field = model.PersonalInformation.CurrentResidence.Field,
                        IsHidden = model.PersonalInformation.CurrentResidence.IsHidden,
                        IsInternal = model.PersonalInformation.CurrentResidence.IsInternal,
                        IsMandatory = model.PersonalInformation.CurrentResidence.IsMandatory,
                        Value = string.Empty
                    },
                    DateOfBirth = new PersonalInformationMetaDataResponseDTO
                    {
                        Field = model.PersonalInformation.DateOfBirth.Field,
                        IsHidden = model.PersonalInformation.DateOfBirth.IsHidden,
                        IsInternal = model.PersonalInformation.DateOfBirth.IsInternal,
                        IsMandatory = model.PersonalInformation.DateOfBirth.IsMandatory,
                        Value = string.Empty
                    },
                    Email = new PersonalInformationMetaDataResponseDTO
                    {
                        Field = model.PersonalInformation.Email.Field,
                        IsHidden = model.PersonalInformation.Email.IsHidden,
                        IsInternal = model.PersonalInformation.Email.IsInternal,
                        IsMandatory = model.PersonalInformation.Email.IsMandatory,
                        Value = string.Empty
                    },
                    IDNumber = new PersonalInformationMetaDataResponseDTO
                    {
                        Field = model.PersonalInformation.IDNumber.Field,
                        IsHidden = model.PersonalInformation.IDNumber.IsHidden,
                        IsInternal = model.PersonalInformation.IDNumber.IsInternal,
                        IsMandatory = model.PersonalInformation.IDNumber.IsMandatory,
                        Value = string.Empty
                    },
                    FirstName = new PersonalInformationMetaDataResponseDTO
                    {
                        Field = model.PersonalInformation.FirstName.Field,
                        IsHidden = model.PersonalInformation.FirstName.IsHidden,
                        IsInternal = model.PersonalInformation.FirstName.IsInternal,
                        IsMandatory = model.PersonalInformation.FirstName.IsMandatory,
                        Value = string.Empty
                    },
                    Gender = new PersonalInformationMetaDataResponseDTO
                    {
                        Field = model.PersonalInformation.Gender.Field,
                        IsHidden = model.PersonalInformation.Gender.IsHidden,
                        IsInternal = model.PersonalInformation.Gender.IsInternal,
                        IsMandatory = model.PersonalInformation.Gender.IsMandatory,
                        Value = string.Empty
                    },
                    LastName = new PersonalInformationMetaDataResponseDTO
                    {
                        Field = model.PersonalInformation.LastName.Field,
                        IsHidden = model.PersonalInformation.LastName.IsHidden,
                        IsInternal = model.PersonalInformation.LastName.IsInternal,
                        IsMandatory = model.PersonalInformation.LastName.IsMandatory,
                        Value = string.Empty
                    },
                    Nationality = new PersonalInformationMetaDataResponseDTO
                    {
                        Field = model.PersonalInformation.Nationality.Field,
                        IsHidden = model.PersonalInformation.Nationality.IsHidden,
                        IsInternal = model.PersonalInformation.Nationality.IsInternal,
                        IsMandatory = model.PersonalInformation.Nationality.IsMandatory,
                        Value = string.Empty
                    },
                    Phone = new PersonalInformationMetaDataResponseDTO
                    {
                        Field = model.PersonalInformation.Phone.Field,
                        IsHidden = model.PersonalInformation.Phone.IsHidden,
                        IsInternal = model.PersonalInformation.Phone.IsInternal,
                        IsMandatory = model.PersonalInformation.Phone.IsMandatory,
                        Value = string.Empty
                    },
                },
                Questions = model.Questions.Select(s => new QuestionsResponseDTO
                {
                    Description = s.Description,
                    Field = s.Field,
                    ListFields = s.ListFields,
                    MaxAllowed = s.MaxAllowed,
                    OtherOptions = s.OtherOptions,
                    Type = s.Type,
                    Value = string.Empty
                }).ToList()
            };
        }


        public static List<ApplicationProgramMiniResponseDTO> ToDTO(this IEnumerable<ApplicationProgramMini> model)
        {
            return model.Select(s => new ApplicationProgramMiniResponseDTO
            {
                id = s.id,
                category = s.category,
                CreatedOn = s.CreatedOn,
                Description = s.Description,
                ModifiedOn = s.ModifiedOn,
                Title = s.Title,
            }).ToList();
        }


        public static UserApplicationProgram ToModel(this UserApplicationProgramRequestDTO model, Guid applicationProgramId)
        {
            return new UserApplicationProgram
            {
                id = Guid.NewGuid().ToString(),
                ApplicationProgramId = applicationProgramId,
                Description = model.Description,
                Title = model.Title,
                CreatedOn = DateTimeOffset.UtcNow,
                ModifiedOn = DateTimeOffset.UtcNow,
                category = AppConstants.PartitionKey,
                PersonalInformation = new UserPersonalInformation
                {
                    CurrentResidence = new UserPersonalInformationMetaData
                    {
                        Field = model.PersonalInformation.CurrentResidence.Field,
                        IsHidden = model.PersonalInformation.CurrentResidence.IsHidden,
                        IsInternal = model.PersonalInformation.CurrentResidence.IsInternal,
                        IsMandatory = model.PersonalInformation.CurrentResidence.IsMandatory,
                        Value = model.PersonalInformation.CurrentResidence.Value,
                    },
                    DateOfBirth = new UserPersonalInformationMetaData
                    {
                        Field = model.PersonalInformation.DateOfBirth.Field,
                        IsHidden = model.PersonalInformation.DateOfBirth.IsHidden,
                        IsInternal = model.PersonalInformation.DateOfBirth.IsInternal,
                        IsMandatory = model.PersonalInformation.DateOfBirth.IsMandatory,
                        Value = model.PersonalInformation.DateOfBirth.Value,
                    },
                    Email = new UserPersonalInformationMetaData
                    {
                        Field = model.PersonalInformation.Email.Field,
                        IsHidden = model.PersonalInformation.Email.IsHidden,
                        IsInternal = model.PersonalInformation.Email.IsInternal,
                        IsMandatory = model.PersonalInformation.Email.IsMandatory,
                        Value = model.PersonalInformation.Email.Value,
                    },
                    IDNumber = new UserPersonalInformationMetaData
                    {
                        Field = model.PersonalInformation.IDNumber.Field,
                        IsHidden = model.PersonalInformation.IDNumber.IsHidden,
                        IsInternal = model.PersonalInformation.IDNumber.IsInternal,
                        IsMandatory = model.PersonalInformation.IDNumber.IsMandatory,
                        Value = model.PersonalInformation.IDNumber.Value,
                    },
                    FirstName = new UserPersonalInformationMetaData
                    {
                        Field = model.PersonalInformation.FirstName.Field,
                        IsHidden = model.PersonalInformation.FirstName.IsHidden,
                        IsInternal = model.PersonalInformation.FirstName.IsInternal,
                        IsMandatory = model.PersonalInformation.FirstName.IsMandatory,
                        Value = model.PersonalInformation.FirstName.Value,
                    },
                    Gender = new UserPersonalInformationMetaData
                    {
                        Field = model.PersonalInformation.Gender.Field,
                        IsHidden = model.PersonalInformation.Gender.IsHidden,
                        IsInternal = model.PersonalInformation.Gender.IsInternal,
                        IsMandatory = model.PersonalInformation.Gender.IsMandatory,
                        Value = model.PersonalInformation.Gender.Value,
                    },
                    LastName = new UserPersonalInformationMetaData
                    {
                        Field = model.PersonalInformation.LastName.Field,
                        IsHidden = model.PersonalInformation.LastName.IsHidden,
                        IsInternal = model.PersonalInformation.LastName.IsInternal,
                        IsMandatory = model.PersonalInformation.LastName.IsMandatory,
                        Value = model.PersonalInformation.LastName.Value,
                    },
                    Nationality = new UserPersonalInformationMetaData
                    {
                        Field = model.PersonalInformation.Nationality.Field,
                        IsHidden = model.PersonalInformation.Nationality.IsHidden,
                        IsInternal = model.PersonalInformation.Nationality.IsInternal,
                        IsMandatory = model.PersonalInformation.Nationality.IsMandatory,
                        Value = model.PersonalInformation.Nationality.Value,
                    },
                    Phone = new UserPersonalInformationMetaData
                    {
                        Field = model.PersonalInformation.Phone.Field,
                        IsHidden = model.PersonalInformation.Phone.IsHidden,
                        IsInternal = model.PersonalInformation.Phone.IsInternal,
                        IsMandatory = model.PersonalInformation.Phone.IsMandatory,
                        Value = model.PersonalInformation.Phone.Value,
                    },
                },
                Questions = model.Questions.Select(s => new UserQuestions
                {
                    Description = s.Description,
                    Field = s.Field,
                    ListFields = s.ListFields,
                    MaxAllowed = s.MaxAllowed,
                    OtherOptions = s.OtherOptions,
                    Type = s.Type,
                    Value = s.Value
                }).ToList()
            };
        }
    }
}