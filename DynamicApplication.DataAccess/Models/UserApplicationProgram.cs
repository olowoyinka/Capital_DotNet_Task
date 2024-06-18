namespace DynamicApplication.DataAccess.Models;

public class UserApplicationProgram
{
    public string id { get; set; }
    
    public Guid ApplicationProgramId { get; set; }

    public string Title { get; set; } = string.Empty;

    public string category { get; set; } = string.Empty;

    public DateTimeOffset CreatedOn { get; set; }

    public DateTimeOffset ModifiedOn { get; set; }

    public string Description { get; set; } = string.Empty;

    public UserPersonalInformation PersonalInformation { get; set; } = new UserPersonalInformation();

    public List<UserQuestions> Questions { get; set; } = new List<UserQuestions>();
}