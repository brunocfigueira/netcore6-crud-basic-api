using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NetcoreCrudBaseApi.Domains.Entities;

[Table("profiles")]
public class ProfileEntity
{
    [Key]
    [Required]
    [Column("id")]
    public long Id { get; set; }
    [Column("name")]
    public string Name { get; set; }
    [Column("description")]
    public string Description { get; set; }
    [Column("acronym")]
    public string Acronym { get; set; }
    [Column("active")]
    public bool Active { get; set; } = true;
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Column("updated_at")]
    public DateTime? UpdatedAt { get; set; }

    //public virtual ICollection<ProfilePermissionEntity> Permissions { get; set; }
}
