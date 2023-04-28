using System.ComponentModel.DataAnnotations;

namespace NetcoreCrudBaseApi.Domains.Dtos.ProfilePermission
{
    public class UpdateProfilePermissionDto
    {
        [Required]
        public ICollection<long> PermissionIds { get; set; }
    }
}
