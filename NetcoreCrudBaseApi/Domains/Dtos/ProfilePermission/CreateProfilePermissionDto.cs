using System.ComponentModel.DataAnnotations;

namespace NetcoreCrudBaseApi.Domains.Dtos.ProfilePermission
{
    public class CreateProfilePermissionDto
    {
        [Required]
        public long ProfileId { get; set; }
        [Required]      
        public ICollection<long> PermissionIds { get; set; }
    }
}
