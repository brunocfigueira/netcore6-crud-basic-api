using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace NetcoreCrudBaseApi.Domains.Entities;
[Table("users")]
public class UserEntity
{
    [Key]
    [Required]
    [Column("id")]
    public long Id { get; set; }
    [Column("profile_id")]
    public long ProfileId { get; set; }    
    [Column("username")]
    public string Username { get; set; }
    [Column("login")]
    public string Login { get; set; }
    [Column("password")]
    public string Password { get; set; }
    [Column("email")]
    public string Email { get; set; }
    [Column("active")]
    public bool Active { get; set; } = true;
    [Column("created_at")]
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    [Column("updated_at")]    
    public DateTime? UpdatedAt { get; set; }

    public virtual ProfileEntity Profile { get; set; }
}
