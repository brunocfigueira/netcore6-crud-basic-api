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
public class ChangePasswordUserDto
{
    [Required]
    [StringLength(15, MinimumLength = 5)]
    [RegularExpression(@"^(?=(.*[a-z]){1,})(?=(.*[A-Z]){1,})(?=(.*[0-9]){1,})(?=(.*[!@#$%^&*()\\-__+.]){1,}).{5,15}$",
                        ErrorMessage = "A senha não está de acordo com as políticas de segurança")]
    public string NewPassword { get; init; }
    [Required]
    [StringLength(15, MinimumLength = 5)]
    [Compare("NewPassword", ErrorMessage = "Este campo não corresponde ao campo 'NewPassword'")]
    public string NewPasswordConfirmation { get; set; }
}
