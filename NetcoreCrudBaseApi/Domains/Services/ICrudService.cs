namespace NetcoreCrudBaseApi.Domains.Services;

public interface ICrudService<C, U, R> where C : class where U : class where R : class
{
    long Create(C dto);
    R? Read(long id);
    bool Update(long id, U dto);
    IEnumerable<R> Search(int skip, int take);
    bool Delete(long id);
}
