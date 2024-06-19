using DynamicApplication.Service.DTOs.Requests;

namespace DynamicApplication.Service.DTOs.Responses;

public record PersonalInformationResponseDTO
{
    public PersonalInformationMetaDataResponseDTO FirstName { get; set; }

    public PersonalInformationMetaDataResponseDTO LastName { get; set; }

    public PersonalInformationMetaDataResponseDTO Email { get; set; }

    public PersonalInformationMetaDataResponseDTO Phone { get; set; }

    public PersonalInformationMetaDataResponseDTO Nationality { get; set; }

    public PersonalInformationMetaDataResponseDTO CurrentResidence { get; set; }

    public PersonalInformationMetaDataResponseDTO IDNumber { get; set; }

    public PersonalInformationMetaDataResponseDTO DateOfBirth { get; set; }

    public PersonalInformationMetaDataResponseDTO Gender { get; set; }
}
