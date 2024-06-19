namespace DynamicApplication.Service.DTOs.Requests;

public record UserApplicationProgramRequestDTO
{
    public Guid ApplicationProgramId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public UserPersonalInformationRequestDTO PersonalInformation { get; set; }

    public List<UserQuestionsRequestDTO> Questions { get; set; }
}