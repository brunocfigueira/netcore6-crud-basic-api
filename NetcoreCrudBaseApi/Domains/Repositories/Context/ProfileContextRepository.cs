using NetcoreCrudBaseApi.Domains.Context;
using NetcoreCrudBaseApi.Domains.Entities;

namespace NetcoreCrudBaseApi.Domains.Repositories.Context;

public class ProfileContextRepository : IProfileReporitory
{
    private readonly DataBaseContext _dbContext;
    public ProfileContextRepository(DataBaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public long Create(ProfileEntity entity)
    {
        _dbContext.Profile.Add(entity);
        _dbContext.SaveChanges();
        return entity.Id;
    }

    public bool Delete(long id)
    {
        _dbContext.Profile.Remove(new ProfileEntity { Id = id });
        return _dbContext.SaveChanges() > 0;
    }

    public ProfileEntity? Read(long id)
    {
        return _dbContext.Profile.FirstOrDefault(entity => entity.Id == id);
    }

    public IEnumerable<ProfileEntity> Search(int skip, int take)
    {
        return _dbContext.Profile.Skip(skip).Take(take).ToList();
    }

    public bool Update(ProfileEntity entity)
    {
        _dbContext.Profile.Update(entity);
        return _dbContext.SaveChanges() > 0;
    }

    public bool IsProfileActivitided(long id)
    {
        return _dbContext.Profile.Any(entity => entity.Id == id && entity.Active == true);
    }

    public bool ExistsById(long id)
    {
        return _dbContext.Profile.Any(entity => entity.Id == id);
    }
}
