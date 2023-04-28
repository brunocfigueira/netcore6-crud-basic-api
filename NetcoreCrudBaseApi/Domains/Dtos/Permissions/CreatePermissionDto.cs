using System.ComponentModel.DataAnnotations;

namespace NetcoreCrudBaseApi.Domains.Dtos.Permissions;

public class CreatePermissionDto
{
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Name { get; set; }
    [Required]
    [StringLength(255, MinimumLength = 3)]
    public string Description { get; set; }
}
