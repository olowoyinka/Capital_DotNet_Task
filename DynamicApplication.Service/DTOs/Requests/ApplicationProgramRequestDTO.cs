using System.ComponentModel.DataAnnotations;

namespace DynamicApplication.Service.DTOs.Requests;


public record ApplicationProgramRequestDTO
{
    [Required]
    public string Title { get; set; } = string.Empty;

    [Required]
    public string Description { get; set; } = string.Empty;

    [Required]
    public PersonalInformationRequestDTO PersonalInformation { get; set; } = new PersonalInformationRequestDTO();

    public List<QuestionsRequestDTO> Questions { get; set; } = new List<QuestionsRequestDTO>();
}