using NetcoreCrudBaseApi.Domains.Entities;

namespace NetcoreCrudBaseApi.Domains.Repositories;

public interface IProfileReporitory : ICrudRepository<ProfileEntity>
{
    bool IsProfileActivitided(long id);
    bool ExistsById(long id);
}
