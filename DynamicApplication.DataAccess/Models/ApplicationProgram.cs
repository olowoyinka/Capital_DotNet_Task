namespace DynamicApplication.DataAccess.Models;

public class ApplicationProgram
{
    public string id { get; set; }

    public string Title { get; set; } = string.Empty;
    
    public string category { get; set; } = string.Empty;

    public DateTimeOffset CreatedOn { get; set; }
    
    public DateTimeOffset ModifiedOn { get; set; }

    public string Description { get; set; } = string.Empty;

    public PersonalInformation PersonalInformation { get; set; } = new PersonalInformation();

    public List<Questions> Questions { get; set; } = new List<Questions>();
}
