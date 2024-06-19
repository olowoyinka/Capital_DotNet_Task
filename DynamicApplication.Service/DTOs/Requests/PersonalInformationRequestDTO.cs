using System.ComponentModel.DataAnnotations;

namespace DynamicApplication.Service.DTOs.Requests;

public record PersonalInformationRequestDTO
{
    [Required]
    public PersonalInformationMetaDataRequestDTO FirstName { get; set; } = new PersonalInformationMetaDataRequestDTO();

    [Required]
    public PersonalInformationMetaDataRequestDTO LastName { get; set; } = new PersonalInformationMetaDataRequestDTO();

    [Required]
    public PersonalInformationMetaDataRequestDTO Email { get; set; } = new PersonalInformationMetaDataRequestDTO();

    [Required]
    public PersonalInformationMetaDataRequestDTO Phone { get; set; } = new PersonalInformationMetaDataRequestDTO();

    [Required]
    public PersonalInformationMetaDataRequestDTO Nationality { get; set; } = new PersonalInformationMetaDataRequestDTO();

    [Required]
    public PersonalInformationMetaDataRequestDTO CurrentResidence { get; set; } = new PersonalInformationMetaDataRequestDTO();

    [Required]
    public PersonalInformationMetaDataRequestDTO IDNumber { get; set; } = new PersonalInformationMetaDataRequestDTO();

    [Required]
    public PersonalInformationMetaDataRequestDTO DateOfBirth { get; set; } = new PersonalInformationMetaDataRequestDTO();

    [Required]
    public PersonalInformationMetaDataRequestDTO Gender { get; set; } = new PersonalInformationMetaDataRequestDTO();
}
