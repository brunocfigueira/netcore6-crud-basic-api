using Microsoft.EntityFrameworkCore;
using NetcoreCrudBaseApi.Domains.Context;
using NetcoreCrudBaseApi.Domains.Entities;

namespace NetcoreCrudBaseApi.Domains.Repositories.Context;

public class UserContextRepository : IUserRepository
{
    private readonly DataBaseContext _dbContext;

    public UserContextRepository(DataBaseContext dbContext)
    {
        _dbContext = dbContext;
    }

    public long Create(UserEntity entity)
    {
        _dbContext.User.Add(entity);
        _dbContext.SaveChanges();
        return entity.Id;
    }

    public bool Delete(long id)
    {
        _dbContext.User.Remove(new UserEntity { Id = id });
        return _dbContext.SaveChanges() > 0;
    }

    public UserEntity? Read(long id)
    {
        return _dbContext.User.FirstOrDefault(entity => entity.Id == id);
    }

    public IEnumerable<UserEntity> Search(int skip, int take)
    {
        return _dbContext.User.Skip(skip).Take(take).ToList();
    }

    public bool Update(UserEntity entity)
    {
        _dbContext.User.Update(entity);
        return _dbContext.SaveChanges() > 0;
    }

    public UserEntity? GetUserByLoginAndPassword(string login, string password)
    {
        return _dbContext.User.FirstOrDefault(reference => reference.Login == login);
    }

    public bool ExistsById(long id)
    {
        return _dbContext.User.Any(entity=>entity.Id == id);
    }
}
