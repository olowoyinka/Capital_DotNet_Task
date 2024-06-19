using System.ComponentModel.DataAnnotations;

namespace DynamicApplication.Service.DTOs.Requests;

public class PersonalInformationMetaDataRequestDTO
{
    [Required]
    public string Field { get; set; } = string.Empty;

    public bool IsMandatory { get; set; }

    public bool IsInternal { get; set; }

    public bool IsHidden { get; set; }
}