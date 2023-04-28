using System.ComponentModel.DataAnnotations;

namespace NetcoreCrudBaseApi.Domains.Dtos.Profiles;

public class CreateProfileDto
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }
    [Required]
    [StringLength(255, MinimumLength = 3)]
    public string Description { get; set; }
    [Required]
    [StringLength(50, MinimumLength = 3)]
    public string Acronym { get; set; }

}