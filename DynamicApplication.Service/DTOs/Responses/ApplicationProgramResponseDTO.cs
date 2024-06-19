namespace DynamicApplication.Service.DTOs.Responses;

public record ApplicationProgramResponseDTO
{
    public Guid ApplicationProgramId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public PersonalInformationResponseDTO PersonalInformation { get; set; }

    public List<QuestionsResponseDTO> Questions { get; set; }
}