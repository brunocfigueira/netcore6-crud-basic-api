using NetcoreCrudBaseApi.Domains.Context;
using NetcoreCrudBaseApi.Domains.Entities;

namespace NetcoreCrudBaseApi.Domains.Repositories.Context;

public class ProfilePermissionContextRepository : IProfilePermissionRepository
{
    private readonly DataBaseContext _dbContext;
    public ProfilePermissionContextRepository(DataBaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public long Create(ProfilePermissionEntity entity)
    {
        _dbContext.ProfilePermission.Add(entity);
        _dbContext.SaveChanges();
        return entity.Id;
    }

    public bool Delete(long id)
    {
        _dbContext.ProfilePermission.Remove(new ProfilePermissionEntity { Id = id });
        return _dbContext.SaveChanges() > 0;
    }

    public ProfilePermissionEntity? Read(long id)
    {
        return _dbContext.ProfilePermission.FirstOrDefault(entity => entity.Id == id);
    }

    public IEnumerable<ProfilePermissionEntity> Search(int skip, int take)
    {
        return _dbContext.ProfilePermission.Skip(skip).Take(take).ToList();
    }

    public bool Update(ProfilePermissionEntity entity)
    {
        _dbContext.ProfilePermission.Update(entity);
        return _dbContext.SaveChanges() > 0;
    }

    public bool ExistsById(long id)
    {
        return _dbContext.ProfilePermission.Any(entity => entity.Id == id);
    }

    public bool ExistsPermissionsByProfileId(long profileId)
    {
        return _dbContext.ProfilePermission.Any(entity => entity.ProfileId == profileId);
    }

    public void SaveProfilePermissions(IEnumerable<ProfilePermissionEntity> entities)
    {
        _dbContext.ProfilePermission.AddRange(entities);
        _dbContext.SaveChanges();
    }

    public void DeleteProfilePermissions(long profileId)
    {
        var entities = _dbContext.ProfilePermission.Where(entity => entity.ProfileId == profileId);
        _dbContext.ProfilePermission.RemoveRange(entities);
        _dbContext.SaveChanges();
    }

    public IEnumerable<ProfilePermissionEntity> ReadByProfileId(long profileId)
    {
        return _dbContext.ProfilePermission.Where(reference => reference.ProfileId == profileId).ToList();
    }
}
