namespace DynamicApplication.Service.DTOs.Responses;

public record ApplicationProgramMiniResponseDTO
{
    public string id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string category { get; set; } = string.Empty;

    public DateTimeOffset CreatedOn { get; set; }

    public DateTimeOffset ModifiedOn { get; set; }

    public string Description { get; set; } = string.Empty;
}