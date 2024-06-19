namespace DynamicApplication.Service.DTOs.Requests;

public record UserPersonalInformationRequestDTO
{
    public UserPersonalInformationMetaDataRequestDTO FirstName { get; set; }

    public UserPersonalInformationMetaDataRequestDTO LastName { get; set; }

    public UserPersonalInformationMetaDataRequestDTO Email { get; set; }

    public UserPersonalInformationMetaDataRequestDTO Phone { get; set; }

    public UserPersonalInformationMetaDataRequestDTO Nationality { get; set; }

    public UserPersonalInformationMetaDataRequestDTO CurrentResidence { get; set; }

    public UserPersonalInformationMetaDataRequestDTO IDNumber { get; set; }

    public UserPersonalInformationMetaDataRequestDTO DateOfBirth { get; set; }

    public UserPersonalInformationMetaDataRequestDTO Gender { get; set; }
}