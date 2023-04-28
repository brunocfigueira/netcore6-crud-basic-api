namespace NetcoreCrudBaseApi.Domains.Repositories;

public interface ICrudRepository<Entity> where Entity : class
{
    long Create(Entity entity);
    Entity? Read(long id);
    bool Update(Entity entity);
    IEnumerable<Entity> Search(int skip, int take);
    bool Delete(long id);
}
