using System.ComponentModel.DataAnnotations;

namespace NetcoreCrudBaseApi.Domains.Dtos.Users;

public class UpdateUserDto
{
    [Required]
    public long ProfileId { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Username { get; set; }
    [Required]
    [StringLength(100, MinimumLength = 3)]
    public string Login { get; set; }
    [Required]
    [StringLength(255, MinimumLength = 3)]
    [EmailAddress]
    public string Email { get; set; }
    [Required]
    public bool? Active { get; set; }
}
