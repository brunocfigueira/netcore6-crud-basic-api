using NetcoreCrudBaseApi.Domains.Entities;

namespace NetcoreCrudBaseApi.Domains.Repositories;

public interface IPermissionRepository : ICrudRepository<PermissionEntity>
{
    bool ExistsById(long id);        
}
