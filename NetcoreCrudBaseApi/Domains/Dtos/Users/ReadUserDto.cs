using NetcoreCrudBaseApi.Domains.Dtos.Profiles;

namespace NetcoreCrudBaseApi.Domains.Dtos.Users;

public class ReadUserDto
{
    public long Id { get; set; }
    public long ProfileId { get; set; }
    public string Username { get; set; }
    public string Login { get; set; }
    public string Email { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    public ReadProfileDto Profile { get; set; }
}
