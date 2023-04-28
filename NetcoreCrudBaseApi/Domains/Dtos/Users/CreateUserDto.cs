using System.ComponentModel.DataAnnotations;

namespace NetcoreCrudBaseApi.Domains.Dtos.Users;
/**
 * Password rule explained
 *
 * Min 1 or more char TINY (?=(.*[a-z]){1,})
 * Min 1 or more char CAPITAL (?=(.*[A-Z]){1,})
 * Min 1 or more char DIGIT (.*[0-9]){1,})
 * Min 1 or more char ESPECIAL (?=(.*[!@#$%^&*()\-__+.])
 * Min 5 and Max 15 total characters {5,15}
 */
public class CreateUserDto
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
    [RegularExpression(@"^(?=(.*[a-z]){1,})(?=(.*[A-Z]){1,})(?=(.*[0-9]){1,})(?=(.*[!@#$%^&*()\\-__+.]){1,}).{5,15}$",
                        ErrorMessage = "A senha não está de acordo com as políticas de segurança")]
    public string Password { get; set; }
    [Required]
    [StringLength(255, MinimumLength = 3)]
    [EmailAddress]
    public string Email { get; set; }
}
