namespace DynamicApplication.DataAccess.Models;

public class PersonalInformationMetaData
{
    public string Field {  get; set; } = string.Empty;

    public bool IsMandatory { get; set; }

    public bool IsInternal { get; set; }

    public bool IsHidden {  get; set; }
}