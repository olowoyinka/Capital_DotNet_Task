namespace DynamicApplication.DataAccess.Models;

public class UserQuestions
{
    public string Type { get; set; } = string.Empty;

    public string Field { get; set; } = string.Empty;
    
    public string Value { get; set; } = string.Empty;

    public string Description { get; set; } = string.Empty;

    public bool OtherOptions { get; set; }

    public int MaxAllowed {  get; set; }

    public List<string> ListFields { get; set; } = new List<string>();
}