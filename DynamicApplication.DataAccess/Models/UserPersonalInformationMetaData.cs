namespace DynamicApplication.DataAccess.Models;

public class UserPersonalInformationMetaData
{
    public string Field {  get; set; } = string.Empty;
    
    public string Value {  get; set; } = string.Empty;

    public bool IsMandatory { get; set; }

    public bool IsInternal { get; set; }

    public bool IsHidden {  get; set; }
}