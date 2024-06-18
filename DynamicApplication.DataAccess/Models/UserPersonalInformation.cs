namespace DynamicApplication.DataAccess.Models;

public class UserPersonalInformation
{
    public UserPersonalInformationMetaData FirstName { get; set; }

    public UserPersonalInformationMetaData LastName { get; set; }

    public UserPersonalInformationMetaData Email { get; set; }

    public UserPersonalInformationMetaData Phone { get; set; }

    public UserPersonalInformationMetaData Nationality { get; set; }

    public UserPersonalInformationMetaData CurrentResidence { get; set; }

    public UserPersonalInformationMetaData IDNumber { get; set; }
    
    public UserPersonalInformationMetaData DateOfBirth { get; set; }
    
    public UserPersonalInformationMetaData Gender { get; set; }
}