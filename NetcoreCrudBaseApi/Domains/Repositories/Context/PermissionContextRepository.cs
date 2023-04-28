using NetcoreCrudBaseApi.Domains.Context;
using NetcoreCrudBaseApi.Domains.Entities;

namespace NetcoreCrudBaseApi.Domains.Repositories.Context;

public class PermissionContextRepository : IPermissionRepository
{
    private readonly DataBaseContext _dbContext;
    public PermissionContextRepository(DataBaseContext dbContext)
    {
        _dbContext = dbContext;
    }
    public long Create(PermissionEntity entity)
    {
        _dbContext.Permission.Add(entity);
        _dbContext.SaveChanges();
        return entity.Id;
    }

    public bool Delete(long id)
    {
        _dbContext.Permission.Remove(new PermissionEntity { Id = id });
        return _dbContext.SaveChanges() > 0;
    }

    public bool ExistsById(long id)
    {
        return _dbContext.Permission.Any(entity => entity.Id == id);
    }

    public PermissionEntity? Read(long id)
    {
        return _dbContext.Permission.FirstOrDefault(entity => entity.Id == id);
    }

    public IEnumerable<PermissionEntity> Search(int skip, int take)
    {
        return _dbContext.Permission.Skip(skip).Take(take).ToList();
    }

    public bool Update(PermissionEntity entity)
    {
        _dbContext.Permission.Update(entity);
        return _dbContext.SaveChanges() > 0;
    }
}
