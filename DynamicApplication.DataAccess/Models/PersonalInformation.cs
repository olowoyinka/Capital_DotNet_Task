namespace DynamicApplication.DataAccess.Models;

public class PersonalInformation
{
    public PersonalInformationMetaData FirstName { get; set; }

    public PersonalInformationMetaData LastName { get; set; }

    public PersonalInformationMetaData Email { get; set; }

    public PersonalInformationMetaData Phone { get; set; }

    public PersonalInformationMetaData Nationality { get; set; }

    public PersonalInformationMetaData CurrentResidence { get; set; }

    public PersonalInformationMetaData IDNumber { get; set; }
    
    public PersonalInformationMetaData DateOfBirth { get; set; }
    
    public PersonalInformationMetaData Gender { get; set; }
}