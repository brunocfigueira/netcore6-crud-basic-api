using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetcoreCrudBaseApi.Domains.Entities;
[Table("profile_permission")]
public class ProfilePermissionEntity
{
    [Key]
    [Required]
    [Column("id")]
    public long Id { get; set; }
    [Required]
    [Column("profile_id")]
    public long ProfileId { get; set; }
    [Required]
    [Column("permission_id")]
    public long PermissionId { get; set; }

    //public virtual ProfileEntity Profile { get; set; }
    //public virtual PermissionEntity Permission { get; set; }

}
