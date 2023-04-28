using NetcoreCrudBaseApi.Domains.Entities;

namespace NetcoreCrudBaseApi.Domains.Repositories;

public interface IProfilePermissionRepository : ICrudRepository<ProfilePermissionEntity>
{
    bool ExistsById(long  id);
    bool ExistsPermissionsByProfileId(long profileId);
    void SaveProfilePermissions(IEnumerable<ProfilePermissionEntity> entities);
    void DeleteProfilePermissions(long profileId);
    IEnumerable<ProfilePermissionEntity> ReadByProfileId(long profileId);
}
