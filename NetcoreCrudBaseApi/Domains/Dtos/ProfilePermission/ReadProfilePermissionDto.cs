using NetcoreCrudBaseApi.Domains.Dtos.Permissions;
using NetcoreCrudBaseApi.Domains.Dtos.Profiles;

namespace NetcoreCrudBaseApi.Domains.Dtos.ProfilePermission
{
    public class ReadProfilePermissionDto
    {

        public long Id { get; set; }
        public long ProfileId { get; set; }
        public long PermissionId { get; set; }
        //public ReadProfileDto Profile { get; set; }
        //public ReadPermissionDto Permission { get; set; }
    }
}
