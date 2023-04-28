using NetcoreCrudBaseApi.Domains.Dtos.ProfilePermission;

namespace NetcoreCrudBaseApi.Domains.Dtos.Permissions;

public class ReadPermissionDto
{
    public long Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    //public ReadProfilePermissionDto Profile { get; set; }
}