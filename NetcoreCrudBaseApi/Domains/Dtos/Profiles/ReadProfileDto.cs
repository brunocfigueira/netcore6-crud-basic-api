using NetcoreCrudBaseApi.Domains.Dtos.ProfilePermission;

namespace NetcoreCrudBaseApi.Domains.Dtos.Profiles;

public class ReadProfileDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string Acronym { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime? UpdatedAt { get; set; }
    //public ICollection<ReadProfilePermissionDto> Permissions { get; set; }
}