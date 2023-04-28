using NetcoreCrudBaseApi.Domains.Entities;

namespace NetcoreCrudBaseApi.Domains.Repositories;

public interface IUserRepository : ICrudRepository<UserEntity>
{
    UserEntity? GetUserByLoginAndPassword(string login, string password);
    bool ExistsById(long id);
}
